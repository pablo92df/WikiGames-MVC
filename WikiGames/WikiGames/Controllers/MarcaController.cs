using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WikiGames.Data;
using WikiGames.Models.Entities;

namespace WikiGames.Controllers
{
    public class MarcaController : Controller
    {
        private readonly ApplicationDbContext context;

        public MarcaController(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<IActionResult> Index()
        {
            var marcas = await context.Marcas.OrderBy(m => m.MarcaName).ToListAsync();
            return View();
        }

        public IActionResult Create()
        { 
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Marca marca)
        {
            if (!(marca is null))
            {
                context.Marcas.Add(marca);
                context.SaveChanges();
                TempData["mensaje"] = "Marca Cargada con exito";
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
