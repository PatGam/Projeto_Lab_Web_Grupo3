using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Projeto_Lab_Web_Grupo3.Migrations
{
    public partial class BencaoJesus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Distrito",
                table: "Utilizadores");

            migrationBuilder.DropColumn(
                name: "Distrito",
                table: "Promocoes");

            migrationBuilder.DropColumn(
                name: "Distrito",
                table: "Pacotes");

            migrationBuilder.AddColumn<int>(
                name: "DistritosId",
                table: "Utilizadores",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DistritosId",
                table: "Promocoes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DistritosId",
                table: "Pacotes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DistritosId",
                table: "Contratos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Distritos",
                columns: table => new
                {
                    DistritosId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Distritos", x => x.DistritosId);
                });

            migrationBuilder.CreateTable(
                name: "Reclamacoes",
                columns: table => new
                {
                    Reclamacao_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(maxLength: 1000, nullable: true),
                    DataReclamacao = table.Column<DateTime>(nullable: false),
                    Resposta = table.Column<string>(nullable: true),
                    DataResposta = table.Column<DateTime>(nullable: false),
                    EstadoResposta = table.Column<bool>(nullable: false),
                    EstadoResolução = table.Column<bool>(nullable: false),
                    DataResolucao = table.Column<DateTime>(nullable: false),
                    ClienteId = table.Column<int>(nullable: false),
                    FuncionarioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reclamacoes", x => x.Reclamacao_Id);
                    table.ForeignKey(
                        name: "FK_Cliente_Reclamacoes",
                        column: x => x.ClienteId,
                        principalTable: "Utilizadores",
                        principalColumn: "Utilizador_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Funcionarios_Reclamacoes",
                        column: x => x.FuncionarioId,
                        principalTable: "Utilizadores",
                        principalColumn: "Utilizador_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Utilizadores_DistritosId",
                table: "Utilizadores",
                column: "DistritosId");

            migrationBuilder.CreateIndex(
                name: "IX_Promocoes_DistritosId",
                table: "Promocoes",
                column: "DistritosId");

            migrationBuilder.CreateIndex(
                name: "IX_Pacotes_DistritosId",
                table: "Pacotes",
                column: "DistritosId");

            migrationBuilder.CreateIndex(
                name: "IX_Contratos_DistritosId",
                table: "Contratos",
                column: "DistritosId");

            migrationBuilder.CreateIndex(
                name: "IX_Reclamacoes_ClienteId",
                table: "Reclamacoes",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Reclamacoes_FuncionarioId",
                table: "Reclamacoes",
                column: "FuncionarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Distritos_Contratos",
                table: "Contratos",
                column: "DistritosId",
                principalTable: "Distritos",
                principalColumn: "DistritosId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Distritos_Pacotes",
                table: "Pacotes",
                column: "DistritosId",
                principalTable: "Distritos",
                principalColumn: "DistritosId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Distritos_Promocoes",
                table: "Promocoes",
                column: "DistritosId",
                principalTable: "Distritos",
                principalColumn: "DistritosId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Distritos_Utilizadores",
                table: "Utilizadores",
                column: "DistritosId",
                principalTable: "Distritos",
                principalColumn: "DistritosId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Distritos_Contratos",
                table: "Contratos");

            migrationBuilder.DropForeignKey(
                name: "FK_Distritos_Pacotes",
                table: "Pacotes");

            migrationBuilder.DropForeignKey(
                name: "FK_Distritos_Promocoes",
                table: "Promocoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Distritos_Utilizadores",
                table: "Utilizadores");

            migrationBuilder.DropTable(
                name: "Distritos");

            migrationBuilder.DropTable(
                name: "Reclamacoes");

            migrationBuilder.DropIndex(
                name: "IX_Utilizadores_DistritosId",
                table: "Utilizadores");

            migrationBuilder.DropIndex(
                name: "IX_Promocoes_DistritosId",
                table: "Promocoes");

            migrationBuilder.DropIndex(
                name: "IX_Pacotes_DistritosId",
                table: "Pacotes");

            migrationBuilder.DropIndex(
                name: "IX_Contratos_DistritosId",
                table: "Contratos");

            migrationBuilder.DropColumn(
                name: "DistritosId",
                table: "Utilizadores");

            migrationBuilder.DropColumn(
                name: "DistritosId",
                table: "Promocoes");

            migrationBuilder.DropColumn(
                name: "DistritosId",
                table: "Pacotes");

            migrationBuilder.DropColumn(
                name: "DistritosId",
                table: "Contratos");

            migrationBuilder.AddColumn<string>(
                name: "Distrito",
                table: "Utilizadores",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Distrito",
                table: "Promocoes",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Distrito",
                table: "Pacotes",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }
    }
}
