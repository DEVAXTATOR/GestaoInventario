using Microsoft.AspNetCore.Mvc;
using GestaoInventario.Data;
using GestaoInventario.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace GestaoInventario.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProdutosController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var produtos = _context.Produtos.ToList();
            return View(produtos);
        }

        public IActionResult Create()
        {
            ViewBag.Categorias = new SelectList(_context.Categorias, "Id", "Nome");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Produto produto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(produto);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Categorias = new SelectList(_context.Categorias, "Id", "Nome", produto.CategoriaId);
            return View(produto);
        }
    }
}
