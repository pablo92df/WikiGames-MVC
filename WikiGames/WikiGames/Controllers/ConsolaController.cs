using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WikiGames.Data;
using WikiGames.Models.ViewModel.ConsolaViewModel;
using WikiGames.Models.Entities;

namespace WikiGames.Controllers
{
    public class ConsolaController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IWebHostEnvironment hostingEnvironment;
        private readonly IMapper mapper;

        public ConsolaController(ApplicationDbContext context, IMapper mapper, IWebHostEnvironment hostingEnvironment)
        {
            this.context = context;
            this.mapper = mapper;
            this.hostingEnvironment = hostingEnvironment;
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
    }
}
