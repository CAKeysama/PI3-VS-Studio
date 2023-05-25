using Microsoft.AspNetCore.Mvc;

namespace PI3.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
