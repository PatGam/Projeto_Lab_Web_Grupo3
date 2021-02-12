using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Projeto_Lab_Web_Grupo3.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Cliente_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(maxLength: 100, nullable: false),
                    Data_Nascimento = table.Column<DateTime>(type: "date", nullable: false),
                    NIF = table.Column<int>(maxLength: 9, nullable: false),
                    Morada = table.Column<string>(maxLength: 200, nullable: false),
                    Telemovel = table.Column<int>(maxLength: 9, nullable: false),
                    Email = table.Column<string>(maxLength: 100, nullable: false),
                    Codigo_Postal = table.Column<string>(maxLength: 8, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Cliente_Id);
                });

            migrationBuilder.CreateTable(
                name: "Funcionarios",
                columns: table => new
                {
                    Funcionario_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(maxLength: 100, nullable: false),
                    Data_Nascimento = table.Column<DateTime>(type: "date", nullable: false),
                    Morada = table.Column<string>(maxLength: 500, nullable: false),
                    Telemovel = table.Column<int>(nullable: false),
                    Email = table.Column<string>(maxLength: 100, nullable: false),
                    Codigo_Postal = table.Column<string>(maxLength: 8, nullable: false),
                    Role = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionarios", x => x.Funcionario_Id);
                });

            migrationBuilder.CreateTable(
                name: "Pacotes",
                columns: table => new
                {
                    Pacote_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(maxLength: 100, nullable: false),
                    Descricao = table.Column<string>(maxLength: 1000, nullable: true),
                    Preco = table.Column<decimal>(type: "decimal(18, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacotes", x => x.Pacote_Id);
                });

            migrationBuilder.CreateTable(
                name: "Promocoes",
                columns: table => new
                {
                    Promocoes_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(maxLength: 100, nullable: false),
                    Descricao = table.Column<string>(maxLength: 1000, nullable: true),
                    Data_inicio = table.Column<DateTime>(type: "date", nullable: false),
                    Data_fim = table.Column<DateTime>(type: "date", nullable: false),
                    Promocao_desc = table.Column<decimal>(type: "decimal(18, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promocoes", x => x.Promocoes_Id);
                });

            migrationBuilder.CreateTable(
                name: "Servicos",
                columns: table => new
                {
                    Servico_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(maxLength: 100, nullable: false),
                    Descricao = table.Column<string>(maxLength: 1000, nullable: true),
                    Tipo_Servico = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicos", x => x.Servico_Id);
                });

            migrationBuilder.CreateTable(
                name: "Promocoes_Pacotes",
                columns: table => new
                {
                    Promocoes_Pacotes_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pacote_Id = table.Column<int>(nullable: false),
                    Promocoes_Id = table.Column<int>(nullable: false),
                    Nome_Pacote = table.Column<string>(maxLength: 100, nullable: false),
                    Nome_Promocoes = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promocoes_Pacotes", x => x.Promocoes_Pacotes_Id);
                    table.ForeignKey(
                        name: "FK_Promocoes_Pacotes_Pacotes",
                        column: x => x.Pacote_Id,
                        principalTable: "Pacotes",
                        principalColumn: "Pacote_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Promocoes_Pacotes_Promocoes",
                        column: x => x.Promocoes_Id,
                        principalTable: "Promocoes",
                        principalColumn: "Promocoes_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Servicos_Pacotes",
                columns: table => new
                {
                    Sevico_Pacote_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Servico_Id = table.Column<int>(nullable: false),
                    Pacote_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicos_Pacotes", x => x.Sevico_Pacote_Id);
                    table.ForeignKey(
                        name: "FK_Servicos_Pacotes_Pacotes",
                        column: x => x.Pacote_Id,
                        principalTable: "Pacotes",
                        principalColumn: "Pacote_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Servicos_Pacotes_Servicos",
                        column: x => x.Servico_Id,
                        principalTable: "Servicos",
                        principalColumn: "Servico_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Contratos",
                columns: table => new
                {
                    Contrato_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cliente_Id = table.Column<int>(nullable: false),
                    Funcionario_Id = table.Column<int>(nullable: false),
                    Data_inicio = table.Column<DateTime>(type: "date", nullable: false),
                    Preco_Final = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Data_Fim = table.Column<DateTime>(type: "date", nullable: false),
                    Promocoes_Pacotes = table.Column<int>(nullable: false),
                    Preco_pacote = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Promocao_desc = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Nome_Cliente = table.Column<string>(maxLength: 100, nullable: false),
                    Nome_Funcionario = table.Column<string>(maxLength: 100, nullable: false),
                    Telefone = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contratos", x => x.Contrato_Id);
                    table.ForeignKey(
                        name: "FK_Contratos_Clientes",
                        column: x => x.Cliente_Id,
                        principalTable: "Clientes",
                        principalColumn: "Cliente_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Contratos_Funcionarios",
                        column: x => x.Funcionario_Id,
                        principalTable: "Funcionarios",
                        principalColumn: "Funcionario_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Contratos_Promocoes_Pacotes",
                        column: x => x.Promocoes_Pacotes,
                        principalTable: "Promocoes_Pacotes",
                        principalColumn: "Promocoes_Pacotes_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contratos_Cliente_Id",
                table: "Contratos",
                column: "Cliente_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Contratos_Funcionario_Id",
                table: "Contratos",
                column: "Funcionario_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Contratos_Promocoes_Pacotes",
                table: "Contratos",
                column: "Promocoes_Pacotes");

            migrationBuilder.CreateIndex(
                name: "IX_Promocoes_Pacotes_Pacote_Id",
                table: "Promocoes_Pacotes",
                column: "Pacote_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Promocoes_Pacotes_Promocoes_Id",
                table: "Promocoes_Pacotes",
                column: "Promocoes_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Servicos_Pacotes_Pacote_Id",
                table: "Servicos_Pacotes",
                column: "Pacote_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Servicos_Pacotes_Servico_Id",
                table: "Servicos_Pacotes",
                column: "Servico_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contratos");

            migrationBuilder.DropTable(
                name: "Servicos_Pacotes");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Funcionarios");

            migrationBuilder.DropTable(
                name: "Promocoes_Pacotes");

            migrationBuilder.DropTable(
                name: "Servicos");

            migrationBuilder.DropTable(
                name: "Pacotes");

            migrationBuilder.DropTable(
                name: "Promocoes");
        }
    }
}
