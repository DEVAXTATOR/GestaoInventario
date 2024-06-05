using Microsoft.AspNetCore.Mvc;
using GestaoInventario.Data;
using GestaoInventario.Models;
using System.Linq;

namespace GestaoInventario.Controllers
{
    public class CategoriasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoriasController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var categorias = _context.Categorias.ToList();
            return View(categorias);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                _context.Add(categoria);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(categoria);
        }
    }
}
