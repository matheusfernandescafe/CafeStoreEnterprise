using CSE.Catalogo.API.Models;
using CSE.Core.Data;
using Microsoft.EntityFrameworkCore;

namespace CSE.Catalogo.API.Data;

public class CatalogoContext(DbContextOptions<CatalogoContext> options) : DbContext(options), IUnitOfWork
{
    public DbSet<Produto> Produtos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(
            e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
            property.SetColumnType("varchar(100)");

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CatalogoContext).Assembly);
    }

    public async Task<bool> Commit()
    {
        return await base.SaveChangesAsync() > 0;
    }
}
