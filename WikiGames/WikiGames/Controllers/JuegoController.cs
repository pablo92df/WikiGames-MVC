using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WikiGames.Data;

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
    }
}
