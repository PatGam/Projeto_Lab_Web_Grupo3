using Microsoft.EntityFrameworkCore.Migrations;

namespace Projeto_Lab_Web_Grupo3.Migrations
{
    public partial class Roles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RolesId",
                table: "Funcionarios",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RolesId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Roles_Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RolesId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_RolesId",
                table: "Funcionarios",
                column: "RolesId");

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

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Funcionarios_RolesId",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "RolesId",
                table: "Funcionarios");
        }
    }
}
