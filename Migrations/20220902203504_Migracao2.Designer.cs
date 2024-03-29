﻿// <auto-generated />
using API_Fase2.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API_Fase2.Migrations
{
    [DbContext(typeof(APIContext))]
    [Migration("20220902203504_Migracao2")]
    partial class Migracao2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("API_Fase2.Models.Estabelecimento", b =>
                {
                    b.Property<int>("IdEstabelecimento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdEstabelecimento"), 1L, 1);

                    b.Property<int>("Cep")
                        .HasColumnType("int");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Cnpj")
                        .HasColumnType("int");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("NomeEstabelecimento")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.HasKey("IdEstabelecimento");

                    b.ToTable("Estabelecimentos");
                });

            modelBuilder.Entity("API_Fase2.Models.Estoque", b =>
                {
                    b.Property<int>("IdEstoque")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdEstoque"), 1L, 1);

                    b.Property<int>("EstabelecimentoId")
                        .HasColumnType("int");

                    b.Property<int>("ProdutoId")
                        .HasColumnType("int");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.Property<double>("Valor")
                        .HasColumnType("float");

                    b.HasKey("IdEstoque");

                    b.HasIndex("EstabelecimentoId");

                    b.HasIndex("ProdutoId");

                    b.ToTable("Estoques");
                });

            modelBuilder.Entity("API_Fase2.Models.Lista", b =>
                {
                    b.Property<int>("IdLista")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdLista"), 1L, 1);

                    b.Property<string>("NomeLista")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdLista");

                    b.ToTable("Listas");
                });

            modelBuilder.Entity("API_Fase2.Models.Produto", b =>
                {
                    b.Property<int>("IdProduto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdProduto"), 1L, 1);

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("NomeProduto")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdProduto");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("API_Fase2.Models.ProdutoLista", b =>
                {
                    b.Property<int>("IdProdutoLista")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdProdutoLista"), 1L, 1);

                    b.Property<int>("ListaId")
                        .HasColumnType("int");

                    b.Property<int>("ProdutoId")
                        .HasColumnType("int");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.HasKey("IdProdutoLista");

                    b.HasIndex("ListaId");

                    b.HasIndex("ProdutoId");

                    b.ToTable("ProdutosLista");
                });

            modelBuilder.Entity("API_Fase2.Models.Estoque", b =>
                {
                    b.HasOne("API_Fase2.Models.Estabelecimento", "Estabelecimento")
                        .WithMany("Estoques")
                        .HasForeignKey("EstabelecimentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API_Fase2.Models.Produto", "Produto")
                        .WithMany("Estoques")
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Estabelecimento");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("API_Fase2.Models.ProdutoLista", b =>
                {
                    b.HasOne("API_Fase2.Models.Lista", "Lista")
                        .WithMany("ProdutosLista")
                        .HasForeignKey("ListaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API_Fase2.Models.Produto", "Produto")
                        .WithMany("ProdutosLista")
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lista");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("API_Fase2.Models.Estabelecimento", b =>
                {
                    b.Navigation("Estoques");
                });

            modelBuilder.Entity("API_Fase2.Models.Lista", b =>
                {
                    b.Navigation("ProdutosLista");
                });

            modelBuilder.Entity("API_Fase2.Models.Produto", b =>
                {
                    b.Navigation("Estoques");

                    b.Navigation("ProdutosLista");
                });
#pragma warning restore 612, 618
        }
    }
}
