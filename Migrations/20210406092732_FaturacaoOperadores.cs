using Microsoft.EntityFrameworkCore.Migrations;

namespace Projeto_Lab_Web_Grupo3.Migrations
{
    public partial class FaturacaoOperadores : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FaturacaoOperadores",
                columns: table => new
                {
                    Faturacao_Operadores = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UtilizadorId = table.Column<int>(nullable: false),
                    Mes = table.Column<int>(nullable: false),
                    NomeMes = table.Column<string>(nullable: true),
                    TotalFaturacao = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FaturacaoOperadores", x => x.Faturacao_Operadores);
                    table.ForeignKey(
                        name: "FK_FaturacaoOperadores_Utilizadores",
                        column: x => x.UtilizadorId,
                        principalTable: "Utilizadores",
                        principalColumn: "Utilizador_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FaturacaoOperadores_UtilizadorId",
                table: "FaturacaoOperadores",
                column: "UtilizadorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FaturacaoOperadores");
        }
    }
}
