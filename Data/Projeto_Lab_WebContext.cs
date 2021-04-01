using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Projeto_Lab_Web_Grupo3.Models;

#nullable disable

namespace Projeto_Lab_Web_Grupo3.Data
{
    
        public partial class Projeto_Lab_WebContext : DbContext
        {
            public Projeto_Lab_WebContext()
            {
            }

            public Projeto_Lab_WebContext(DbContextOptions<Projeto_Lab_WebContext> options)
                : base(options)
            {
            }

            public virtual DbSet<Contratos> Contratos { get; set; }
            public virtual DbSet<Utilizadores> Utilizadores { get; set; }
            public virtual DbSet<Pacotes> Pacotes { get; set; }
            public virtual DbSet<Promocoes> Promocoes { get; set; }
            public virtual DbSet<PromocoesPacotes> PromocoesPacotes { get; set; }
            public virtual DbSet<Servicos> Servicos { get; set; }
            public virtual DbSet<ServicosPacotes> ServicosPacotes { get; set; }
            public virtual DbSet<Tipos_Sevicos> TiposServicos { get; set; }
            public virtual DbSet<Distritos> Distritos { get; set; }
            public virtual DbSet<ServicosContratos> ServicosContratos { get; set; }
            public virtual DbSet<DistritosPacotes> DistritosPacotes { get; set; }

