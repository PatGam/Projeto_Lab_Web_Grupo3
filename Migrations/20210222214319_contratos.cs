using Microsoft.EntityFrameworkCore.Migrations;

namespace Projeto_Lab_Web_Grupo3.Migrations
{
    public partial class contratos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contratos_Promocoes_Pacotes_PromocoesPacotesId",
                table: "Contratos");

            migrationBuilder.AlterColumn<int>(
                name: "Telefone",
                table: "Contratos",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PromocoesPacotesId",
                table: "Contratos",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PacoteId",
                table: "Contratos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PacotesPacoteId",
                table: "Contratos",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contratos_PacotesPacoteId",
                table: "Contratos",
                column: "PacotesPacoteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contratos_Pacotes_PacotesPacoteId",
                table: "Contratos",
                column: "PacotesPacoteId",
                principalTable: "Pacotes",
                principalColumn: "Pacote_Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Contratos_Promocoes_Pacotes_PromocoesPacotesId",
                table: "Contratos",
                column: "PromocoesPacotesId",
                principalTable: "Promocoes_Pacotes",
                principalColumn: "Promocoes_Pacotes_Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contratos_Pacotes_PacotesPacoteId",
                table: "Contratos");

            migrationBuilder.DropForeignKey(
                name: "FK_Contratos_Promocoes_Pacotes_PromocoesPacotesId",
                table: "Contratos");

            migrationBuilder.DropIndex(
                name: "IX_Contratos_PacotesPacoteId",
                table: "Contratos");

            migrationBuilder.DropColumn(
                name: "PacoteId",
                table: "Contratos");

            migrationBuilder.DropColumn(
                name: "PacotesPacoteId",
                table: "Contratos");

            migrationBuilder.AlterColumn<string>(
                name: "Telefone",
                table: "Contratos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "PromocoesPacotesId",
                table: "Contratos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Contratos_Promocoes_Pacotes_PromocoesPacotesId",
                table: "Contratos",
                column: "PromocoesPacotesId",
                principalTable: "Promocoes_Pacotes",
                principalColumn: "Promocoes_Pacotes_Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
