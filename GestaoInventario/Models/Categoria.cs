using System.ComponentModel.DataAnnotations;

namespace GestaoInventario.Models
{
    public class Categoria
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; } = string.Empty;
    }
}
