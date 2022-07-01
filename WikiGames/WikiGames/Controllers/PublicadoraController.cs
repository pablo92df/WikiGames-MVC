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
                return RedirectToAction("NoEncontrado", "Home");
            }

            var publicadoraViewModel = mapper.Map<PublicadoraEditViewModel>(publicadora);

            return View(publicadoraViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(PublicadoraEditViewModel publicadoraEdit, int PublicadoraId)
        {
            if (!ModelState.IsValid)
            {
                return View(publicadoraEdit);
            }
            var publicador = await iCRUD.GetByID<Publicadora>(PublicadoraId);

            if (publicador is null) 
            {
                return RedirectToAction("NoEncontrado", "Home");
            }


            publicador = mapper.Map<Publicadora>(publicadoraEdit);

            await iCRUD.Update(publicador);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id) 
        {
            var publicador = await iCRUD.GetByID<Publicadora>(id);
            if (publicador is null)
            {
                return RedirectToAction("NoEncontrado", "Home");
            }

            return View(publicador);
        }
        [HttpPost]
        public async Task<IActionResult> DeletePublicadora(int PublicadoraId)
        {
            var publicador = await iCRUD.GetByID<Publicadora>(PublicadoraId);
            if (publicador is null)
            {
                return RedirectToAction("NoEncontrado", "Home");
            }

            await iCRUD.Delete<Publicadora>(publicador);
            return RedirectToAction("Index");
        }
    }
}
