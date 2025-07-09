using CSE.Core.Data;

namespace CSE.Catalogo.API.Models;

public interface IProdutoRepository : IRepository<Produto>
{
    Task<IEnumerable<Produto>> ObterTodos();
    Task<Produto?> ObterPorId(Guid id);

    Task Adicionar(Produto produto);
    void Atualizar(Produto produto);
}
