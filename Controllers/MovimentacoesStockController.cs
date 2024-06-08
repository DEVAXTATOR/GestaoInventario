using Microsoft.AspNetCore.Mvc;
using GestaoInventario.Data;
using GestaoInventario.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

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
            var movimentacoes = _context.MovimentacoesStock.Include(m => m.Produto).ToList();
            return View(movimentacoes);
        }

        public IActionResult Create()
        {
            ViewData["ProdutoId"] = new SelectList(_context.Produtos, "Id", "Nome");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,ProdutoId,Quantidade,Data")] MovimentacaoStock movimentacao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movimentacao);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProdutoId"] = new SelectList(_context.Produtos, "Id", "Nome", movimentacao.ProdutoId);
            return View(movimentacao);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movimentacao = _context.MovimentacoesStock.Find(id);
            if (movimentacao == null)
            {
                return NotFound();
            }
            ViewData["ProdutoId"] = new SelectList(_context.Produtos, "Id", "Nome", movimentacao.ProdutoId);
            return View(movimentacao);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,ProdutoId,Quantidade,Data")] MovimentacaoStock movimentacao)
        {
            if (id != movimentacao.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movimentacao);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovimentacaoStockExists(movimentacao.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProdutoId"] = new SelectList(_context.Produtos, "Id", "Nome", movimentacao.ProdutoId);
            return View(movimentacao);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movimentacao = _context.MovimentacoesStock
                .Include(m => m.Produto)
                .FirstOrDefault(m => m.Id == id);
            if (movimentacao == null)
            {
                return NotFound();
            }

            return View(movimentacao);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var movimentacao = _context.MovimentacoesStock.Find(id);
            _context.MovimentacoesStock.Remove(movimentacao);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movimentacao = _context.MovimentacoesStock
                .Include(m => m.Produto)
                .FirstOrDefault(m => m.Id == id);
            if (movimentacao == null)
            {
                return NotFound();
            }

            return View(movimentacao);
        }

        private bool MovimentacaoStockExists(int id)
        {
            return _context.MovimentacoesStock.Any(e => e.Id == id);
        }
    }
}
