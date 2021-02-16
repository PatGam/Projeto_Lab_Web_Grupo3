using Microsoft.EntityFrameworkCore.Migrations;

namespace Projeto_Lab_Web_Grupo3.Migrations
{
    public partial class Roles2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Roles_Nome",
                table: "Funcionarios",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Roles_Nome",
                table: "Funcionarios");
        }
    }
}
