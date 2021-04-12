using Microsoft.EntityFrameworkCore.Migrations;

namespace Projeto_Lab_Web_Grupo3.Migrations
{
    public partial class Reclamacoes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ContratoId",
                table: "Reclamacoes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Reclamacoes_ContratoId",
                table: "Reclamacoes",
                column: "ContratoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reclamacoes_Contratos_ContratoId",
                table: "Reclamacoes",
                column: "ContratoId",
                principalTable: "Contratos",
                principalColumn: "Contrato_Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reclamacoes_Contratos_ContratoId",
                table: "Reclamacoes");

            migrationBuilder.DropIndex(
                name: "IX_Reclamacoes_ContratoId",
                table: "Reclamacoes");

            migrationBuilder.DropColumn(
                name: "ContratoId",
                table: "Reclamacoes");
        }
    }
}
