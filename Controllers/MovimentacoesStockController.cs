using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GestaoInventario.Data;
using GestaoInventario.Models;
using System.Linq;
using System.Threading.Tasks;
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

        // GET: MovimentacoesStock
        public async Task<IActionResult> Index()
        {
            var movimentacoes = _context.MovimentacoesStock.Include(m => m.Produto);
            return View(await movimentacoes.ToListAsync());
        }

        // GET: MovimentacoesStock/Create
        public IActionResult Create()
        {
            var produtos = _context.Produtos.ToList();
            if (!produtos.Any())
            {
                ViewBag.ProdutosMessage = "Nenhum produto disponível.";
            }
            else
            {
                ViewBag.Produtos = produtos;
                ViewBag.ProdutoId = new SelectList(produtos, "Id", "Nome");
            }
            return View();
        }

        // POST: MovimentacoesStock/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProdutoId,Quantidade,Data,IsEntrada")] MovimentacaoStock movimentacaoStock)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movimentacaoStock);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            var produtos = _context.Produtos.ToList();
            if (!produtos.Any())
            {
                ViewBag.ProdutosMessage = "Nenhum produto disponível.";
            }
            else
            {
                ViewBag.Produtos = produtos;
                ViewBag.ProdutoId = new SelectList(produtos, "Id", "Nome", movimentacaoStock.ProdutoId);
            }
            return View(movimentacaoStock);
        }

        // GET: MovimentacoesStock/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movimentacaoStock = await _context.MovimentacoesStock.FindAsync(id);
            if (movimentacaoStock == null)
            {
                return NotFound();
            }
            ViewBag.ProdutoId = new SelectList(_context.Produtos, "Id", "Nome", movimentacaoStock.ProdutoId);
            return View(movimentacaoStock);
        }

        // POST: MovimentacoesStock/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProdutoId,Quantidade,Data,IsEntrada")] MovimentacaoStock movimentacaoStock)
        {
            if (id != movimentacaoStock.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movimentacaoStock);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovimentacaoStockExists(movimentacaoStock.Id))
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
            ViewBag.ProdutoId = new SelectList(_context.Produtos, "Id", "Nome", movimentacaoStock.ProdutoId);
            return View(movimentacaoStock);
        }

        // GET: MovimentacoesStock/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movimentacaoStock = await _context.MovimentacoesStock
                .Include(m => m.Produto)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movimentacaoStock == null)
            {
                return NotFound();
            }

            return View(movimentacaoStock);
        }

        // GET: MovimentacoesStock/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movimentacaoStock = await _context.MovimentacoesStock
                .Include(m => m.Produto)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movimentacaoStock == null)
            {
                return NotFound();
            }

            return View(movimentacaoStock);
        }

        // POST: MovimentacoesStock/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movimentacaoStock = await _context.MovimentacoesStock.FindAsync(id);
            _context.MovimentacoesStock.Remove(movimentacaoStock);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovimentacaoStockExists(int id)
        {
            return _context.MovimentacoesStock.Any(e => e.Id == id);
        }
    }
}
