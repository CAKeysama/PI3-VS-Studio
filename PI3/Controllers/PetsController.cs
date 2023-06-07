    using Microsoft.AspNetCore.Mvc;
using PI3.Entidades;
using PI3.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace PI3.Controllers
{
    public class PetsController : Controller
    {
        private string path;
        private Contexto db;
        public PetsController(Contexto contexto, IWebHostEnvironment _path)
        {
            db = contexto;
            path = _path.WebRootPath+"\\upload\\";
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
        public async Task<IActionResult> SalvarDados(Pets dados, IFormFile Imagem)
        {
            int UsuarioId = int.Parse(User.FindFirstValue(ClaimTypes.Sid));
            dados.UsuarioId = UsuarioId;
            if(Imagem.Length > 0) 
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                using (var stream = System.IO.File.Create(path+Imagem.FileName))
                {
                    await Imagem.CopyToAsync(stream);
                }
                dados.CaminhoImagem = Imagem.FileName;
            }
            else
            {
                dados.CaminhoImagem = "";
            }
            

            db.PETS.Add(dados);
            db.SaveChanges();
            return RedirectToAction("Usuario", "Usuario");
        }


    }
}
