﻿// <auto-generated />
using System;
using GeradorTestes.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LocadoraAutomoveis.Infra.Orm.Migrations
{
    [DbContext(typeof(GeradorTestesDbContext))]
    partial class GeradorTestesDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LocadoraAutomoveis.Dominio.ModuloGrupoAutomovel.GrupoAutomovel", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("TBGrupoAutomovel", (string)null);
                });

            modelBuilder.Entity("LocadoraAutomoveis.Dominio.ModuloParceiro.Parceiro", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("TBParceiro", (string)null);
                });

            modelBuilder.Entity("LocadoraAutomoveis.Dominio.ModuloTaxaServico.TaxaServico", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<bool>("PlanoDiario")
                        .HasColumnType("bit");

                    b.Property<decimal>("Preco")
                        .HasColumnType("decimal(10,2)");

                    b.HasKey("Id");

                    b.ToTable("TBTaxaServico", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
