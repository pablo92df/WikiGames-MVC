using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WikiGames.Data;

namespace WikiGames.Controllers
{
    public class PublicadoraController : Controller
    {
        private readonly ApplicationDbContext context;

        public PublicadoraController(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<IActionResult> Index()
        {
            var publicadoras = await context.Publicadoras.ToListAsync();
            return View(publicadoras);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(PublicadoraController publi)
        {
            if (ModelState.IsValid)
            {
                context.Add(publi);
                await context.SaveChangesAsync();
                TempData["mensaje"] = "Publicadora Cargado con exito";

                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
