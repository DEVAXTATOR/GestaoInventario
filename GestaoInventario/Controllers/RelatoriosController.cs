using System.Linq;
using Microsoft.AspNetCore.Mvc;
using GestaoInventario.Data;
using GestaoInventario.Models;
using Microsoft.EntityFrameworkCore;

namespace GestaoInventario.Controllers
{
    public class RelatoriosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RelatoriosController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var movimentacoes = _context.MovimentacoesStock
                .Include(m => m.Produto)
                .ToList();

            return View(movimentacoes);
        }
    }
}
