using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WikiGames.Data;
using WikiGames.Models.Entities;
using WikiGames.Models.ViewModel.PublicadoraViewModel;
using WikiGames.Services.RepositoriesInterface;

namespace WikiGames.Controllers
{
    public class PublicadoraController : Controller
    {

        private readonly ICRUD iCRUD;
        private readonly IPublicadoraRepository publicadoraRepository;
        private readonly IMapper mapper;

        public PublicadoraController( ICRUD iCRUD, IPublicadoraRepository publicadoraRepository, IMapper mapper)
        {

            this.iCRUD = iCRUD;
            this.publicadoraRepository = publicadoraRepository;
            this.mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var publicadoras = await publicadoraRepository.GetAll();

            return View(publicadoras);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Publicadora publi)
        {
            if (ModelState.IsValid)
            {
                await  iCRUD.Create<Publicadora>(publi);
                TempData["mensaje"] = "Publicadora Cargado con exito";
                return RedirectToAction("Index");
            }

            return View();
        }

        public async Task<IActionResult> Edit(int id)
        {
            var publicadora = await iCRUD.GetByID<Publicadora>(id);

            if (publicadora is null)
            {
                return RedirectToAction("Index");
            }

            var publicadoraViewModel = mapper.Map<PublicadoraEditViewModel>(publicadora);

            return View(publicadoraViewModel);
        }
        //[HttpPost]
        //public async Task<IActionResult> Edit(DesarrolladorEditViewModel desarrolladorEditDTO)
        //{

        //    if (!ModelState.IsValid)
        //    {
        //        return View(desarrolladorEditDTO);
        //    }
           


        //    var desarrollador = mapper.Map<Desarrollador>(desarrolladorEditDTO);

        //    await icrud.Update<Desarrollador>(desarrollador);

        //    return RedirectToAction("Index");
        //}
    }
}
