using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Projeto_Lab_Web_Grupo3.Migrations
{
    public partial class PacotesNosContratos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PacotesNoContratoId",
                table: "ServicosContratos",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PacotesNoContrato",
                columns: table => new
                {
                    Contrato_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContratoId = table.Column<int>(nullable: false),
                    PacoteId = table.Column<int>(nullable: false),
                    Data_inicio = table.Column<DateTime>(type: "date", nullable: false),
                    Data_Fim = table.Column<DateTime>(type: "date", nullable: false),
                    Preco_pacote = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Promocao_desc = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Preco_Final = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Inactivo = table.Column<bool>(nullable: false),
                    Morada = table.Column<string>(maxLength: 500, nullable: false),
                    Codigo_Postal = table.Column<string>(maxLength: 8, nullable: false),
                    DistritosId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PacotesNoContrato", x => x.Contrato_Id);
                    table.ForeignKey(
                        name: "FK_PacotesNoContrato_Contratos",
                        column: x => x.ContratoId,
                        principalTable: "Contratos",
                        principalColumn: "Contrato_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PacotesNoContrato_Distritos",
                        column: x => x.DistritosId,
                        principalTable: "Distritos",
                        principalColumn: "DistritosId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PacotesNoContrato_Pacotes",
                        column: x => x.PacoteId,
                        principalTable: "Pacotes",
                        principalColumn: "Pacote_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServicosContratos_PacotesNoContratoId",
                table: "ServicosContratos",
                column: "PacotesNoContratoId");

            migrationBuilder.CreateIndex(
                name: "IX_PacotesNoContrato_ContratoId",
                table: "PacotesNoContrato",
                column: "ContratoId");

            migrationBuilder.CreateIndex(
                name: "IX_PacotesNoContrato_DistritosId",
                table: "PacotesNoContrato",
                column: "DistritosId");

            migrationBuilder.CreateIndex(
                name: "IX_PacotesNoContrato_PacoteId",
                table: "PacotesNoContrato",
                column: "PacoteId");

            migrationBuilder.AddForeignKey(
                name: "FK_ServicosContratos_PacotesNoContrato_PacotesNoContratoId",
                table: "ServicosContratos",
                column: "PacotesNoContratoId",
                principalTable: "PacotesNoContrato",
                principalColumn: "Contrato_Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServicosContratos_PacotesNoContrato_PacotesNoContratoId",
                table: "ServicosContratos");

            migrationBuilder.DropTable(
                name: "PacotesNoContrato");

            migrationBuilder.DropIndex(
                name: "IX_ServicosContratos_PacotesNoContratoId",
                table: "ServicosContratos");

            migrationBuilder.DropColumn(
                name: "PacotesNoContratoId",
                table: "ServicosContratos");
        }
    }
}
