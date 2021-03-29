using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Projeto_Lab_Web_Grupo3.Migrations
{
    public partial class PacotesContratos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    Nome = table.Column<string>(maxLength: 50, nullable: false),
                    Icone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposServicos", x => x.Tipo_Servico_Id);
                });

            migrationBuilder.CreateTable(
                name: "Pacotes",
                columns: table => new
                {
                    Pacote_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(maxLength: 100, nullable: false),
                    Descricao = table.Column<string>(maxLength: 1000, nullable: true),
                    Preco = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Inactivo = table.Column<bool>(nullable: false),
                    Imagem = table.Column<byte[]>(nullable: true),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    DataInactivo = table.Column<DateTime>(nullable: false),
                    DistritosId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacotes", x => x.Pacote_Id);
                    table.ForeignKey(
                        name: "FK_Pacotes_Distritos_DistritosId",
                        column: x => x.DistritosId,
                        principalTable: "Distritos",
                        principalColumn: "DistritosId",
                        onDelete: ReferentialAction.Restrict);
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
                    Promocao_desc = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    DistritosId = table.Column<int>(nullable: false),
                    Inactivo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promocoes", x => x.Promocoes_Id);
                    table.ForeignKey(
                        name: "FK_Distritos_Promocoes",
                        column: x => x.DistritosId,
                        principalTable: "Distritos",
                        principalColumn: "DistritosId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Utilizadores",
                columns: table => new
                {
                    Utilizador_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(maxLength: 100, nullable: false),
                    NIF = table.Column<string>(maxLength: 9, nullable: true),
                    Data_Nascimento = table.Column<DateTime>(type: "date", nullable: false),
                    Morada = table.Column<string>(maxLength: 500, nullable: false),
                    Concelho = table.Column<string>(maxLength: 50, nullable: false),
                    Telemovel = table.Column<string>(nullable: true),
                    Email = table.Column<string>(maxLength: 100, nullable: false),
                    Codigo_Postal = table.Column<string>(maxLength: 8, nullable: false),
                    Data_Ativacao = table.Column<DateTime>(type: "date", nullable: false),
                    Role = table.Column<string>(maxLength: 20, nullable: false),
                    Pontos = table.Column<int>(nullable: false),
                    Inactivo = table.Column<bool>(nullable: false),
                    DistritosId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilizadores", x => x.Utilizador_Id);
                    table.ForeignKey(
                        name: "FK_Distritos_Utilizadores",
                        column: x => x.DistritosId,
                        principalTable: "Distritos",
                        principalColumn: "DistritosId",
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
                    Tipo_Servico = table.Column<int>(nullable: false),
                    Inactivo = table.Column<bool>(nullable: false)
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
                name: "DistritosPacotes",
                columns: table => new
                {
                    Distrito_Pacote_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Distrito_Id = table.Column<int>(nullable: false),
                    Pacote_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DistritosPacotes", x => x.Distrito_Pacote_Id);
                    table.ForeignKey(
                        name: "FK_Distritos_Pacotes_Distritos",
                        column: x => x.Distrito_Id,
                        principalTable: "Distritos",
                        principalColumn: "DistritosId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Distritos_Pacotes_Pacotes",
                        column: x => x.Pacote_Id,
                        principalTable: "Pacotes",
                        principalColumn: "Pacote_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Promocoes_Pacotes",
                columns: table => new
                {
                    Promocoes_Pacotes_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pacote_Id = table.Column<int>(nullable: false),
                    Promocoes_Id = table.Column<int>(nullable: false)
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
                name: "Contratos",
                columns: table => new
                {
                    Contrato_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UtilizadorId = table.Column<int>(nullable: false),
                    ClienteId = table.Column<int>(nullable: false),
                    FuncionarioId = table.Column<int>(nullable: false),
                    PacoteId = table.Column<int>(nullable: false),
                    NomePacote = table.Column<string>(nullable: true),
                    PromocoesId = table.Column<int>(nullable: false),
                    Data_inicio = table.Column<DateTime>(type: "date", nullable: false),
                    Data_Fim = table.Column<DateTime>(type: "date", nullable: false),
                    Telefone = table.Column<int>(nullable: false),
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
                    table.PrimaryKey("PK_Contratos", x => x.Contrato_Id);
                    table.ForeignKey(
                        name: "FK_Distritos_Contratos",
                        column: x => x.DistritosId,
                        principalTable: "Distritos",
                        principalColumn: "DistritosId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Contratos_Pacotes",
                        column: x => x.PacoteId,
                        principalTable: "Pacotes",
                        principalColumn: "Pacote_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Contratos_Promocoes",
                        column: x => x.PromocoesId,
                        principalTable: "Promocoes",
                        principalColumn: "Promocoes_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Contratos_Utilizadores",
                        column: x => x.UtilizadorId,
                        principalTable: "Utilizadores",
                        principalColumn: "Utilizador_Id",
                        onDelete: ReferentialAction.Restrict);
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
                    FuncionarioId = table.Column<int>(nullable: false),
                    Inactivo = table.Column<bool>(nullable: false)
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
                name: "ServicosContratos",
                columns: table => new
                {
                    ServicosContratosId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContratoId = table.Column<int>(nullable: false),
                    ServicoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicosContratos", x => x.ServicosContratosId);
                    table.ForeignKey(
                        name: "FK_Servicos_Contratos_Contratos",
                        column: x => x.ContratoId,
                        principalTable: "Contratos",
                        principalColumn: "Contrato_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Servicos_Contratos_Servicos",
                        column: x => x.ServicoId,
                        principalTable: "Servicos",
                        principalColumn: "Servico_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contratos_DistritosId",
                table: "Contratos",
                column: "DistritosId");

            migrationBuilder.CreateIndex(
                name: "IX_Contratos_PacoteId",
                table: "Contratos",
                column: "PacoteId");

            migrationBuilder.CreateIndex(
                name: "IX_Contratos_PromocoesId",
                table: "Contratos",
                column: "PromocoesId");

            migrationBuilder.CreateIndex(
                name: "IX_Contratos_UtilizadorId",
                table: "Contratos",
                column: "UtilizadorId");

            migrationBuilder.CreateIndex(
                name: "IX_DistritosPacotes_Distrito_Id",
                table: "DistritosPacotes",
                column: "Distrito_Id");

            migrationBuilder.CreateIndex(
                name: "IX_DistritosPacotes_Pacote_Id",
                table: "DistritosPacotes",
                column: "Pacote_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Pacotes_DistritosId",
                table: "Pacotes",
                column: "DistritosId");

            migrationBuilder.CreateIndex(
                name: "IX_Promocoes_DistritosId",
                table: "Promocoes",
                column: "DistritosId");

            migrationBuilder.CreateIndex(
                name: "IX_Promocoes_Pacotes_Pacote_Id",
                table: "Promocoes_Pacotes",
                column: "Pacote_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Promocoes_Pacotes_Promocoes_Id",
                table: "Promocoes_Pacotes",
                column: "Promocoes_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Reclamacoes_ClienteId",
                table: "Reclamacoes",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Reclamacoes_FuncionarioId",
                table: "Reclamacoes",
                column: "FuncionarioId");

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
                name: "IX_ServicosContratos_ContratoId",
                table: "ServicosContratos",
                column: "ContratoId");

            migrationBuilder.CreateIndex(
                name: "IX_ServicosContratos_ServicoId",
                table: "ServicosContratos",
                column: "ServicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Utilizadores_DistritosId",
                table: "Utilizadores",
                column: "DistritosId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DistritosPacotes");

            migrationBuilder.DropTable(
                name: "Promocoes_Pacotes");

            migrationBuilder.DropTable(
                name: "Reclamacoes");

            migrationBuilder.DropTable(
                name: "Servicos_Pacotes");

            migrationBuilder.DropTable(
                name: "ServicosContratos");

            migrationBuilder.DropTable(
                name: "Tipos_Clientes");

            migrationBuilder.DropTable(
                name: "Contratos");

            migrationBuilder.DropTable(
                name: "Servicos");

            migrationBuilder.DropTable(
                name: "Pacotes");

            migrationBuilder.DropTable(
                name: "Promocoes");

            migrationBuilder.DropTable(
                name: "Utilizadores");

            migrationBuilder.DropTable(
                name: "TiposServicos");

            migrationBuilder.DropTable(
                name: "Distritos");
        }
    }
}
