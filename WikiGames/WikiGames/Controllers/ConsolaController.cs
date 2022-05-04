using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WikiGames.Data;
using WikiGames.Models.DTO.Consola;
using WikiGames.Models.Entities;

namespace WikiGames.Controllers
{
    public class ConsolaController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public ConsolaController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;

        }
        public async Task<IActionResult> Index()
        {
            List<ConsolaDTO> consolaDTO = await context.Consolas.ProjectTo<ConsolaDTO>(mapper.ConfigurationProvider).ToListAsync();
           // List<Consola> consola = await context.Consolas.Include(m => m.Marca).ToListAsync();
            return View(consolaDTO);
        }
        public async Task<IActionResult> ConsolaInfo()
        {
            //List<ConsolaDTO> consolaDTO = await context.Consolas.ProjectTo<ConsolaDTO>(mapper.ConfigurationProvider).ToListAsync();
            List<Consola> consola = await context.Consolas.ToListAsync();
            return View(consola);
        }

        public IActionResult Create() 
        {
            ViewData["Marcas"] = new SelectList(context.Marcas, "MarcaId", "MarcaName");

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ConsolaCreacionDTO consolaDTO) 
        {
            if (!(ModelState.IsValid)) 
            {
                //consolaDTO.Marca = context.Marcas.FirstOrDefault(m=>m.MarcaId == consolaDTO.MarcaId);
                //Consola consola = new Consola() 
                //{
                //    ConsolaName = consolaDTO.ConsolaName,
                //    MarcaId = consolaDTO.MarcaId,
                //    FechaLanzamiento = consolaDTO.FechaLanzamiento,
                //    Descripcion = consolaDTO.Descripcion
                //};
                var consola = mapper.Map<Consola>(consolaDTO);
                context.Add(consola);
                await context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
