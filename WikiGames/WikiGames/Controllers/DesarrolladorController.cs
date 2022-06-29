using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WikiGames.Data;
using WikiGames.Models.ViewModel.DesarrolladoresViewModel;
using WikiGames.Models.Entities;

using WikiGames.Services.RepositoriesInterface;

namespace WikiGames.Controllers
{
    public class DesarrolladorController : Controller
    {
     
        private readonly IWebHostEnvironment hostingEnvironment;
        private readonly IDesarrolladorRepository desarrolladorRepository;
		private readonly IImgDesarrolladoresRepository imgDesarrolladoresRepository;
        private readonly ICRUD icrud;
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public DesarrolladorController(IMapper mapper,
            IWebHostEnvironment hostingEnvironment,
            IDesarrolladorRepository desarrolladorRepository,
            IImgDesarrolladoresRepository imgDesarrolladoresRepository, ICRUD icrud, ApplicationDbContext context)
        {
      
            this.mapper = mapper;
            this.hostingEnvironment = hostingEnvironment;
            this.desarrolladorRepository = desarrolladorRepository;
			this.imgDesarrolladoresRepository = imgDesarrolladoresRepository;
            this.icrud = icrud;
            this.context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Index(string desarrolladorName)
        {

            var desarrolladores = await desarrolladorRepository.GetAll(desarrolladorName);
            var desarrolladorViewModel = mapper.Map<List<DesarrolladorViewModel>>(desarrolladores);
            return View(desarrolladorViewModel);
        }


        public async Task<IActionResult> AllInfo(int id) 
        {
            //if (id >= 0) 
            //{
            //    Desarrollador desarrollador = await context.Desarrolladores.Where(d => d.DesarrolladorId == id)
            //        .Include(d=>d.Juegos)
            //            .ThenInclude(j=>j.Generos)
            //        .Include(d=>d.ImgDesarrolladores)
            //        .FirstOrDefaultAsync();
            //    var desarrolladorDTO = mapper.Map<DesarrolladorViewModel>(desarrollador);
            await desarrolladorRepository.GetById(id);
            //    return View(desarrolladorDTO);
            //}
            return View();
        }
        public IActionResult Create() 
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(DesarrolladorCreacionViewModel desarrolladorCreacionDTO, IFormFile imgDesarrollador)
        {

            if (!ModelState.IsValid) 
            {
                return View(desarrolladorCreacionDTO);
            }
			ImgDesarrolladores imgDesa = new ImgDesarrolladores();
			string name = Path.GetFileName(imgDesarrollador.FileName);
			string path = Path.Combine(this.hostingEnvironment.WebRootPath, "Images/IMGDesarrolladores");
			if (!Directory.Exists(path))
			{
				Directory.CreateDirectory(path);
			}
			imgDesa.ImagePath = "\\Images\\IMGDesarrolladores\\" + name;
			imgDesa.Nombre = name;
			var img = await imgDesarrolladoresRepository.GetByPath(imgDesa.ImagePath);
			if (img == null)
			{
                FileStream stream = new FileStream(Path.Combine(path, name), FileMode.Create);
                imgDesarrollador.CopyTo(stream);
                stream.Close();

                    await icrud.Create(imgDesa);


                 var desarrollador = mapper.Map<Desarrollador>(desarrolladorCreacionDTO);
                 desarrollador.ImgDesarrolladores = imgDesa;
                 await icrud.Create<Desarrollador>(desarrollador);

                return RedirectToAction("Index");

            }

            return View(desarrolladorCreacionDTO);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var desarrollador = await desarrolladorRepository.GetById(id);

            if (desarrollador is null)
            {
                return RedirectToAction("Index");
            }

            var desarrolladorViewModel = mapper.Map<DesarrolladorEditViewModel>(desarrollador);

            return View(desarrolladorViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(DesarrolladorEditViewModel desarrolladorEditDTO, IFormFile imgDesarrollador)
        {

            if (!ModelState.IsValid)
            {
                return View(desarrolladorEditDTO);
            }
            if (imgDesarrollador is not null)
            {
                ImgDesarrolladores imgDesa = new ImgDesarrolladores();
                string name = Path.GetFileName(imgDesarrollador.FileName);
                string path = Path.Combine(this.hostingEnvironment.WebRootPath, "Images/IMGDesarrolladores");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                imgDesa.ImagePath = "\\Images\\IMGDesarrolladores\\" + name;
                imgDesa.Nombre = name;

                var imgDesarrolladorOld = await imgDesarrolladoresRepository.GetById(desarrolladorEditDTO.ImgDesarrolladores.ImgDesarrolladoresId);

                FileStream stream = new FileStream(Path.Combine(path, name), FileMode.Create);
                imgDesarrollador.CopyTo(stream);
                stream.Close();

                imgDesarrolladorOld.Nombre = imgDesa.Nombre;
                imgDesarrolladorOld.ImagePath = imgDesa.ImagePath;

                await icrud.Update<ImgDesarrolladores>(imgDesa);

                desarrolladorEditDTO.ImgDesarrolladores = imgDesarrolladorOld;
            }
            else
            { 
                var imgDesarrolladorOld = await imgDesarrolladoresRepository.GetById(desarrolladorEditDTO.ImgDesarrolladores.ImgDesarrolladoresId);

                if (imgDesarrolladorOld is not null)
                    desarrolladorEditDTO.ImgDesarrolladores = imgDesarrolladorOld;
                else
                    return RedirectToAction("Index");

            }



            var desarrollador = mapper.Map<Desarrollador>(desarrolladorEditDTO);
 
            await icrud.Update<Desarrollador>(desarrollador);

            return RedirectToAction("Index");
        }
    }
}
