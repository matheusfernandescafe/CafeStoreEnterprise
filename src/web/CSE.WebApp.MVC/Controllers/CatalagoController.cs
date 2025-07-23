using CSE.WebApp.MVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace CSE.WebApp.MVC.Controllers;

public class CatalogoController(ICatalogoServiceRefit catalogoService) : MainController
{
    private readonly ICatalogoServiceRefit _catalogoService = catalogoService;

    [HttpGet("vitrine")]
    [Route("")]
    public async Task<IActionResult> Index()
        => View(await _catalogoService.ObterTodos());

    [HttpGet("produto-detalhe/{id}")]
    public async Task<IActionResult> ProdutoDetalhe(Guid id)
        => View(await _catalogoService.ObterPorId(id));
}
