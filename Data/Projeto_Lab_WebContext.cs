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

        public virtual DbSet<Clientes> Clientes { get; set; }
        public virtual DbSet<Contratos> Contratos { get; set; }
        public virtual DbSet<Funcionarios> Funcionarios { get; set; }
        public virtual DbSet<Pacotes> Pacotes { get; set; }
        public virtual DbSet<Promocoes> Promocoes { get; set; }
        public virtual DbSet<PromocoesPacotes> PromocoesPacotes { get; set; }
        public virtual DbSet<Servicos> Servicos { get; set; }
        public virtual DbSet<ServicosPacotes> ServicosPacotes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Clientes>(entity =>
            {
                entity.Property(e => e.ClienteId).ValueGeneratedNever();
            });

            modelBuilder.Entity<Contratos>(entity =>
            {
                entity.Property(e => e.ContratoId).ValueGeneratedNever();

                entity.HasOne(d => d.Cliente)
                    .WithMany(p => p.Contratos)
                    .HasForeignKey(d => d.ClienteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Contratos_Clientes");

                entity.HasOne(d => d.Funcionario)
                    .WithMany(p => p.Contratos)
                    .HasForeignKey(d => d.FuncionarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Contratos_Funcionarios");

                entity.HasOne(d => d.PromocoesPacotesNavigation)
                    .WithMany(p => p.Contratos)
                    .HasForeignKey(d => d.PromocoesPacotes)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Contratos_Promocoes_Pacotes");
            });

            modelBuilder.Entity<Funcionarios>(entity =>
            {
                entity.Property(e => e.FuncionarioId).ValueGeneratedNever();
            });

            modelBuilder.Entity<Pacotes>(entity =>
            {
                entity.Property(e => e.PacoteId).ValueGeneratedNever();
            });

            modelBuilder.Entity<Promocoes>(entity =>
            {
                entity.Property(e => e.PromocoesId).ValueGeneratedNever();
            });

            modelBuilder.Entity<PromocoesPacotes>(entity =>
            {
                entity.Property(e => e.PromocoesPacotesId).ValueGeneratedNever();

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

            modelBuilder.Entity<Servicos>(entity =>
            {
                entity.Property(e => e.ServicoId).ValueGeneratedNever();
            });

            modelBuilder.Entity<ServicosPacotes>(entity =>
            {
                entity.Property(e => e.SevicoPacoteId).ValueGeneratedNever();

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

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
