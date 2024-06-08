using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestaoInventario.Migrations
{
    /// <inheritdoc />
    public partial class AtualizacaoMovimentacaoStock : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsEntrada",
                table: "MovimentacoesStock");

            migrationBuilder.AddColumn<string>(
                name: "Tipo",
                table: "MovimentacoesStock",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tipo",
                table: "MovimentacoesStock");

            migrationBuilder.AddColumn<bool>(
                name: "IsEntrada",
                table: "MovimentacoesStock",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
