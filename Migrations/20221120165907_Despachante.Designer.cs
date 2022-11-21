﻿// <auto-generated />
using System;
using Despachantes.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Despachantes.Migrations
{
    [DbContext(typeof(DespachanteContext))]
    [Migration("20221120165907_Despachante")]
    partial class Despachante
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.5");

            modelBuilder.Entity("Despachantes.Model.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("varchar(11)");

                    b.Property<DateTime>("Nascimento")
                        .HasColumnType("datetime");

                    b.Property<string>("Nome")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("Despachantes.Model.Cliente_Servico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Cliente")
                        .HasColumnType("int");

                    b.Property<int>("Fk_Cliente")
                        .HasColumnType("int");

                    b.Property<int>("Fk_Servico")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Fk_Servico");

                    b.ToTable("Clientes_Servicos");
                });

            modelBuilder.Entity("Despachantes.Model.Servico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("Valor")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.ToTable("Servicos");
                });

            modelBuilder.Entity("Despachantes.Model.Veiculo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Fk_Cliente")
                        .HasColumnType("int");

                    b.Property<string>("Placa")
                        .HasColumnType("text");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Fk_Cliente");

                    b.ToTable("Veiculos");
                });

            modelBuilder.Entity("Despachantes.Model.Cliente_Servico", b =>
                {
                    b.HasOne("Despachantes.Model.Servico", "Servico")
                        .WithMany()
                        .HasForeignKey("Fk_Servico")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Servico");
                });

            modelBuilder.Entity("Despachantes.Model.Veiculo", b =>
                {
                    b.HasOne("Despachantes.Model.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("Fk_Cliente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");
                });
#pragma warning restore 612, 618
        }
    }
}
