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
 

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Login(string email, string senha)
        {
            var usuario = db.USUARIO.FirstOrDefault(u => u.EMAIL == email && u.SENHA == senha);
            if (usuario != null )
            {
                return RedirectToAction("Usuario", "Usuario");

            }
            else
            {
                ModelState.AddModelError(string.Empty, "Email ou senha invalidos");
                return View("Login");
            }
        }

        public IActionResult Usuario()
        {
            return View();
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
    }
}