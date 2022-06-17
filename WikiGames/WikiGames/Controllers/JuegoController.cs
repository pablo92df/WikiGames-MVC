using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WikiGames.Data;
using WikiGames.Models.ViewModel.JuegoViewModel;
using WikiGames.Models.Entities;
using WikiGames.Models.ViewModel.JuegViewModel;
using WikiGames.Services.RepositoriesInterface;

namespace WikiGames.Controllers
{
    public class JuegoController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        private readonly IJuegoRepository juegoRepository;
        private readonly IGeneroRepository generoRepository;
        private readonly IDesarrolladorRepository desarrolladorRepository;

        public JuegoController(ApplicationDbContext context,
            IMapper mapper,
            IJuegoRepository juegoRepository,
            IGeneroRepository generoRepository,
            IDesarrolladorRepository desarrolladorRepository)
        {
            this.context = context;
            this.mapper = mapper;
            this.juegoRepository = juegoRepository;
            this.generoRepository = generoRepository;
            this.desarrolladorRepository = desarrolladorRepository;
        }
        [HttpGet]
        public async Task<IActionResult> Index(string juegoName, int GeneroId, int ConsolaId, int DesarrolladoraId, int ModoDeJuegoId)
        {

            ViewBag.Desarrolladores = new SelectList(context.Desarrolladores.OrderBy(x => x.DesarrolladorName), "DesarrolladorId", "DesarrolladorName");
            ViewBag.Generos = new SelectList(context.Generos.OrderBy(x => x.Nombre), "GeneroId", "Nombre");
            ViewBag.Consolas = new SelectList(context.Consolas.OrderBy(c => c.ConsolaName), "ConsolaId", "ConsolaName");
            ViewBag.ModoJuegos = new SelectList(context.ModosDeJuegos.OrderBy(m => m.ModosDeJuegoName), "ModosDeJuegoId", "ModosDeJuegoName");

            var juegos = await juegoRepository.GetAll(juegoName, GeneroId, ConsolaId, DesarrolladoraId, ModoDeJuegoId);
            var juegosViewModel = mapper.Map<List<JuegosViewModel>>(juegos);

            return View(juegosViewModel);
        }
        public async Task<IActionResult> AllInfo(int id) 
        {
          
            var juego = await juegoRepository.GetById(id);

            var juegosViewModel = mapper.Map<JuegoAllInfoViewModel>(juego);
            return View(juegosViewModel);
        }

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
        public async Task<IActionResult> CreateJuego(JuegoCreacionViewModel juegoViewModel)
        {

            if (!ModelState.IsValid)
            {
                return View(juegoViewModel);
            }
            foreach (var i in juegoViewModel.Generos) 
            {
                var genero = generoRepository.GetById(i.GeneroId);
                if (genero is null) 
                {
                    return View(juegoViewModel);
                }
            }
            var desarrollador = desarrolladorRepository.GetById(juegoViewModel.DesarrolladoraId);
            if (desarrollador is null) 
            {
                return View(desarrollador);
            }
            Juego juego = mapper.Map<Juego>(juegoViewModel);
           
            await juegoRepository.Create(juego);

            // jueguito.Generos.ForEach(g => context.Entry(g).State = EntityState.Unchanged);
            //if (juegoDTO.JuegosConsolaDTO is not null)
            //{
            //    List<JuegoConsola> jconsola = new List<JuegoConsola>();

            //    for (int i = 0; i < juegoDTO.JuegosConsolaDTO.Count; i++)
            //    {
            //        jconsola.Add(new JuegoConsola());
            //        jconsola[jconsola.Count - 1] = mapper.Map<JuegoConsola>(juegoDTO.JuegosConsolaDTO[i]);
            //    }
            //    jueguito.JuegoConsola = jconsola;
            //}
   
        

            return RedirectToAction("Index");
            
        }

        [HttpPost]
        public async Task<IActionResult> CreateJuegoPersonajes(JuegoCreacionViewModel juegoDTO)
        {

            if (ModelState.IsValid)
            {

                var jueguito = mapper.Map<Juego>(juegoDTO);
                jueguito.Generos.ForEach(g => context.Entry(g).State = EntityState.Unchanged);
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
                context.Juegos.Add(jueguito);
                await context.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return View();
        }

    }
}
