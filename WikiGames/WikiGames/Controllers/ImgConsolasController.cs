using Microsoft.AspNetCore.Mvc;
using WikiGames.Data;
using System.IO;
using WikiGames.Models.Entities;
using Microsoft.AspNetCore.Hosting;
namespace WikiGames.Controllers
{
    public class ImgConsolasController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IWebHostEnvironment hostingEnvironment;

        public ImgConsolasController(ApplicationDbContext context, IWebHostEnvironment hostingEnvironment)
        {
            this.context = context;
            this.hostingEnvironment = hostingEnvironment;
        }
        public IActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(IFormFile imgConsolas)
        {
            string wwwPath = this.hostingEnvironment.WebRootPath;
           
            string name = Path.GetFileName(imgConsolas.FileName);
            string path = Path.Combine(this.hostingEnvironment.WebRootPath, "Images/IMGConsolas");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            FileStream stream = new FileStream(Path.Combine(path, name), FileMode.Create);
            await imgConsolas.CopyToAsync(stream);
            return RedirectToAction("Index");

        }
    }
}
