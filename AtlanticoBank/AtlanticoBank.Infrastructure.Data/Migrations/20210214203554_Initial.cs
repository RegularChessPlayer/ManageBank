using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace AtlanticoBank.Infrastructure.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "caixa",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    ativo = table.Column<bool>(type: "boolean", nullable: true, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_caixa", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "estoquecaixa",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    cedula = table.Column<int>(type: "integer", nullable: false),
                    quantidade = table.Column<int>(type: "integer", nullable: false),
                    caixaid = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_estoquecaixa", x => x.id);
                    table.ForeignKey(
                        name: "FK_estoquecaixa_caixa_caixaid",
                        column: x => x.caixaid,
                        principalTable: "caixa",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "caixa",
                columns: new[] { "id", "ativo", "nome" },
                values: new object[,]
                {
                    { 100L, true, "A100" },
                    { 101L, true, "A101" }
                });

            migrationBuilder.InsertData(
                table: "estoquecaixa",
                columns: new[] { "id", "caixaid", "cedula", "quantidade" },
                values: new object[,]
                {
                    { 200L, 100L, 50, 10 },
                    { 201L, 100L, 20, 20 },
                    { 202L, 100L, 10, 30 },
                    { 203L, 100L, 5, 40 },
                    { 204L, 100L, 2, 50 },
                    { 205L, 101L, 50, 10 },
                    { 206L, 101L, 20, 20 },
                    { 207L, 101L, 10, 30 },
                    { 208L, 101L, 5, 40 },
                    { 209L, 101L, 2, 50 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_estoquecaixa_caixaid",
                table: "estoquecaixa",
                column: "caixaid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "estoquecaixa");

            migrationBuilder.DropTable(
                name: "caixa");
        }
    }
}
