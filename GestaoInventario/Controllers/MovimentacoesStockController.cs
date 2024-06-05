using System.Linq;
using Microsoft.AspNetCore.Mvc;
using GestaoInventario.Data;
using GestaoInventario.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace GestaoInventario.Controllers
{
    public class MovimentacoesStockController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MovimentacoesStockController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var movimentacoesStock = _context.MovimentacoesStock
                .Include(m => m.Produto) // Certifique-se de incluir o Produto
                .ToList();
            return View(movimentacoesStock);
        }

        public IActionResult Create()
        {
            ViewBag.Produtos = new SelectList(_context.Produtos, "Id", "Nome");
            return View();
        }

        [HttpPost]
        public IActionResult Create(MovimentacaoStock movimentacaoStock)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movimentacaoStock);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Produtos = new SelectList(_context.Produtos, "Id", "Nome", movimentacaoStock.ProdutoId);
            return View(movimentacaoStock);
        }
    }
}
