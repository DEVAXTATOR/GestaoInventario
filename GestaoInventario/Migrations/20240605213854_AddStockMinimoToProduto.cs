using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestaoInventario.Migrations
{
    /// <inheritdoc />
    public partial class AddStockMinimoToProduto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EstoqueMinimo",
                table: "Produtos",
                newName: "StockMinimo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StockMinimo",
                table: "Produtos",
                newName: "EstoqueMinimo");
        }
    }
}
