using Microsoft.AspNetCore.Mvc;

namespace GestaoInventario.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
