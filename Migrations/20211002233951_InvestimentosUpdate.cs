using Microsoft.EntityFrameworkCore.Migrations;

namespace CInvestimentos.Migrations
{
    public partial class InvestimentosUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AcaoId",
                table: "Vendas");

            migrationBuilder.DropColumn(
                name: "InvestidorId",
                table: "Vendas");

            migrationBuilder.AddColumn<int>(
                name: "InvestimentoId",
                table: "Vendas",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InvestimentoId",
                table: "Vendas");

            migrationBuilder.AddColumn<int>(
                name: "AcaoId",
                table: "Vendas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "InvestidorId",
                table: "Vendas",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
