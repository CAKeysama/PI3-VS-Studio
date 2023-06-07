    using Microsoft.AspNetCore.Mvc;
using PI3.Entidades;
using PI3.Models;
using Microsoft.EntityFrameworkCore;

namespace PI3.Controllers
{
    public class PetsController : Controller
    {

        private Contexto db;
        public PetsController(Contexto contexto)
        {
            db = contexto;
        }

        public IActionResult Pets()
        {
            return View();
        }

        
        public IActionResult Cadastro()
        {
            PetsViewModel model = new PetsViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult SalvarDados(Pets dados)
        {
            db.PETS.Add(dados);
            db.SaveChanges();
            return RedirectToAction("Usuario", "Usuario");
        }


    }
}
