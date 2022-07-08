using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WikiGames.Data;
using WikiGames.Models.ViewModel.DesarrolladoresViewModel;
using WikiGames.Models.Entities;
using System.IO;
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
           var desarrollador =  await desarrolladorRepository.GetAllInfo(id);
            var desarrolladorView = mapper.Map<DesarrolladorAllInfoViewModel>(desarrollador);
            //    return View(desarrolladorDTO);
            //}
            return View(desarrolladorView);
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
			if (img is null)
			{
                FileStream stream = new FileStream(Path.Combine(path, name), FileMode.Create);
               await imgDesarrollador.CopyToAsync(stream);
                
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
            var desarr = await desarrolladorRepository.GetById(desarrolladorEditDTO.DesarrolladorId);
            if (desarr is null) 
            {
                return RedirectToAction("NoEncontrado", "Home");
            }
            context.Entry<Desarrollador>(desarr).State = EntityState.Detached;

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
                await imgDesarrollador.CopyToAsync(stream);
                stream.Close();

                DeleteFile(imgDesarrolladorOld.ImagePath);

                imgDesarrolladorOld.Nombre = imgDesa.Nombre;
                imgDesarrolladorOld.ImagePath = imgDesa.ImagePath;

                await icrud.Update<ImgDesarrolladores>(imgDesarrolladorOld);

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

        public async Task<IActionResult> Delete(int id) 
        {
            var desarrolladora = await desarrolladorRepository.GetById(id);
            if (desarrolladora is null) 
            {
                return RedirectToAction("NoEncontrado", "Home");
            }

            var desarrolladorView = mapper.Map<DesarrolladorViewModel>(desarrolladora);

            return View(desarrolladorView);

        }
        [HttpPost]
        public async Task<IActionResult> DeleteDesarrolladora(int DesarrolladorId) 
        {

            var desarrolladora = await desarrolladorRepository.GetById(DesarrolladorId);
            if (desarrolladora is null) 
            {
                return RedirectToAction("NoEncontrado", "Home");
            }
            var imgDesarrolladora = await icrud.GetByID<ImgDesarrolladores>(desarrolladora.ImgDesarrolladores.ImgDesarrolladoresId);
            
            DeleteFile(imgDesarrolladora.ImagePath);


            await icrud.Delete<Desarrollador>(desarrolladora);
            //context.Entry<Desarrollador>(desarrolladora).State = EntityState.Detached;

           // context.Entry<ImgDesarrolladores>(imgDesarrolladora).State = EntityState.Detached;

            await icrud.Delete<ImgDesarrolladores>(imgDesarrolladora);


            return RedirectToAction("Index");
        }

        private bool DeleteFile(string path)
        {
            var ruta = Path.Combine(this.hostingEnvironment.WebRootPath + path);
            
            FileInfo file = new FileInfo(ruta);
            if (file.Exists)
            { 
                file.Delete();
                return true;
            }
            return false;
        }
    }
}
