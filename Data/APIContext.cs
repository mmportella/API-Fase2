using API_Fase2.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Fase2.Data
{
    public class APIContext : DbContext
    {

        public APIContext(DbContextOptions<APIContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Estoque>()
                .HasOne(estoque => estoque.Produto)
                .WithMany(produto => produto.Estoques)
                .HasForeignKey(estoque => estoque.ProdutoId);

            builder.Entity<Estoque>()
                .HasOne(estoque => estoque.Estabelecimento)
                .WithMany(estabelecimento => estabelecimento.Estoques)
                .HasForeignKey(estoque => estoque.EstabelecimentoId);

        }

        public DbSet<Estabelecimento> Estabelecimentos { get; set; }

        public DbSet<Produto> Produtos { get; set; }

        public DbSet<Estoque> Estoques { get; set; }

    }
}
