using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CInvestimentos.Migrations
{
    public partial class ContextUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Investimento_Acoes_AcaoId",
                table: "Investimento");

            migrationBuilder.DropForeignKey(
                name: "FK_Investimento_Investidores_InvestidorId",
                table: "Investimento");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vendas",
                table: "Vendas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Investimento",
                table: "Investimento");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Investidores",
                table: "Investidores");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Compras",
                table: "Compras");

            migrationBuilder.RenameTable(
                name: "Vendas",
                newName: "Venda");

            migrationBuilder.RenameTable(
                name: "Investimento",
                newName: "Investimentos");

            migrationBuilder.RenameTable(
                name: "Investidores",
                newName: "Investidor");

            migrationBuilder.RenameTable(
                name: "Compras",
                newName: "Compra");

            migrationBuilder.RenameIndex(
                name: "IX_Investimento_InvestidorId",
                table: "Investimentos",
                newName: "IX_Investimentos_InvestidorId");

            migrationBuilder.RenameIndex(
                name: "IX_Investimento_AcaoId",
                table: "Investimentos",
                newName: "IX_Investimentos_AcaoId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Nascimento",
                table: "Investidor",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Venda",
                table: "Venda",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Investimentos",
                table: "Investimentos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Investidor",
                table: "Investidor",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Compra",
                table: "Compra",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Investimentos_Acoes_AcaoId",
                table: "Investimentos",
                column: "AcaoId",
                principalTable: "Acoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Investimentos_Investidor_InvestidorId",
                table: "Investimentos",
                column: "InvestidorId",
                principalTable: "Investidor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Investimentos_Acoes_AcaoId",
                table: "Investimentos");

            migrationBuilder.DropForeignKey(
                name: "FK_Investimentos_Investidor_InvestidorId",
                table: "Investimentos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Venda",
                table: "Venda");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Investimentos",
                table: "Investimentos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Investidor",
                table: "Investidor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Compra",
                table: "Compra");

            migrationBuilder.RenameTable(
                name: "Venda",
                newName: "Vendas");

            migrationBuilder.RenameTable(
                name: "Investimentos",
                newName: "Investimento");

            migrationBuilder.RenameTable(
                name: "Investidor",
                newName: "Investidores");

            migrationBuilder.RenameTable(
                name: "Compra",
                newName: "Compras");

            migrationBuilder.RenameIndex(
                name: "IX_Investimentos_InvestidorId",
                table: "Investimento",
                newName: "IX_Investimento_InvestidorId");

            migrationBuilder.RenameIndex(
                name: "IX_Investimentos_AcaoId",
                table: "Investimento",
                newName: "IX_Investimento_AcaoId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Nascimento",
                table: "Investidores",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vendas",
                table: "Vendas",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Investimento",
                table: "Investimento",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Investidores",
                table: "Investidores",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Compras",
                table: "Compras",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Investimento_Acoes_AcaoId",
                table: "Investimento",
                column: "AcaoId",
                principalTable: "Acoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Investimento_Investidores_InvestidorId",
                table: "Investimento",
                column: "InvestidorId",
                principalTable: "Investidores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
