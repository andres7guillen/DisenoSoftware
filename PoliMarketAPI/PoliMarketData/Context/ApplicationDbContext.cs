using Microsoft.EntityFrameworkCore;
using PoliMarketDomain.Entidades;
using PoliMarketDomain.Entities;

namespace PoliMarketData.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options){}

    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Pedido> Pedidos { get; set; }
    public DbSet<Producto> Productos { get; set; }
    public DbSet<Vendedor> Vendedores { get; set; }
    public DbSet<Venta> Ventas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Pedido>()
            .Ignore(p => p.Productos);

        modelBuilder.Entity<Pedido>()
        .HasOne(p => p.Cliente)
        .WithMany(c => c.Pedidos)
        .HasForeignKey(p => p.ClienteId)
        .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Pedido>()
        .HasOne<Vendedor>()
        .WithMany(v => v.Pedidos)
        .HasForeignKey(p => p.VendedorId)
        .OnDelete(DeleteBehavior.Restrict);

    }

}
