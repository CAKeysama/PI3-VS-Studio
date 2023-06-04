using Microsoft.AspNetCore.Mvc;
using PI3.Entidades;
using PI3.Models;
using Microsoft.EntityFrameworkCore;


namespace PI3.Controllers
{
    public class UsuarioController : Controller
    {
        private Contexto db;
        public UsuarioController(Contexto contexto)
        {
            db = contexto;
        }


        public IActionResult Cadastro()
        {
            UsuarioViewModel model = new UsuarioViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult SalvarDados(Usuario dados)
        {
            db.USUARIO.Add(dados);
            db.SaveChanges();
            return RedirectToAction("Usuario", "Usuario");
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Usuario()
        {
            return View();
        }
    }
}