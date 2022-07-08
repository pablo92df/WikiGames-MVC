using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WikiGames.Data;
using WikiGames.Models.ViewModel.ConsolaViewModel;
using WikiGames.Models.Entities;
using WikiGames.Services.RepositoriesInterface;

namespace WikiGames.Controllers
{
    public class ConsolaController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IWebHostEnvironment hostingEnvironment;
        private readonly ICRUD icrud;
        private readonly IConsolaRepository consolaRepository;
        private readonly IImgConsolasRepository imgConsolasRepository;
        private readonly IMapper mapper;

        public ConsolaController(ApplicationDbContext context, IMapper mapper, IWebHostEnvironment hostingEnvironment, ICRUD icrud, IConsolaRepository consolaRepository, IImgConsolasRepository imgConsolasRepository)
        {
            this.context = context;
            this.mapper = mapper;
            this.hostingEnvironment = hostingEnvironment;
            this.icrud = icrud;
            this.consolaRepository = consolaRepository;
            this.imgConsolasRepository = imgConsolasRepository;
        }
        public async Task<IActionResult> Index(string ConsolaName, int MarcaId)
        {
            ViewBag.Marcas = new SelectList(context.Marcas.OrderBy(m => m.MarcaName), "MarcaId", "MarcaName");

            var consolaQueryable = context.Consolas.AsQueryable();

            if (!string.IsNullOrEmpty(ConsolaName)) 
            {
                consolaQueryable = consolaQueryable.Where(c => c.ConsolaName.Contains(ConsolaName) || c.Marca.MarcaName.Contains(ConsolaName));
                
            }
            if (MarcaId > 0) 
            {
                consolaQueryable = consolaQueryable.Where(c => c.MarcaId == MarcaId);
            }
            var consolas = await context.Consolas.Include(c => c.imgConsolas).ToListAsync();
            List<ConsolaViewModel> consola = await consolaQueryable.ProjectTo<ConsolaViewModel>(mapper.ConfigurationProvider).OrderBy(c=>c.Marca.MarcaName).ToListAsync();


            return View(consola);
        }
        public async Task<IActionResult> AllInfo(int id)
        {
       
            Consola con = await context.Consolas
                .Where(c => c.ConsolaId == id)
                .Include(c=>c.JuegoConsola)
                .ThenInclude(jc=>jc.Juego)
                    .ThenInclude(d=>d.Desarrolladora)
                .Include(c=>c.Marca)
                .Include(c=>c.imgConsolas)
                .FirstOrDefaultAsync();
            ConsolaAllInfoViewModel consola = mapper.Map<ConsolaAllInfoViewModel>(con);


            return View(consola);
        }

        public IActionResult Create() 
        {
            ViewData["Marcas"] = new SelectList(context.Marcas, "MarcaId", "MarcaName");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ConsolaCreacionViewModel consolaDTO, IFormFile imgConsolas) 
        {
            if (!ModelState.IsValid) 
            {
                ViewData["Marcas"] = new SelectList(context.Marcas, "MarcaId", "MarcaName");
                return View(consolaDTO);
            }
            var marca = context.Marcas.Where(x => x.MarcaId == consolaDTO.MarcaId).FirstOrDefaultAsync();
            if(marca is null) 
            { 
                return View(consolaDTO);
            }
            ImgConsolas imgConsola = new ImgConsolas();
            string name = Path.GetFileName(imgConsolas.FileName);
            string path = Path.Combine(this.hostingEnvironment.WebRootPath, "Images/IMGConsolas");

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            imgConsola.ImagePath = "\\Images\\IMGConsolas\\" + name;
            imgConsola.Nombre = name;
            var img = await context.ImgConsolas.Where(i => i.ImagePath == imgConsola.ImagePath).FirstOrDefaultAsync();
            if (img == null)
            {
                FileStream stream = new FileStream(Path.Combine(path, name), FileMode.Create);
                imgConsolas.CopyTo(stream);
                stream.Close();
                context.ImgConsolas.Add(imgConsola);
                await context.SaveChangesAsync();
                var consola = mapper.Map<Consola>(consolaDTO);
                consola.imgConsolas = imgConsola;
                context.Consolas.Add(consola);
                await context.SaveChangesAsync();
                TempData["mensaje"] = "Consola Cargada con exito";
                return RedirectToAction("Index");

            }


            TempData["mensaje"] = "Error al Cargar datos";

            return RedirectToAction("Index");

        }

        public async Task<IActionResult> Edit(int id) 
        {
            var consola = await consolaRepository.GetConsolaById(id);
            if (consola is null)
            {
                return RedirectToAction("NoEncontrado", "Home");
            }
            ViewData["Marcas"] = new SelectList(context.Marcas, "MarcaId", "MarcaName");

            var consolaView = mapper.Map<ConsolaCreacionViewModel>(consola);
            return View(consolaView);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(ConsolaCreacionViewModel consolaEdit, IFormFile img)
        {
            if (!ModelState.IsValid) 
            {
                return View(consolaEdit);
            }

            var consolaexist = await consolaRepository.GetConsolaById(consolaEdit.ConsolaId);

            if (consolaexist is null)
            {
                return RedirectToAction("NoEncontrado", "Home");
            }
            context.Entry<Consola>(consolaexist).State = EntityState.Detached;
            if (img is not null)
            {
                ImgConsolas imgCon = new ImgConsolas();
                string name = Path.GetFileName(img.FileName);
                string path = Path.Combine(this.hostingEnvironment.WebRootPath, "Images/IMGConsolas");

                imgCon.ImagePath = "\\Images\\IMGConsolas\\" + name;
                imgCon.Nombre = name;

                var imgConsolaOld = await imgConsolasRepository.GetById(consolaEdit.ImgConsolasId);

                FileStream stream = new FileStream(Path.Combine(path, name), FileMode.Create);
                await img.CopyToAsync(stream);
                stream.Close();

                DeleteFile(imgConsolaOld.ImagePath);
                imgConsolaOld.Nombre = imgCon.Nombre;
                imgConsolaOld.ImagePath = imgCon.ImagePath;
                 await icrud.Update<ImgConsolas>(imgConsolaOld);

                consolaEdit.imgConsolas = imgConsolaOld;
            }
            else
            {
                var imgConsolaOld = await imgConsolasRepository.GetById(consolaEdit.ImgConsolasId);

                if (imgConsolaOld is not null)
                    consolaEdit.imgConsolas = imgConsolaOld;
                else
                    return RedirectToAction("Index");

            }

            consolaexist = mapper.Map<Consola>(consolaEdit);

            await icrud.Update<Consola>(consolaexist);

            TempData["mensaje"] = "Datos Editados correctamente";

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
