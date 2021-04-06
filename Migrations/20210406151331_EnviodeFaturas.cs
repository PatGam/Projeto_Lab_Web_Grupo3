using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Projeto_Lab_Web_Grupo3.Migrations
{
    public partial class EnviodeFaturas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "TotalFaturacao",
                table: "FaturacaoOperadores",
                type: "decimal(30, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.CreateTable(
                name: "EnvioDeFaturas",
                columns: table => new
                {
                    EnvioDeFaturasId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataDeEnvio = table.Column<DateTime>(nullable: false),
                    Enviado = table.Column<bool>(nullable: false),
                    Texto = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnvioDeFaturas", x => x.EnvioDeFaturasId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EnvioDeFaturas");

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalFaturacao",
                table: "FaturacaoOperadores",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(30, 2)");
        }
    }
}
