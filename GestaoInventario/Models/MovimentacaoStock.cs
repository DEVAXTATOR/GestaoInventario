using System;
using System.ComponentModel.DataAnnotations;

namespace GestaoInventario.Models
{
    public class MovimentacaoStock
    {
        public int Id { get; set; }

        [Required]
        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int Quantidade { get; set; }

        [Required]
        public bool IsEntrada { get; set; }

        [Required]
        public DateTime Data { get; set; }

        // Propriedade Tipo para exibir o tipo de movimentação
        public string Tipo => IsEntrada ? "Entrada" : "Saída";
    }
}
