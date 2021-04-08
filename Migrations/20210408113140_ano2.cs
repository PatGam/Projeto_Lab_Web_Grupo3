using Microsoft.EntityFrameworkCore.Migrations;

namespace Projeto_Lab_Web_Grupo3.Migrations
{
    public partial class ano2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ano",
                table: "EnvioDeFaturas",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ano",
                table: "EnvioDeFaturas");
        }
    }
}
