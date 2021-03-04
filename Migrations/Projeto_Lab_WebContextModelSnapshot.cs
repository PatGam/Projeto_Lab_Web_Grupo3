﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Projeto_Lab_Web_Grupo3.Data;

namespace Projeto_Lab_Web_Grupo3.Migrations
{
    [DbContext(typeof(Projeto_Lab_WebContext))]
    partial class Projeto_Lab_WebContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Projeto_Lab_Web_Grupo3.Models.Contratos", b =>
                {
                    b.Property<int>("ContratoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Contrato_Id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataFim")
                        .HasColumnName("Data_Fim")
                        .HasColumnType("date");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnName("Data_inicio")
                        .HasColumnType("date");

                    b.Property<int>("FuncionarioId")
                        .HasColumnType("int");

                    b.Property<bool>("Inactivo")
                        .HasColumnType("bit");

                    b.Property<int>("PacoteId")
                        .HasColumnType("int");

                    b.Property<decimal>("PrecoFinal")
                        .HasColumnName("Preco_Final")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("PrecoPacote")
                        .HasColumnName("Preco_pacote")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("PromocaoDesc")
                        .HasColumnName("Promocao_desc")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int>("PromocoesId")
                        .HasColumnType("int");

                    b.Property<int>("Telefone")
                        .HasColumnName("Telefone")
                        .HasColumnType("int");

                    b.Property<int>("UtilizadorId")
                        .HasColumnType("int");

                    b.HasKey("ContratoId");

                    b.HasIndex("PacoteId");

                    b.HasIndex("PromocoesId");

                    b.HasIndex("UtilizadorId");

