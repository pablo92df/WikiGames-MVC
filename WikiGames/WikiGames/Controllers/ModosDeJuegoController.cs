using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WikiGames.Data;
using WikiGames.Models.Entities;

namespace WikiGames.Controllers
{
    public class ModosDeJuegoController : Controller
    {
        private readonly ApplicationDbContext context;

        public ModosDeJuegoController(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<IActionResult> Index()
        {
            var modos = await context.ModosDeJuegos.ToListAsync();
            return View(modos);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ModosDeJuego modosDeJuego)
        {
            if (ModelState.IsValid)
            {
                context.ModosDeJuegos.Add(modosDeJuego);
                await context.SaveChangesAsync();
                TempData["mensaje"] = "Cargado con exito";
                return RedirectToAction("Index");
            }

            TempData["mensaje"] = "Error al cargar";
            return View();
        }

    }
}
