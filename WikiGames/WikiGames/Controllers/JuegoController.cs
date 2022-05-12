using AutoMapper;
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
        private readonly IMapper mapper;
        public JuegoController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var Juegos = await context.Juegos
                .Include(j => j.Generos.OrderByDescending(g => g.Nombre))
                .Include(j => j.JuegoConsola)
                 .ThenInclude(jc => jc.Consola).ThenInclude(c => c.Marca).ToListAsync();

            return View(Juegos);
        }
        public async Task<IActionResult> AllInfo(int id) 
        {
            var Juegos = await context.Juegos
                    .Where(j=>j.JuegoId == id)
                    .Include(j => j.Generos.OrderByDescending(g => g.Nombre))
                    .Include(j => j.JuegoConsola)
                     .ThenInclude(jc => jc.Consola).ThenInclude(c => c.Marca)
                     .Include(j=>j.Desarrolladora).FirstOrDefaultAsync();

            return View(Juegos);
        }
        public IActionResult Create()
        {
            ViewData["Generos"] = new SelectList(context.Generos, "GeneroId", "Nombre");
            ViewData["Consolas"] = new SelectList(context.Consolas, "ConsolaId", "ConsolaName");
            ViewData["Desarrollador"] = new SelectList(context.Desarrolladores, "DesarrolladorId", "DesarrolladorName");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(JuegoCreacionDTO juegoDTO)
        {
            var jueguito = mapper.Map<Juego>(juegoDTO);
            //Juego jueguito = new Juego() 
            //{
            //    JuegoName = juegoDTO.JuegoName,
            //    JuegoDescription = juegoDTO.Descripcion,
            //    FechaLanzamientoOficial = juegoDTO.FechaLanzamientoOficial
            //};
            jueguito.Generos.ForEach(g => context.Entry(g).State = EntityState.Unchanged);
            jueguito.Desarrolladora.ForEach(d => context.Entry(d).State = EntityState.Unchanged);
            if (juegoDTO.JuegosConsolaDTO is not null)
            {
                List<JuegoConsola> jconsola = new List<JuegoConsola>();

                for (int i = 0; i < juegoDTO.JuegosConsolaDTO.Count; i++)
                {
                    jconsola.Add(new JuegoConsola());
                    jconsola[jconsola.Count-1] = mapper.Map<JuegoConsola>(juegoDTO.JuegosConsolaDTO[i]);
                }
                jueguito.JuegoConsola = jconsola;
            }
            context.Add(jueguito);
            await context.SaveChangesAsync();

            return RedirectToAction("Index");
          //  return View(juegoDTO);
        }


    }
}
