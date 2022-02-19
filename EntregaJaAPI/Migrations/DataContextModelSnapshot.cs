﻿// <auto-generated />
using EntregaJaAPI.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using System;

namespace EntregaJaAPI.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("EntregaJaAPI.Models.Produto", b =>
                {
                    b.Property<int>("IdProduto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Descricao")
                        .HasColumnType("text");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Preco")
                        .HasColumnType("numeric");

                    b.HasKey("IdProduto");

                    b.ToTable("Produto");
                });

            modelBuilder.Entity("EntregaJaAPI.Models.ProdutoNaVenda", b =>
                {
                    b.Property<int>("IdProdutoNaVenda")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Descricao")
                        .HasColumnType("text");

                    b.Property<int>("IdProduto")
                        .HasColumnType("integer");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Preco")
                        .HasColumnType("numeric");

                    b.Property<int>("Quantidade")
                        .HasColumnType("integer");

                    b.Property<int?>("VendaIdVenda")
                        .HasColumnType("integer");

                    b.HasKey("IdProdutoNaVenda");

                    b.HasIndex("VendaIdVenda");

                    b.ToTable("ProdutosNaVenda");
                });

            modelBuilder.Entity("EntregaJaAPI.Models.Venda", b =>
                {
                    b.Property<int>("IdVenda")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("DataHoraCancelamentoVenda")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DataHoraVenda")
                        .HasColumnType("timestamp without time zone");

                    b.Property<decimal>("ValorFrete")
                        .HasColumnType("numeric");

                    b.Property<decimal>("ValorTotalVenda")
                        .HasColumnType("numeric");

                    b.HasKey("IdVenda");

                    b.ToTable("Vendas");
                });

            modelBuilder.Entity("EntregaJaAPI.Models.ProdutoNaVenda", b =>
                {
                    b.HasOne("EntregaJaAPI.Models.Venda", null)
                        .WithMany("ProdutosDaVenda")
                        .HasForeignKey("VendaIdVenda");
                });

            modelBuilder.Entity("EntregaJaAPI.Models.Venda", b =>
                {
                    b.Navigation("ProdutosDaVenda");
                });
#pragma warning restore 612, 618
        }
    }
}
