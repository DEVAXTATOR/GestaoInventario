using Microsoft.EntityFrameworkCore;
using GestaoInventario.Models;

namespace GestaoInventario.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<MovimentacaoStock> MovimentacoesStock { get; set; }
        public DbSet<Venda> Vendas { get; set; }
        public DbSet<Compra> Compras { get; set; }
    }
}
