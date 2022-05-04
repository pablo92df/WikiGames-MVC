using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WikiGames.Data;
using WikiGames.Models.DTO;
using WikiGames.Models.Entities;

namespace WikiGames.Controllers
{
    public class MarcaController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public MarcaController(ApplicationDbContext context, IMapper mapper)
        {
            this.mapper = mapper;

            this.context = context;
        }
        public async Task<IActionResult> Index()
        {
            var marcas = await context.Marcas.OrderBy(m => m.MarcaName).ToListAsync();
            return View(marcas);
        }

        public IActionResult Create()
        { 
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(MarcaCreacionDTO marcaDTO)
        {
            //Marca marca = new Marca() 
            //{
            //    MarcaName = marcaDTO.MarcaName,
            //};
            //var marca = 
            //context.Marcas.Add(marca);
            //context.SaveChanges();
            //TempData["mensaje"] = "Marca Cargada con exito";
            return RedirectToAction("Index");
          
            //return View();
        }
    }
}
