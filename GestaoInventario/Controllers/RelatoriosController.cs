using Microsoft.AspNetCore.Mvc;
using GestaoInventario.Data;
using GestaoInventario.Models;
using System.Collections.Generic;
using System.Linq;

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
            return View();
        }

        public IActionResult Detalhes(int id)
        {
            var model = new RelatorioViewModel();

            switch (id)
            {
                case 1:
                    model.Titulo = "Relatório de Vendas";
                    model.Cabecalhos = new List<string> { "Produto", "Quantidade Vendida", "Data" };
                    model.Linhas = _context.Vendas
                        .Select(v => new List<string> { v.Produto.Nome, v.Quantidade.ToString(), v.Data.ToShortDateString() })
                        .ToList();
                    break;
                case 2:
                    model.Titulo = "Relatório de Stock";
                    model.Cabecalhos = new List<string> { "Produto", "Quantidade em Stock" };
                    model.Linhas = _context.Produtos
                        .Select(p => new List<string> { p.Nome, p.Quantidade.ToString() })
                        .ToList();
                    break;
                case 3:
                    model.Titulo = "Relatório de Compras";
                    model.Cabecalhos = new List<string> { "Produto", "Quantidade Comprada", "Data" };
                    model.Linhas = _context.Compras
                        .Select(c => new List<string> { c.Produto.Nome, c.Quantidade.ToString(), c.Data.ToShortDateString() })
                        .ToList();
                    break;
                default:
                    return NotFound();
            }

            return View(model);
        }
    }
}
