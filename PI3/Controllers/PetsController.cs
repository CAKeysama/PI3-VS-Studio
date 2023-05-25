using Microsoft.AspNetCore.Mvc;

namespace PI3.Controllers
{
    public class PetsController : Controller
    {
        public IActionResult Lista()
        {
            return View();
        }

    }
}
