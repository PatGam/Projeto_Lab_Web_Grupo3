using Microsoft.EntityFrameworkCore.Migrations;

namespace Projeto_Lab_Web_Grupo3.Migrations
{
    public partial class TiposClientes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_Tipos_Clientes_Tipos_ClientesTipoClienteId",
                table: "Clientes");

            migrationBuilder.DropIndex(
                name: "IX_Clientes_Tipos_ClientesTipoClienteId",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "Tipos_ClientesTipoClienteId",
                table: "Clientes");

            migrationBuilder.AddColumn<int>(
                name: "TipoClienteId",
                table: "Clientes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TiposClientesTipoClienteId",
                table: "Clientes",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_TiposClientesTipoClienteId",
                table: "Clientes",
                column: "TiposClientesTipoClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_Tipos_Clientes_TiposClientesTipoClienteId",
                table: "Clientes",
                column: "TiposClientesTipoClienteId",
                principalTable: "Tipos_Clientes",
                principalColumn: "Tipos_CLientes_Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_Tipos_Clientes_TiposClientesTipoClienteId",
                table: "Clientes");

            migrationBuilder.DropIndex(
                name: "IX_Clientes_TiposClientesTipoClienteId",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "TipoClienteId",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "TiposClientesTipoClienteId",
                table: "Clientes");

            migrationBuilder.AddColumn<int>(
                name: "Tipos_ClientesTipoClienteId",
                table: "Clientes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_Tipos_ClientesTipoClienteId",
                table: "Clientes",
                column: "Tipos_ClientesTipoClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_Tipos_Clientes_Tipos_ClientesTipoClienteId",
                table: "Clientes",
                column: "Tipos_ClientesTipoClienteId",
                principalTable: "Tipos_Clientes",
                principalColumn: "Tipos_CLientes_Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
