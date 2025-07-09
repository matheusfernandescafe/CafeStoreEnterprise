using CSE.Catalogo.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace CSE.Catalogo.API.Controllers;

[Route("api/[controller]")]
[ApiController]

public class CatalogoController(IProdutoRepository productRepository) : Controller
{
    private readonly IProdutoRepository _iProdutoRepository = productRepository;

    [HttpGet("Produtos")]
    public async Task<IEnumerable<Produto>> Index()
        => await _iProdutoRepository.ObterTodos();

    [HttpGet("Produtos/{id}")]
    public async Task<Produto?> ProdutoDetalhe(Guid id)
        => await _iProdutoRepository.ObterPorId(id);
}
