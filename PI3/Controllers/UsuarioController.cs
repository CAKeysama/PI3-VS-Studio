using Microsoft.AspNetCore.Mvc;
using PI3.Entidades;
using PI3.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;

namespace PI3.Controllers
{

    public class UsuarioController : Controller
    {
        private Contexto db;
        public UsuarioController(Contexto contexto)
        {
            db = contexto;
        }
 

        public IActionResult Login(string ReturnUrl)
        {

            if (string.IsNullOrEmpty(ReturnUrl))
            {
                ReturnUrl = "/";
            }

            TempData["ReturnUrl"] = ReturnUrl;
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Login(string email, string senha, string ReturnUrl)
        {
            var usuario = db.USUARIO.FirstOrDefault(u => u.EMAIL == email && u.SENHA == senha);
            if (usuario != null )
            {
                List<Claim> claims = new List<Claim>();

                claims.Add(new Claim(ClaimTypes.Name, usuario.NOME));
                claims.Add(new Claim(ClaimTypes.Role, "Administrador"));
                claims.Add(new Claim(ClaimTypes.Sid, usuario.Id.ToString()));

                var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = true,
                };

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);

                if (string.IsNullOrEmpty(ReturnUrl))
                {
                    ReturnUrl = "/";
                }

                return Redirect(ReturnUrl);

            }
            else
            {
                ModelState.AddModelError(string.Empty, "Email ou senha invalidos");
                return View("Login");
            }
        }

        public async Task<IActionResult> LogOff()
        {

            await HttpContext.SignOutAsync(
                CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Login");
        }

        [Authorize]
        public IActionResult Usuario()
        {
            int UsuarioId = int.Parse(User.FindFirstValue(ClaimTypes.Sid));
            PetsViewModel model = new PetsViewModel();
            model.ListaPets = db.PETS.Where(a => a.UsuarioId == UsuarioId).ToList();
            model.Usuario = db.USUARIO.Find(UsuarioId);


            return View(model);
        }
        public IActionResult Cadastro()
        {
            
            UsuarioViewModel model = new UsuarioViewModel();
            return View(model);
        }


        [HttpPost]
        public IActionResult SalvarDados(Usuario dados)
        {
            if (!ModelState.IsValid)
                ViewData["message"] = "Informações Faltando!";

            return View("Cadastro");

            db.USUARIO.Add(dados);
            db.SaveChanges();
            return RedirectToAction("Usuario", "Usuario");
        }
    }
}