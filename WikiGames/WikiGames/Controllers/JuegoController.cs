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
        public async Task<IActionResult> Index([FromQuery] JuegoFiltroDTO juegoFiltroDTO)
        {
            // ViewData["Desarrollador"] = new SelectList(context.Desarrolladores, "DesarrolladorId", "DesarrolladorName");
            ViewBag.Desarrolladores = new SelectList(context.Desarrolladores.OrderBy(x => x.DesarrolladorName), "DesarrolladorId", "DesarrolladorName");
            ViewData["Generos"] = new SelectList(context.Generos, "GeneroId", "Nombre");
            ViewData["Consolas"] = new SelectList(context.Consolas, "ConsolaId", "ConsolaName");
            ViewData["Publicadora"] = new SelectList(context.Publicadoras, "PublicadoraId", "PublicadoraNombre");
            ViewData["ModoJuegos"] = new SelectList(context.ModosDeJuegos, "ModosDeJuegoId", "ModosDeJuegoName");
            var juegoQueryable = context.Juegos.AsQueryable();
            if (!string.IsNullOrEmpty(juegoFiltroDTO.JuegoName))
            {
                juegoQueryable = juegoQueryable.Where(p => p.JuegoName.Contains(juegoFiltroDTO.JuegoName));
            }

            if (juegoFiltroDTO.GeneroId != 0)
            {
                juegoQueryable = juegoQueryable.Where(p => p.Generos
                                                .Select(g => g.GeneroId)
                                                .Contains(juegoFiltroDTO.GeneroId));
            }
            if (juegoFiltroDTO.ConsolaId != 0)
            {
                juegoQueryable = juegoQueryable.Where(p => p.JuegoConsola
                                                .Select(g => g.ConsolaId)
                                                .Contains(juegoFiltroDTO.ConsolaId));
            }
            if (juegoFiltroDTO.DesarrolladoraId != 0)
            {
                juegoQueryable = juegoQueryable.Where(p => p.Desarrolladora.DesarrolladorId == juegoFiltroDTO.DesarrolladoraId);

            }
            if (juegoFiltroDTO.PublicadoraId != 0)
            {
                juegoQueryable = juegoQueryable.Where(p => p.Publicadora.PublicadoraId == juegoFiltroDTO.PublicadoraId);
            }
            if (juegoFiltroDTO.ModoDeJuegoId != 0)
            {
                juegoQueryable = juegoQueryable.Where(p => p.ModosDeJuegos
                                                .Select(g => g.ModosDeJuegoId)
                                                .Contains(juegoFiltroDTO.ModoDeJuegoId));
            }

            var juegos = await juegoQueryable.Include(j => j.Generos)
                                             .Include(j => j.Desarrolladora)
                                             .Include(j => j.Publicadora).ToListAsync();

            var Juegos = await context.Juegos
                .Include(j => j.Generos.OrderByDescending(g => g.Nombre))
                .Include(j => j.Desarrolladora)
                .Include(j => j.Publicadora).ToListAsync();


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

        //public async Task<IActionResult> Filtrar([FromQuery] JuegoFiltroDTO juegoFiltroDTO)
        //{
        //    var juegoQueryable = context.Juegos.AsQueryable();
        //    if (!string.IsNullOrEmpty(juegoFiltroDTO.JuegoName))
        //    {
        //        juegoQueryable = juegoQueryable.Where(p => p.JuegoName.Contains(juegoFiltroDTO.JuegoName));
        //    }

        //    if (juegoFiltroDTO.GeneroId != 0) 
        //    {
        //        juegoQueryable = juegoQueryable.Where(p => p.Generos
        //                                        .Select(g => g.GeneroId)
        //                                        .Contains(juegoFiltroDTO.GeneroId));
        //    }
        //    if (juegoFiltroDTO.ConsolaId != 0)
        //    {
        //        juegoQueryable = juegoQueryable.Where(p => p.JuegoConsola
        //                                        .Select(g => g.ConsolaId)
        //                                        .Contains(juegoFiltroDTO.ConsolaId));
        //    }
        //    if (juegoFiltroDTO.DesarrolladoraId != 0)
        //    {
        //        juegoQueryable = juegoQueryable.Where(p => p.Desarrolladora.DesarrolladorId == juegoFiltroDTO.DesarrolladoraId);
                                                
        //    }
        //    if (juegoFiltroDTO.PublicadoraId != 0)
        //    {
        //        juegoQueryable = juegoQueryable.Where(p => p.Publicadora.PublicadoraId == juegoFiltroDTO.PublicadoraId);
        //    }
        //    if (juegoFiltroDTO.ModoDeJuegoId != 0)
        //    {
        //        juegoQueryable = juegoQueryable.Where(p => p.ModosDeJuegos
        //                                        .Select(g => g.ModosDeJuegoId)
        //                                        .Contains(juegoFiltroDTO.ModoDeJuegoId));
        //    }

        //    var juegos = await juegoQueryable.Include(j=>j.Generos)
        //                                     .Include(j=>j.Desarrolladora)
        //                                     .Include(j=>j.Publicadora).ToListAsync();

        //    return View(juegos);
        //}
        public IActionResult Create()
        {
            ViewData["Generos"] = new SelectList(context.Generos, "GeneroId", "Nombre");
            ViewData["Consolas"] = new SelectList(context.Consolas, "ConsolaId", "ConsolaName");
            ViewData["Desarrollador"] = new SelectList(context.Desarrolladores, "DesarrolladorId", "DesarrolladorName");
            ViewData["Publicadora"] = new SelectList(context.Publicadoras, "PublicadoraId", "PublicadoraNombre");
            ViewData["ModoJuegos"] = new SelectList(context.ModosDeJuegos, "ModosDeJuegoId", "ModosDeJuegoName");


            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(JuegoCreacionDTO juegoDTO)
        {

            if (!ModelState.IsValid)
            {
                var jueguito = mapper.Map<Juego>(juegoDTO);
                jueguito.Generos.ForEach(g => context.Entry(g).State = EntityState.Unchanged);
                //jueguito.Desarrolladora(d => context.Entry(d).State = EntityState.Unchanged);
                if (juegoDTO.JuegosConsolaDTO is not null)
                {
                    List<JuegoConsola> jconsola = new List<JuegoConsola>();

                    for (int i = 0; i < juegoDTO.JuegosConsolaDTO.Count; i++)
                    {
                        jconsola.Add(new JuegoConsola());
                        jconsola[jconsola.Count - 1] = mapper.Map<JuegoConsola>(juegoDTO.JuegosConsolaDTO[i]);
                    }
                    jueguito.JuegoConsola = jconsola;
                }
                context.Add(jueguito);
                await context.SaveChangesAsync();

                return RedirectToAction("Index");
            }
         
            return View();
        }


    }
}
