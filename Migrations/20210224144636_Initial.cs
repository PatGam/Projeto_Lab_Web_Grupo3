using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Projeto_Lab_Web_Grupo3.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "Tipos_Clientes",
                columns: table => new
                {
                    Tipos_CLientes_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipos_Clientes", x => x.Tipos_CLientes_Id);
                });

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
                name: "Utilizadores",
                columns: table => new
                {
                    Funcionario_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(maxLength: 100, nullable: false),
                    NIF = table.Column<string>(maxLength: 9, nullable: true),
                    Data_Nascimento = table.Column<DateTime>(type: "date", nullable: false),
                    Morada = table.Column<string>(maxLength: 500, nullable: false),
                    Telemovel = table.Column<string>(nullable: true),
                    Email = table.Column<string>(maxLength: 100, nullable: false),
                    Codigo_Postal = table.Column<string>(maxLength: 8, nullable: false),
                    Role = table.Column<string>(maxLength: 20, nullable: false),
                    RolesId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilizadores", x => x.Funcionario_Id);
                    table.ForeignKey(
                        name: "FK_Utilizadores_Roles_RolesId",
                        column: x => x.RolesId,
                        principalTable: "Roles",
                        principalColumn: "RolesId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Cliente_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(maxLength: 100, nullable: false),
                    Data_Nascimento = table.Column<DateTime>(type: "date", nullable: false),
                    NIF = table.Column<string>(maxLength: 9, nullable: true),
                    Morada = table.Column<string>(maxLength: 200, nullable: false),
                    Telemovel = table.Column<string>(maxLength: 9, nullable: true),
                    Email = table.Column<string>(maxLength: 100, nullable: false),
                    Codigo_Postal = table.Column<string>(maxLength: 8, nullable: false),
                    TipoClienteId = table.Column<int>(nullable: false),
                    TiposClientesTipoClienteId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Cliente_Id);
                    table.ForeignKey(
                        name: "FK_Clientes_Tipos_Clientes_TiposClientesTipoClienteId",
                        column: x => x.TiposClientesTipoClienteId,
                        principalTable: "Tipos_Clientes",
                        principalColumn: "Tipos_CLientes_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Servicos",
                columns: table => new
                {
                    Servico_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(maxLength: 100, nullable: false),
                    Descricao = table.Column<string>(maxLength: 1000, nullable: true),
                    Tipo_Servico = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicos", x => x.Servico_Id);
                    table.ForeignKey(
                        name: "FK_Servicos_TipoServicos",
                        column: x => x.Tipo_Servico,
                        principalTable: "TiposServicos",
                        principalColumn: "Tipo_Servico_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Contratos",
                columns: table => new
                {
                    Contrato_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UtilizadorId = table.Column<int>(nullable: false),
                    ClienteId = table.Column<int>(nullable: false),
                    FuncionarioId = table.Column<int>(nullable: false),
                    PacoteId = table.Column<int>(nullable: false),
                    PromocoesPacotesId = table.Column<int>(nullable: false),
                    Data_inicio = table.Column<DateTime>(type: "date", nullable: false),
                    Data_Fim = table.Column<DateTime>(type: "date", nullable: false),
                    Telefone = table.Column<int>(nullable: false),
                    Preco_pacote = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Promocao_desc = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Preco_Final = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    ClientesClienteId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contratos", x => x.Contrato_Id);
                    table.ForeignKey(
                        name: "FK_Contratos_Clientes_ClientesClienteId",
                        column: x => x.ClientesClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Cliente_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Contratos_Pacotes",
                        column: x => x.PacoteId,
                        principalTable: "Pacotes",
                        principalColumn: "Pacote_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Contratos_PromocoesPacotes",
                        column: x => x.PromocoesPacotesId,
                        principalTable: "Promocoes_Pacotes",
                        principalColumn: "Promocoes_Pacotes_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Contratos_Clientes",
                        column: x => x.UtilizadorId,
                        principalTable: "Utilizadores",
                        principalColumn: "Funcionario_Id",
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

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_TiposClientesTipoClienteId",
                table: "Clientes",
                column: "TiposClientesTipoClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Contratos_ClientesClienteId",
                table: "Contratos",
                column: "ClientesClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Contratos_PacoteId",
                table: "Contratos",
                column: "PacoteId");

            migrationBuilder.CreateIndex(
                name: "IX_Contratos_PromocoesPacotesId",
                table: "Contratos",
                column: "PromocoesPacotesId");

            migrationBuilder.CreateIndex(
                name: "IX_Contratos_UtilizadorId",
                table: "Contratos",
                column: "UtilizadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Promocoes_Pacotes_Pacote_Id",
                table: "Promocoes_Pacotes",
                column: "Pacote_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Promocoes_Pacotes_Promocoes_Id",
                table: "Promocoes_Pacotes",
                column: "Promocoes_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Servicos_Tipo_Servico",
                table: "Servicos",
                column: "Tipo_Servico");

            migrationBuilder.CreateIndex(
                name: "IX_Servicos_Pacotes_Pacote_Id",
                table: "Servicos_Pacotes",
                column: "Pacote_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Servicos_Pacotes_Servico_Id",
                table: "Servicos_Pacotes",
                column: "Servico_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Utilizadores_RolesId",
                table: "Utilizadores",
                column: "RolesId");
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
                name: "Promocoes_Pacotes");

            migrationBuilder.DropTable(
                name: "Utilizadores");

            migrationBuilder.DropTable(
                name: "Servicos");

            migrationBuilder.DropTable(
                name: "Tipos_Clientes");

            migrationBuilder.DropTable(
                name: "Pacotes");

            migrationBuilder.DropTable(
                name: "Promocoes");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "TiposServicos");
        }
    }
}
