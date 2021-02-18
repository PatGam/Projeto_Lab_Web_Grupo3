using Microsoft.EntityFrameworkCore.Migrations;

namespace Projeto_Lab_Web_Grupo3.Migrations
{
    public partial class RolesString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Funcionarios_Roles",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "Roles_Nome",
                table: "Funcionarios");

            migrationBuilder.AlterColumn<int>(
                name: "RolesId",
                table: "Funcionarios",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Funcionarios",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionarios_Roles_RolesId",
                table: "Funcionarios",
                column: "RolesId",
                principalTable: "Roles",
                principalColumn: "RolesId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Funcionarios_Roles_RolesId",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Funcionarios");

            migrationBuilder.AlterColumn<int>(
                name: "RolesId",
                table: "Funcionarios",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Roles_Nome",
                table: "Funcionarios",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionarios_Roles",
                table: "Funcionarios",
                column: "RolesId",
                principalTable: "Roles",
                principalColumn: "RolesId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
