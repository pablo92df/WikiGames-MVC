using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WikiGames.Data;
using WikiGames.Models.DTO.Juego;
using WikiGames.Models.Entities;

namespace WikiGames.Controllers
{
    public class JuegoController : Controller
    {
        private readonly ApplicationDbContext context;

        public JuegoController(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<IActionResult> Index()
        {
            var Juegos = await context.Juegos
                .Include(j => j.Generos.OrderByDescending(g => g.Nombre))
                .Include(j => j.JuegoConsola)
                 .ThenInclude(jc => jc.Consola).ThenInclude(c => c.Marca).ToListAsync();

            return View(Juegos);
        }

        public IActionResult Create()
        {
            ViewData["Generos"] = new SelectList(context.Generos, "GeneroId", "Nombre");
            ViewData["Consolas"] = new SelectList(context.Consolas, "ConsolaId", "ConsolaName");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(JuegoCreacionDTO juegoDTO)
        {
            var jueguito = juegoDTO;
            return View(juegoDTO);
        }


    }
}
