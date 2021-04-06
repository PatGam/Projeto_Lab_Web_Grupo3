using Microsoft.EntityFrameworkCore.Migrations;

namespace Projeto_Lab_Web_Grupo3.Migrations
{
    public partial class DistritosPromocoes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DistritosPromocoes",
                columns: table => new
                {
                    Distritos_Promocoes_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Distrito_Id = table.Column<int>(nullable: false),
                    Promocoes_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DistritosPromocoes", x => x.Distritos_Promocoes_Id);
                    table.ForeignKey(
                        name: "FK_Distritos_Promocoes_Distritos",
                        column: x => x.Distrito_Id,
                        principalTable: "Distritos",
                        principalColumn: "DistritosId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Distritos_Promocoes_Promocoes",
                        column: x => x.Promocoes_Id,
                        principalTable: "Promocoes",
                        principalColumn: "Promocoes_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DistritosPromocoes_Distrito_Id",
                table: "DistritosPromocoes",
                column: "Distrito_Id");

            migrationBuilder.CreateIndex(
                name: "IX_DistritosPromocoes_Promocoes_Id",
                table: "DistritosPromocoes",
                column: "Promocoes_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DistritosPromocoes");
        }
    }
}
