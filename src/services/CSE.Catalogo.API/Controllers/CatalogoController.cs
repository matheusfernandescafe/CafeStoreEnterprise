using CSE.Catalogo.API.Models;
using CSE.WebAPI.Core.Identidade;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CSE.Catalogo.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]

public class CatalogoController(IProdutoRepository productRepository) : Controller
{
    private readonly IProdutoRepository _iProdutoRepository = productRepository;

    [AllowAnonymous]
    [HttpGet("Produtos")]
    public async Task<IEnumerable<Produto>> Index()
        => await _iProdutoRepository.ObterTodos();

    [ClaimsAuthorize("Catalago", "Ler")]
    [HttpGet("Produtos/{id}")]
    public async Task<Produto?> ProdutoDetalhe(Guid id)
        => await _iProdutoRepository.ObterPorId(id);
}
