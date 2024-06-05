using System.ComponentModel.DataAnnotations;

namespace GestaoInventario.Models
{
    public class Produto
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; } = string.Empty;

        [Required]
        public int CategoriaId { get; set; }  // ID da Categoria para FK

        [Range(0, int.MaxValue)]
        public int Quantidade { get; set; }

        [Range(0.0, double.MaxValue)]
        public double Preco { get; set; }

        public Categoria Categoria { get; set; } // Relação com a tabela Categoria

        [Range(0, int.MaxValue)]
        public int StockMinimo { get; set; } // Novo campo para o stock mínimo
    }
}
