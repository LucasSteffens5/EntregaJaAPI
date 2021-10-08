using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace EntregaJaAPI.Migrations
{
    public partial class CriandoTabelas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    IdProduto = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    Descricao = table.Column<string>(type: "text", nullable: true),
                    Preco = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.IdProduto);
                });

            migrationBuilder.CreateTable(
                name: "Vendas",
                columns: table => new
                {
                    IdVenda = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Cep = table.Column<string>(type: "text", nullable: false),
                    DataHoraVenda = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DataHoraCancelamentoVenda = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ValorFrete = table.Column<decimal>(type: "numeric", nullable: false),
                    ValorTotalVenda = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendas", x => x.IdVenda);
                });

            migrationBuilder.CreateTable(
                name: "ProdutosNaVenda",
                columns: table => new
                {
                    IdProdutoNaVenda = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdProduto = table.Column<int>(type: "integer", nullable: false),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    Descricao = table.Column<string>(type: "text", nullable: true),
                    Preco = table.Column<decimal>(type: "numeric", nullable: false),
                    Quantidade = table.Column<int>(type: "integer", nullable: false),
                    VendaIdVenda = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdutosNaVenda", x => x.IdProdutoNaVenda);
                    table.ForeignKey(
                        name: "FK_ProdutosNaVenda_Vendas_VendaIdVenda",
                        column: x => x.VendaIdVenda,
                        principalTable: "Vendas",
                        principalColumn: "IdVenda",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProdutosNaVenda_VendaIdVenda",
                table: "ProdutosNaVenda",
                column: "VendaIdVenda");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produto");

            migrationBuilder.DropTable(
                name: "ProdutosNaVenda");

            migrationBuilder.DropTable(
                name: "Vendas");
        }
    }
}
