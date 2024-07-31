using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace api_project_net5.Migrations
{
    public partial class CreateClientesSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    CNPJ = table.Column<string>(type: "character varying(14)", maxLength: 14, nullable: false),
                    Endereco = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Telefone = table.Column<string>(type: "character varying(13)", maxLength: 13, nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                    table.CheckConstraint("CK_CNPJ_Length", "LENGTH(\"CNPJ\") = 14");
                    table.CheckConstraint("CK_Telefone_Length", "LENGTH(\"Telefone\") = 13");
                });

            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "Id", "CNPJ", "DataCadastro", "Endereco", "Nome", "Telefone" },
                values: new object[,]
                {
                    { 1, "12345678901234", new DateTime(2024, 7, 30, 23, 28, 6, 375, DateTimeKind.Local).AddTicks(8915), "Rua 1, 123", "Empresa 1", "5548912345678" },
                    { 2, "43210987654321", new DateTime(2024, 7, 30, 23, 28, 6, 376, DateTimeKind.Local).AddTicks(4976), "Rua 2, 123", "Empresa 2", "5548987654321" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_CNPJ",
                table: "Clientes",
                column: "CNPJ",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
