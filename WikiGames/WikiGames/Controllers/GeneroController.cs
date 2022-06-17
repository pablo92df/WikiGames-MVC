using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WikiGames.Data;
using WikiGames.Models.ViewModel;
using WikiGames.Models.Entities;
using WikiGames.Services.RepositoriesInterface;
using WikiGames.Services.Repositories;
using AutoMapper;

namespace WikiGames.Controllers
{
    public class GeneroController : Controller
    {


        private readonly IGeneroRepository generoRepository;
        private readonly IMapper mapper;

        public GeneroController(IGeneroRepository generoRepository, IMapper mapper)
        {
 ;
            this.generoRepository = generoRepository;
            this.mapper = mapper;
        }
        public async  Task<IActionResult> Index()
        {
            var gen = await generoRepository.GetAll();
            var generos = mapper.Map<GeneroViewModel>(gen);

            return View(generos);
        }
        public IActionResult Create()
        { 
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(GeneroViewModel generoViewModel) 
        {
            if(!ModelState.IsValid)
            {
                return View(generoViewModel);

            }
            var genero = mapper.Map<Genero>(generoViewModel);

            await generoRepository.Create(genero);
            TempData["mensaje"] = "Genero Cargado con exito";
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            Genero gen = await generoRepository.GetById(id);

            if (gen is null)
            {
                return RedirectToAction("NoEncontrado","Home");
            }
            return View("Index");
        }


        [HttpPost]
        public async Task<IActionResult> Edit(GeneroViewModel generoViewModel, int GeneroId)
        {
            if (generoViewModel.GeneroId != GeneroId) 
            {
                return RedirectToAction("NoEncontrado","Home");
            }
            Genero gen = await generoRepository.GetById(GeneroId);

            if (gen is null) 
            {
                return RedirectToAction("NoEncontrado", "Home");
            }

            gen = mapper.Map<Genero>(generoViewModel);
            
            await generoRepository.Update(gen);
            TempData["mensaje"] = "Genero actualizado Exitosamente";

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int idGenero)
        {
            var genero = generoRepository.GetById(idGenero);

            if (genero is null) 
            {
                return RedirectToAction("NoEncontrado","Home");
            }

            await generoRepository.Delete(idGenero);

            return RedirectToAction("Index");
        }
    }
}
