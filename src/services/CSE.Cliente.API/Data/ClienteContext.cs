using CSE.Core.Data;
using Microsoft.EntityFrameworkCore;

namespace CSE.Cliente.API.Data;

public class ClienteContext(DbContextOptions<ClienteContext> options) : DbContext(options), IUnitOfWork
{

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ClienteContext).Assembly);
    }

    public async Task<bool> Commit()
    {
        return await base.SaveChangesAsync() > 0;
    }
}
