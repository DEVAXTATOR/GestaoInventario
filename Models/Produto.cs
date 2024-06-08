using System.ComponentModel.DataAnnotations;

namespace GestaoInventario.Models
{
    public class Produto
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public decimal Preco { get; set; }

        [Required]
        public int Quantidade { get; set; }

        [Required]
        public int StockMinimo { get; set; }

        public string Descricao { get; set; }

        [Required]
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
    }
}
