using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WikiGames.Data;
using WikiGames.Models.ViewModel;
using WikiGames.Models.Entities;
using WikiGames.Services.RepositoriesInterface;

namespace WikiGames.Controllers
{
    public class MarcaController : Controller
    {
       
        private readonly IMapper mapper;
        private readonly IMarcaRepository marcaRepository;

        public MarcaController(IMapper mapper, IMarcaRepository marcaRepository)
        {
            this.mapper = mapper;
            this.marcaRepository = marcaRepository;
        }
        public async Task<IActionResult> Index()
        {
            var marca = await marcaRepository.GetAll();
            var marcas = mapper.Map<MarcaViewModel>(marca);
            return View(marcas);
        }

        public IActionResult Create()
        { 
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(MarcaCreacionViewModel marcaViewModel)
        {

            if (!ModelState.IsValid) 
            {
                return View(marcaViewModel);
            }
            Marca marca = new Marca()
            {
                MarcaName = marcaViewModel.MarcaName,
            };
            await marcaRepository.Create(marca);
            TempData["mensaje"] = "Marca Cargada con exito";
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id, MarcaViewModel marcaViewModel) 
        {
            var marca = await marcaRepository.GetById(id);
            if (marca is null)
            {
                return RedirectToAction("NoEncontrado", "Home");
            }
            if (id != marcaViewModel.MarcaId) 
            {
                return RedirectToAction("NoEncontrado", "Home");
            }

            await marcaRepository.Delete(marca);
            TempData["mensaje"] = "Marca Cargada con exito";
            return RedirectToAction("Index");
        }
    }
}
