using CSE.Clientes.API.Models;
using CSE.Core.Data;
using Microsoft.EntityFrameworkCore;

namespace CSE.Clientes.API.Data;

public class ClienteContext : DbContext, IUnitOfWork
{
    public ClienteContext(DbContextOptions<ClienteContext> options) : base(options)
    {
        ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        ChangeTracker.AutoDetectChangesEnabled = false;
    }

    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Endereco> Enderecos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(
            e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
            property.SetColumnType("varchar(100)");

        foreach (var relationship in modelBuilder.Model.GetEntityTypes()
            .SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ClienteContext).Assembly);
    }

    public async Task<bool> Commit()
    {
        return await base.SaveChangesAsync() > 0;
    }
}
