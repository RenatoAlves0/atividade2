﻿// <auto-generated />
using System;
using Atividade1;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Atividade1.Migrations
{
    [DbContext(typeof(StoreContext))]
    partial class StoreContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028");

            modelBuilder.Entity("Atividade1.Agencia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("BancoId");

                    b.HasKey("Id");

                    b.HasIndex("BancoId");

                    b.ToTable("Agencias");
                });

            modelBuilder.Entity("Atividade1.Banco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.HasKey("Id");

                    b.ToTable("Bancos");
                });

            modelBuilder.Entity("Atividade1.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nome");

                    b.HasKey("Id");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("Atividade1.ContaCorrente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AgenciaId");

                    b.Property<decimal>("Saldo");

                    b.Property<string>("Titular");

                    b.HasKey("Id");

                    b.HasIndex("AgenciaId");

                    b.ToTable("ContasCorrentes");
                });

            modelBuilder.Entity("Atividade1.ContaPoupanca", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AgenciaId");

                    b.Property<DateTime>("DataAniversario");

                    b.Property<decimal>("Juros");

                    b.Property<decimal>("Saldo");

                    b.Property<string>("Titular");

                    b.HasKey("Id");

                    b.HasIndex("AgenciaId");

                    b.ToTable("ContasPoupanca");
                });

            modelBuilder.Entity("Atividade1.Solicitacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AgenciaId");

                    b.HasKey("Id");

                    b.HasIndex("AgenciaId");

                    b.ToTable("Solicitacoes");
                });

            modelBuilder.Entity("Atividade1.Agencia", b =>
                {
                    b.HasOne("Atividade1.Banco")
                        .WithMany("Agencias")
                        .HasForeignKey("BancoId");
                });

            modelBuilder.Entity("Atividade1.ContaCorrente", b =>
                {
                    b.HasOne("Atividade1.Agencia", "Agencia")
                        .WithMany("ContaCorrentes")
                        .HasForeignKey("AgenciaId");
                });

            modelBuilder.Entity("Atividade1.ContaPoupanca", b =>
                {
                    b.HasOne("Atividade1.Agencia")
                        .WithMany("ContaPoupancas")
                        .HasForeignKey("AgenciaId");
                });

            modelBuilder.Entity("Atividade1.Solicitacao", b =>
                {
                    b.HasOne("Atividade1.Agencia")
                        .WithMany("Solicitacoes")
                        .HasForeignKey("AgenciaId");
                });
#pragma warning restore 612, 618
        }
    }
}
