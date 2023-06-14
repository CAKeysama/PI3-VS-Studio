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
            PetsViewModel model = new PetsViewModel();
            model.ListaPets = db.PETS.ToList();
            return View(model);
        }

        public ActionResult Excluir(int id) 
        {
            Pets item = db.PETS.Find(id);
            if(item != null) 
            {
                db.PETS.Remove(item);
                db.SaveChanges();
            }
            return Redirect("/Usuario/Usuario");
        }
        
        public IActionResult Editar(int id) 
        {
            Pets item = db.PETS.Find(id);
            if(item != null) 
            {
                return View(item);
            }
            else 
            {
                return Redirect("/Pets/Editar");
            }
        }


        public IActionResult Cadastro()
        {
            PetsViewModel model = new PetsViewModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> SalvarDados(Pets dados, IFormFile Imagem)
        {
            if(dados.Id > 0)
            {
                if (Imagem != null)
                {
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    using (var stream = System.IO.File.Create(path + Imagem.FileName))
                    {
                        await Imagem.CopyToAsync(stream);
                    }
                    dados.CaminhoImagem = Imagem.FileName;
                }



                db.PETS.Update(dados);
                db.SaveChanges();
            
            }
            else
            {
                int UsuarioId = int.Parse(User.FindFirstValue(ClaimTypes.Sid));
                dados.UsuarioId = UsuarioId;
                if (Imagem != null)
                {
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    using (var stream = System.IO.File.Create(path + Imagem.FileName))
                    {
                        await Imagem.CopyToAsync(stream);
                    }
                    dados.CaminhoImagem = Imagem.FileName;
                }



                db.PETS.Add(dados);
                db.SaveChanges();
               
            }
            return RedirectToAction("Usuario", "Usuario");

        }


    }
}
