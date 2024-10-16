using LojaSeuManoel.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace LojaSeuManoel.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Caixa> Caixas { get; set; }
        public DbSet<CaixaEmbala> CaixaEmbalas { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Caixa>()
                .Property(c => c.Altura)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Caixa>()
                .Property(c => c.Largura)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Caixa>()
                .Property(c => c.Comprimento)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Produto>()
                .Property(p => p.Altura)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Produto>()
                .Property(p => p.Largura)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Produto>()
                .Property(p => p.Comprimento)
                .HasPrecision(18, 2);


            modelBuilder.Entity<Produto>()
            .ToTable("Produtos")
            .HasKey(p => p.Id);

            modelBuilder.Entity<Caixa>()
                .ToTable("Caixas")
                .HasKey(c => c.Id);

            modelBuilder.Entity<Pedido>()
                .ToTable("Pedidos")
                .HasKey(p => p.Id);

            modelBuilder.Entity<CaixaEmbala>()
                .ToTable("CaixaEmbala")
                .HasKey(ce => ce.Id);

            modelBuilder.Entity<CaixaEmbala>()
                .HasOne(ce => ce.Caixa)
                .WithMany(c => c.CaixaEmbala)
                .HasForeignKey(ce => ce.CaixaId);

            modelBuilder.Entity<CaixaEmbala>()
                .HasOne(ce => ce.Pedido)
                .WithMany(p => p.CaixaEmbala)
                .HasForeignKey(ce => ce.PedidoId);

            modelBuilder.Entity<CaixaEmbala>()
                .HasMany(ce => ce.Produtos)
                .WithMany(p => p.CaixaEmbala);
        }

    }
}
