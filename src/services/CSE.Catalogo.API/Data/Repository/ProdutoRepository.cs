using CSE.Catalogo.API.Models;
using CSE.Core.Data;
using Microsoft.EntityFrameworkCore;

namespace CSE.Catalogo.API.Data.Repository;

public class ProdutoRepository(CatalogoContext context) : IProdutoRepository
{
    private readonly CatalogoContext _context = context;

    public IUnitOfWork UnitOfWork => _context;

    public async Task<IEnumerable<Produto>> ObterTodos()
    {
        return await _context.Produtos.AsNoTracking().ToListAsync();
    }

    public async Task<Produto?> ObterPorId(Guid id)
    {
        return await _context.Produtos.FindAsync(id);
    }

    public async Task Adicionar(Produto produto)
    {
        await _context.Produtos.AddAsync(produto);
    }

    public void Atualizar(Produto produto)
    {
        _context.Produtos.Update(produto);
    }

    public void Dispose()
    {
        _context?.Dispose();
    }
}
