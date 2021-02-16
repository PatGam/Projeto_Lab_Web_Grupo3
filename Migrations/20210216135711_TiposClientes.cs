using Microsoft.EntityFrameworkCore.Migrations;

namespace Projeto_Lab_Web_Grupo3.Migrations
{
    public partial class TiposClientes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Roles_Nome",
                table: "Funcionarios");

            migrationBuilder.AddColumn<int>(
                name: "Tipos_ClientesTipoClienteId",
                table: "Clientes",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Tipos_Clientes",
                columns: table => new
                {
                    Tipos_CLientes_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipos_Clientes", x => x.Tipos_CLientes_Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_Tipos_Clientes_Tipos_ClientesTipoClienteId",
                table: "Clientes");

            migrationBuilder.DropTable(
                name: "Tipos_Clientes");

            migrationBuilder.DropIndex(
                name: "IX_Clientes_Tipos_ClientesTipoClienteId",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "Tipos_ClientesTipoClienteId",
                table: "Clientes");

            migrationBuilder.AddColumn<string>(
                name: "Roles_Nome",
                table: "Funcionarios",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
