using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PI3.Models;
using System.Diagnostics;

namespace PI3.Controllers
{
    
    public class HomeController : Controller
    {

        private string path;
        private Contexto db;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        
        public IActionResult Index()
        {
            return View();
        }
       
        public IActionResult Sobre()
        {
            return View();
        }
        
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        public IActionResult Lista(string busca) 
        {
            if(string.IsNullOrEmpty(busca) )
            {
                return View(db.PETS.ToList());
            }
            else
            {
                return View(db.PETS.Where(meuObjeto => meuObjeto.NOME.Contains(busca)).ToList());
            }
        }

    }
}