        public virtual DbSet<PacotesNoContrato> PacotesNoContrato { get; set; }





        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                if (!optionsBuilder.IsConfigured)
                {
                    //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                    optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Projeto_Lab_WebContext;Trusted_Connection=True;MultipleActiveResultSets=true");
                }
            }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PacotesNoContrato>(entity =>
            {
               
                entity.HasOne(d => d.Pacotes)
                    .WithMany(p => p.PacotesNoContrato)
                    .HasForeignKey(d => d.PacoteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PacotesNoContrato_Pacotes");

                entity.HasOne(d => d.Contratos)
                    .WithMany(p => p.PacotesNoContrato)
                    .HasForeignKey(d => d.ContratoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PacotesNoContrato_Contratos");


                entity.HasOne(d => d.Distritos)
                        .WithMany(p => p.PacotesNoContrato)
                        .HasForeignKey(d => d.DistritosId)
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_PacotesNoContrato_Distritos");
            });


            modelBuilder.Entity<Contratos>(entity =>
            {
                entity.HasOne(d => d.Utilizadores)
                    .WithMany(p => p.Contratos)
                    .HasForeignKey(d => d.UtilizadorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Contratos_Utilizadores");

                entity.HasOne(d => d.Pacotes)
                    .WithMany(p => p.Contratos)
                    .HasForeignKey(d => d.PacoteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Contratos_Pacotes");

                entity.HasOne(d => d.Promocoes)
                .WithMany(p => p.Contratos)
                .HasForeignKey(d => d.PromocoesId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Contratos_Promocoes");

                entity.HasOne(d => d.Distritos)
                        .WithMany(p => p.Contratos)
                        .HasForeignKey(d => d.DistritosId)
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Distritos_Contratos");
            });


            modelBuilder.Entity<PromocoesPacotes>(entity =>
            {
                entity.HasIndex(e => e.PacoteId);

                entity.HasIndex(e => e.PromocoesId);

                entity.HasOne(d => d.Pacote)
                    .WithMany(p => p.PromocoesPacotes)
                    .HasForeignKey(d => d.PacoteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Promocoes_Pacotes_Pacotes");

                entity.HasOne(d => d.Promocoes)
                    .WithMany(p => p.PromocoesPacotes)
                    .HasForeignKey(d => d.PromocoesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Promocoes_Pacotes_Promocoes");
            });

            modelBuilder.Entity<ServicosPacotes>(entity =>
            {
                entity.HasIndex(e => e.PacoteId);

                entity.HasIndex(e => e.ServicoId);

                entity.HasOne(d => d.Pacote)
                    .WithMany(p => p.ServicosPacotes)
                    .HasForeignKey(d => d.PacoteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Servicos_Pacotes_Pacotes");

                entity.HasOne(d => d.Servico)
                    .WithMany(p => p.ServicosPacotes)
                    .HasForeignKey(d => d.ServicoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Servicos_Pacotes_Servicos");
            });

            modelBuilder.Entity<ServicosContratos>(entity =>
            {
                entity.HasIndex(e => e.ContratoId);

                entity.HasIndex(e => e.ServicoId);

                entity.HasOne(d => d.Contratos)
                    .WithMany(p => p.ServicosContratos)
                    .HasForeignKey(d => d.ContratoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Servicos_Contratos_Contratos");

                entity.HasOne(d => d.Servicos)
                    .WithMany(p => p.ServicosContratos)
                    .HasForeignKey(d => d.ServicoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Servicos_Contratos_Servicos");
            });


            modelBuilder.Entity<Servicos>(entity =>
            {
                entity.HasOne(d => d.TipoServicos)
                    .WithMany(p => p.Servicos)
                    .HasForeignKey(d => d.TipoServicoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Servicos_TipoServicos");

            });

            modelBuilder.Entity<Reclamacoes>(entity =>
            {
                entity.HasOne(d => d.Cliente)
                    .WithMany(p => p.ReclamacoesCliente)
                    .HasForeignKey(d => d.ClienteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cliente_Reclamacoes");

                entity.HasOne(d => d.Funcionario)
                    .WithMany(p => p.ReclamacoesFuncionario)
                    .HasForeignKey(d => d.FuncionarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Funcionarios_Reclamacoes");
            });

            modelBuilder.Entity<Utilizadores>(entity =>
            {
                entity.HasOne(d => d.Distritos)
                        .WithMany(p => p.Utilizadores)
                        .HasForeignKey(d => d.DistritosId)
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Distritos_Utilizadores");
            });

            modelBuilder.Entity<Promocoes>(entity =>
            {
                entity.HasOne(d => d.Distritos)
                        .WithMany(p => p.Promocoes)
                        .HasForeignKey(d => d.DistritosId)
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Distritos_Promocoes");
            });

            //modelBuilder.Entity<Pacotes>(entity =>
            //{
            //    entity.HasOne(d => d.Distritos)
            //            .WithMany(p => p.Pacotes)
            //            .HasForeignKey(d => d.DistritosId)
            //            .OnDelete(DeleteBehavior.ClientSetNull)
            //            .HasConstraintName("FK_Distritos_Pacotes");
            //});

            modelBuilder.Entity<PromocoesPacotes>(entity =>
            {
                entity.HasIndex(e => e.PacoteId);

                entity.HasIndex(e => e.PromocoesId);

                entity.HasOne(d => d.Pacote)
                    .WithMany(p => p.PromocoesPacotes)
                    .HasForeignKey(d => d.PacoteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Promocoes_Pacotes_Pacotes");

                entity.HasOne(d => d.Promocoes)
                    .WithMany(p => p.PromocoesPacotes)
                    .HasForeignKey(d => d.PromocoesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Promocoes_Pacotes_Promocoes");
            });

            modelBuilder.Entity<DistritosPacotes>(entity =>
            {
                entity.HasIndex(e => e.DistritosId);

                entity.HasIndex(e => e.PacoteId);

                entity.HasOne(d => d.Pacote)
                    .WithMany(p => p.DistritosPacotes)
                    .HasForeignKey(d => d.PacoteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Distritos_Pacotes_Pacotes");

                entity.HasOne(d => d.Distritos)
                    .WithMany(p => p.DistritosPacotes)
                    .HasForeignKey(d => d.DistritosId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Distritos_Pacotes_Distritos");
            });


            //modelBuilder.Entity<Clientes>() // Lado N
            //      .HasOne(p => p.TiposClientes) // um produto tem uma categoria
            //      .WithMany(c => c.Clientes) // que por sua vez tem vários produtos
            //      .HasForeignKey(p => p.TipoClienteId) // chave estrangeira
            //      .OnDelete(DeleteBehavior.Restrict) // não permitir o cascade delete
            //      .HasConstraintName("FK_Clientes_TiposClientes");

            OnModelCreatingPartial(modelBuilder);
            }

            partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

            public DbSet<Projeto_Lab_Web_Grupo3.Models.Tipos_Clientes> Tipos_Clientes { get; set; }

            public DbSet<Projeto_Lab_Web_Grupo3.Models.Reclamacoes> Reclamacoes { get; set; }
        }
    }
