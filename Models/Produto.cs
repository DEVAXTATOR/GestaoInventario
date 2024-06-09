namespace GestaoInventario.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }
        public int CategoriaId { get; set; }
        public int StockMinimo { get; set; }
        public string Descricao { get; set; }

        public Categoria Categoria { get; set; }
    }
}