                    b.ToTable("Contratos");
                });

            modelBuilder.Entity("Projeto_Lab_Web_Grupo3.Models.Pacotes", b =>
                {
                    b.Property<int>("PacoteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Pacote_Id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataInactivo")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(1000)")
                        .HasMaxLength(1000);

                    b.Property<byte[]>("Imagem")
                        .HasColumnType("varbinary(max)");

                    b.Property<bool>("Inactivo")
                        .HasColumnType("bit");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<decimal>("Preco")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("PacoteId");

                    b.ToTable("Pacotes");
                });

            modelBuilder.Entity("Projeto_Lab_Web_Grupo3.Models.Promocoes", b =>
                {
                    b.Property<int>("PromocoesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Promocoes_Id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataFim")
                        .HasColumnName("Data_fim")
                        .HasColumnType("date");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnName("Data_inicio")
                        .HasColumnType("date");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(1000)")
                        .HasMaxLength(1000);

                    b.Property<bool>("Inactivo")
                        .HasColumnType("bit");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<decimal>("PromocaoDesc")
                        .HasColumnName("Promocao_desc")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("PromocoesId");

                    b.ToTable("Promocoes");
                });

            modelBuilder.Entity("Projeto_Lab_Web_Grupo3.Models.PromocoesPacotes", b =>
                {
                    b.Property<int>("PromocoesPacotesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Promocoes_Pacotes_Id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PacoteId")
                        .HasColumnName("Pacote_Id")
                        .HasColumnType("int");

                    b.Property<int>("PromocoesId")
                        .HasColumnName("Promocoes_Id")
                        .HasColumnType("int");

                    b.HasKey("PromocoesPacotesId");

                    b.HasIndex("PacoteId");

                    b.HasIndex("PromocoesId");

                    b.ToTable("Promocoes_Pacotes");
                });

            modelBuilder.Entity("Projeto_Lab_Web_Grupo3.Models.Servicos", b =>
                {
                    b.Property<int>("ServicoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Servico_Id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(1000)")
                        .HasMaxLength(1000);

                    b.Property<bool>("Inactivo")
                        .HasColumnType("bit");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<int>("TipoServicoId")
                        .HasColumnName("Tipo_Servico")
                        .HasColumnType("int");

                    b.HasKey("ServicoId");

                    b.HasIndex("TipoServicoId");

                    b.ToTable("Servicos");
                });

            modelBuilder.Entity("Projeto_Lab_Web_Grupo3.Models.ServicosPacotes", b =>
                {
                    b.Property<int>("SevicoPacoteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Sevico_Pacote_Id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PacoteId")
                        .HasColumnName("Pacote_Id")
                        .HasColumnType("int");

                    b.Property<int>("ServicoId")
                        .HasColumnName("Servico_Id")
                        .HasColumnType("int");

                    b.HasKey("SevicoPacoteId");

                    b.HasIndex("PacoteId");

                    b.HasIndex("ServicoId");

                    b.ToTable("Servicos_Pacotes");
                });

            modelBuilder.Entity("Projeto_Lab_Web_Grupo3.Models.Tipos_Clientes", b =>
                {
                    b.Property<int>("TipoClienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Tipos_CLientes_Id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("TipoClienteId");

                    b.ToTable("Tipos_Clientes");
                });

            modelBuilder.Entity("Projeto_Lab_Web_Grupo3.Models.Tipos_Sevicos", b =>
                {
                    b.Property<int>("TipoServicoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Tipo_Servico_Id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("TipoServicoId");

                    b.ToTable("TiposServicos");
                });

            modelBuilder.Entity("Projeto_Lab_Web_Grupo3.Models.Utilizadores", b =>
                {
                    b.Property<int>("UtilizadorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Utilizador_Id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CodigoPostal")
                        .IsRequired()
                        .HasColumnName("Codigo_Postal")
                        .HasColumnType("nvarchar(8)")
                        .HasMaxLength(8);

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnName("Data_Nascimento")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<bool>("Inactivo")
                        .HasColumnType("bit");

                    b.Property<string>("Morada")
                        .IsRequired()
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<string>("Nif")
                        .HasColumnName("NIF")
                        .HasColumnType("nvarchar(9)")
                        .HasMaxLength(9);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("Telemovel")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UtilizadorId");

                    b.ToTable("Utilizadores");
                });

            modelBuilder.Entity("Projeto_Lab_Web_Grupo3.Models.Contratos", b =>
                {
                    b.HasOne("Projeto_Lab_Web_Grupo3.Models.Pacotes", "Pacotes")
                        .WithMany("Contratos")
                        .HasForeignKey("PacoteId")
                        .HasConstraintName("FK_Contratos_Pacotes")
                        .IsRequired();

                    b.HasOne("Projeto_Lab_Web_Grupo3.Models.Promocoes", "Promocoes")
                        .WithMany("Contratos")
                        .HasForeignKey("PromocoesId")
                        .HasConstraintName("FK_Contratos_Promocoes")
                        .IsRequired();

                    b.HasOne("Projeto_Lab_Web_Grupo3.Models.Utilizadores", "Utilizadores")
                        .WithMany("Contratos")
                        .HasForeignKey("UtilizadorId")
                        .HasConstraintName("FK_Contratos_Utilizadores")
                        .IsRequired();
                });

            modelBuilder.Entity("Projeto_Lab_Web_Grupo3.Models.PromocoesPacotes", b =>
                {
                    b.HasOne("Projeto_Lab_Web_Grupo3.Models.Pacotes", "Pacote")
                        .WithMany("PromocoesPacotes")
                        .HasForeignKey("PacoteId")
                        .HasConstraintName("FK_Promocoes_Pacotes_Pacotes")
                        .IsRequired();

                    b.HasOne("Projeto_Lab_Web_Grupo3.Models.Promocoes", "Promocoes")
                        .WithMany("PromocoesPacotes")
                        .HasForeignKey("PromocoesId")
                        .HasConstraintName("FK_Promocoes_Pacotes_Promocoes")
                        .IsRequired();
                });

            modelBuilder.Entity("Projeto_Lab_Web_Grupo3.Models.Servicos", b =>
                {
                    b.HasOne("Projeto_Lab_Web_Grupo3.Models.Tipos_Sevicos", "TipoServicos")
                        .WithMany("Servicos")
                        .HasForeignKey("TipoServicoId")
                        .HasConstraintName("FK_Servicos_TipoServicos")
                        .IsRequired();
                });

            modelBuilder.Entity("Projeto_Lab_Web_Grupo3.Models.ServicosPacotes", b =>
                {
                    b.HasOne("Projeto_Lab_Web_Grupo3.Models.Pacotes", "Pacote")
                        .WithMany("ServicosPacotes")
                        .HasForeignKey("PacoteId")
                        .HasConstraintName("FK_Servicos_Pacotes_Pacotes")
                        .IsRequired();

                    b.HasOne("Projeto_Lab_Web_Grupo3.Models.Servicos", "Servico")
                        .WithMany("ServicosPacotes")
                        .HasForeignKey("ServicoId")
                        .HasConstraintName("FK_Servicos_Pacotes_Servicos")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
