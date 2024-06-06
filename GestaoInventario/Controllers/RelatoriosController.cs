using Microsoft.AspNetCore.Mvc;

namespace GestaoInventario.Controllers
{
    public class RelatoriosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Detalhes(int id)
        {
            // Lógica para obter detalhes do relatório pelo id
            return View();
        }
    }
}
