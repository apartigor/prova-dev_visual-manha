﻿// <auto-generated />
using Igor.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Igor.Migrations
{
    [DbContext(typeof(AppDataContext))]
    [Migration("20241016124245_UpdateForeignKeys")]
    partial class UpdateForeignKeys
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.10");

            modelBuilder.Entity("Igor.Models.Folha", b =>
                {
                    b.Property<int>("folhaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ano")
                        .HasColumnType("INTEGER");

                    b.Property<int>("funcionarioId")
                        .HasColumnType("INTEGER");

                    b.Property<double>("impostoFgts")
                        .HasColumnType("REAL");

                    b.Property<double>("impostoInss")
                        .HasColumnType("REAL");

                    b.Property<double>("impostoIrrf")
                        .HasColumnType("REAL");

                    b.Property<int>("mes")
                        .HasColumnType("INTEGER");

                    b.Property<int>("quantidade")
                        .HasColumnType("INTEGER");

                    b.Property<double>("salarioBruto")
                        .HasColumnType("REAL");

                    b.Property<double>("salarioLiquido")
                        .HasColumnType("REAL");

                    b.Property<double>("valor")
                        .HasColumnType("REAL");

                    b.HasKey("folhaId");

                    b.HasIndex("funcionarioId");

                    b.ToTable("Folhas");
                });

            modelBuilder.Entity("Igor.Models.Funcionario", b =>
                {
                    b.Property<int>("funcionarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("cpf")
                        .HasColumnType("TEXT");

                    b.Property<string>("nome")
                        .HasColumnType("TEXT");

                    b.HasKey("funcionarioId");

                    b.ToTable("Funcionarios");
                });

            modelBuilder.Entity("Igor.Models.Folha", b =>
                {
                    b.HasOne("Igor.Models.Funcionario", "Funcionario")
                        .WithMany()
                        .HasForeignKey("funcionarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Funcionario");
                });
#pragma warning restore 612, 618
        }
    }
}
