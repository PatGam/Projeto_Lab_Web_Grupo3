using Microsoft.EntityFrameworkCore.Migrations;

namespace Projeto_Lab_Web_Grupo3.Migrations
{
    public partial class TiposServicos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Tipo_Servico",
                table: "Servicos",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.CreateTable(
                name: "TiposServicos",
                columns: table => new
                {
                    Tipo_Servico_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposServicos", x => x.Tipo_Servico_Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Servicos_Tipo_Servico",
                table: "Servicos",
                column: "Tipo_Servico");

            migrationBuilder.AddForeignKey(
                name: "FK_Servicos_TipoServicos",
                table: "Servicos",
                column: "Tipo_Servico",
                principalTable: "TiposServicos",
                principalColumn: "Tipo_Servico_Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Servicos_TipoServicos",
                table: "Servicos");

            migrationBuilder.DropTable(
                name: "TiposServicos");

            migrationBuilder.DropIndex(
                name: "IX_Servicos_Tipo_Servico",
                table: "Servicos");

            migrationBuilder.AlterColumn<string>(
                name: "Tipo_Servico",
                table: "Servicos",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(int),
                oldMaxLength: 50);
        }
    }
}
