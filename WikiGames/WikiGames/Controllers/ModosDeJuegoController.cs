using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WikiGames.Data;
using WikiGames.Models.Entities;
using WikiGames.Services.RepositoriesInterface;

namespace WikiGames.Controllers
{
    public class ModosDeJuegoController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly ICRUD icrud;

        public ModosDeJuegoController(ApplicationDbContext context, ICRUD icrud)
        {
            this.context = context;
            this.icrud = icrud;
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

                await icrud.Create<ModosDeJuego>(modosDeJuego);
                TempData["mensaje"] = "Cargado con exito";
                return RedirectToAction("Index");
            }

            TempData["mensaje"] = "Error al cargar";
            return View();
        }

    }
}
