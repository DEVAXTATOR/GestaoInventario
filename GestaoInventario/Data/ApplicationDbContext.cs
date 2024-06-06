using GestaoInventario.Models;
using Microsoft.EntityFrameworkCore;

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Dados de semente para Categoria
            modelBuilder.Entity<Categoria>().HasData(
                new Categoria { Id = 1, Nome = "Eletrónicos" },
                new Categoria { Id = 2, Nome = "Móveis" }
            );

            // Dados de semente para Produto
            modelBuilder.Entity<Produto>().HasData(
                new Produto { Id = 1, Nome = "Computador", CategoriaId = 1, Quantidade = 10, Preco = 1500.00 },
                new Produto { Id = 2, Nome = "Cadeira", CategoriaId = 2, Quantidade = 50, Preco = 85.00 }
            );
        }
    }
}
