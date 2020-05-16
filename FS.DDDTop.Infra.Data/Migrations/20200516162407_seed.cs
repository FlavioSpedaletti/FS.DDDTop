using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FS.DDDTop.Infra.Data.Migrations
{
    public partial class seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "ClienteId", "Ativo", "DataCadastro", "Email", "Nome", "Sobrenome" },
                values: new object[] { 1, true, new DateTime(2020, 5, 16, 13, 24, 7, 270, DateTimeKind.Local).AddTicks(62), "flavio@email.com", "Flavio", "Spedaletti" });

            migrationBuilder.InsertData(
                table: "Reclamacoes",
                columns: new[] { "ReclamacaoId", "ClienteId", "Descricao", "Resolvida" },
                values: new object[] { 1, 1, "Internet lenta", false });

            migrationBuilder.InsertData(
                table: "Reclamacoes",
                columns: new[] { "ReclamacaoId", "ClienteId", "Descricao", "Resolvida" },
                values: new object[] { 2, 1, "Sinal da TV caiu", true });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Reclamacoes",
                keyColumn: "ReclamacaoId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Reclamacoes",
                keyColumn: "ReclamacaoId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "ClienteId",
                keyValue: 1);
        }
    }
}
