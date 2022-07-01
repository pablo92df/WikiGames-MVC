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
        private readonly ICRUD icrud;

        public MarcaController(IMapper mapper, IMarcaRepository marcaRepository, ICRUD icrud)
        {
            this.mapper = mapper;
            this.marcaRepository = marcaRepository;
            this.icrud = icrud;
        }
        public async Task<IActionResult> Index()
        {
            var marca = await marcaRepository.GetAll();
            var marcas = mapper.Map<List<MarcaViewModel>>(marca);
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
            await icrud.Create(marca);
            TempData["mensaje"] = "Marca Cargada con exito";
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id, MarcaViewModel marcaViewModel) 
        {
            var marca = await icrud.GetByID<Marca>(id);
            if (marca is null)
            {
                return RedirectToAction("NoEncontrado", "Home");
            }
            if (id != marcaViewModel.MarcaId) 
            {
                return RedirectToAction("NoEncontrado", "Home");
            }

            await icrud.Delete<Marca>(marca);
            TempData["mensaje"] = "Marca Eliminada con exito";
            return RedirectToAction("Index");
        }
    }
}
