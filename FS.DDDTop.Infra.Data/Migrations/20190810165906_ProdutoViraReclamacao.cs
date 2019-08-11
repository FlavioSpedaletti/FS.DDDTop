using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FS.DDDTop.Infra.Data.Migrations
{
    public partial class ProdutoViraReclamacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.CreateTable(
                name: "Reclamacoes",
                columns: table => new
                {
                    ReclamacaoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false),
                    Resolvida = table.Column<bool>(nullable: false),
                    ClienteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reclamacoes", x => x.ReclamacaoId);
                    table.ForeignKey(
                        name: "FK_Reclamacoes_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reclamacoes_ClienteId",
                table: "Reclamacoes",
                column: "ClienteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reclamacoes");

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    ProdutoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClienteId = table.Column<int>(nullable: false),
                    Disponivel = table.Column<bool>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.ProdutoId);
                    table.ForeignKey(
                        name: "FK_Produtos_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_ClienteId",
                table: "Produtos",
                column: "ClienteId");
        }
    }
}
