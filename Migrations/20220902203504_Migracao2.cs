using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Fase2.Migrations
{
    public partial class Migracao2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "valor",
                table: "Estoques",
                newName: "Valor");

            migrationBuilder.RenameColumn(
                name: "quantidade",
                table: "Estoques",
                newName: "Quantidade");

            migrationBuilder.CreateTable(
                name: "Listas",
                columns: table => new
                {
                    IdLista = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeLista = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Listas", x => x.IdLista);
                });

            migrationBuilder.CreateTable(
                name: "ProdutosLista",
                columns: table => new
                {
                    IdProdutoLista = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ListaId = table.Column<int>(type: "int", nullable: false),
                    ProdutoId = table.Column<int>(type: "int", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdutosLista", x => x.IdProdutoLista);
                    table.ForeignKey(
                        name: "FK_ProdutosLista_Listas_ListaId",
                        column: x => x.ListaId,
                        principalTable: "Listas",
                        principalColumn: "IdLista",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProdutosLista_Produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produtos",
                        principalColumn: "IdProduto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProdutosLista_ListaId",
                table: "ProdutosLista",
                column: "ListaId");

            migrationBuilder.CreateIndex(
                name: "IX_ProdutosLista_ProdutoId",
                table: "ProdutosLista",
                column: "ProdutoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProdutosLista");

            migrationBuilder.DropTable(
                name: "Listas");

            migrationBuilder.RenameColumn(
                name: "Valor",
                table: "Estoques",
                newName: "valor");

            migrationBuilder.RenameColumn(
                name: "Quantidade",
                table: "Estoques",
                newName: "quantidade");
        }
    }
}
