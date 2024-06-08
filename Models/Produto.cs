using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoInventario.Models
{
    public class Produto
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Preco { get; set; }

        [Required]
        public int Quantidade { get; set; }

        [Required]
        [Display(Name = "Categoria")]
        public int CategoriaId { get; set; }

        [ForeignKey("CategoriaId")]
        public virtual Categoria Categoria { get; set; }

        [Required]
        [Display(Name = "Stock Mínimo")]
        public int StockMinimo { get; set; }

        [Required]
        public string Descricao { get; set; }
    }
}
