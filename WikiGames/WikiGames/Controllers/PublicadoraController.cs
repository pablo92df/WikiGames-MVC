using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WikiGames.Data;
using WikiGames.Models.Entities;
using WikiGames.Services.RepositoriesInterface;

namespace WikiGames.Controllers
{
    public class PublicadoraController : Controller
    {

        private readonly ICRUD iCRUD;
        private readonly IPublicadoraRepository publicadoraRepository;

        public PublicadoraController( ICRUD iCRUD, IPublicadoraRepository publicadoraRepository)
        {

            this.iCRUD = iCRUD;
            this.publicadoraRepository = publicadoraRepository;
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
    }
}
