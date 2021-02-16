﻿using System;
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
            public virtual DbSet<Roles> Roles { get; set; }


            public virtual DbSet<Tipos_Sevicos> TiposServicos { get; set; }



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
                modelBuilder.Entity<Contratos>(entity =>
                {
                    entity.HasIndex(e => e.ClienteId);

                    entity.HasIndex(e => e.FuncionarioId);

                    entity.HasIndex(e => e.PromocoesPacotes);

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


            modelBuilder.Entity<Servicos>(entity =>
            {
                entity.HasOne(d => d.TipoServicos)
                    .WithMany(p => p.Servicos)
                    .HasForeignKey(d => d.TipoServicoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Servicos_TipoServicos");

            });

                modelBuilder.Entity<Funcionarios>() // Lado N
                   .HasOne(p => p.Roles) // um produto tem uma categoria
                   .WithMany(c => c.Funcionarios) // que por sua vez tem vários produtos
                   .HasForeignKey(p => p.RolesId) // chave estrangeira
                   .OnDelete(DeleteBehavior.Restrict); // não permitir o cascade delete


            OnModelCreatingPartial(modelBuilder);
            }

            partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

            public DbSet<Projeto_Lab_Web_Grupo3.Models.Tipos_Clientes> Tipos_Clientes { get; set; }
        }
    }
