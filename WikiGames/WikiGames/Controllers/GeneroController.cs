using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WikiGames.Data;
using WikiGames.Models.DTO;
using WikiGames.Models.Entities;

namespace WikiGames.Controllers
{
    public class GeneroController : Controller
    {
        private readonly ApplicationDbContext context;

        public GeneroController(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async  Task<IActionResult> Index()
        {
            var generos = await context.Generos.OrderBy(g=>g.Nombre).ToListAsync();
            return View(generos);
        }
        public IActionResult Create()
        { 
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(GeneroDTO generoDTO) 
        {
            if (!(generoDTO is null)) 
            {
                Genero genero = new Genero()
                    {
                        Nombre = generoDTO.Nombre
                    };

                context.Generos.Add(genero);
                context.SaveChanges();
                TempData["mensaje"] = "Genero Cargado con exito";
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
