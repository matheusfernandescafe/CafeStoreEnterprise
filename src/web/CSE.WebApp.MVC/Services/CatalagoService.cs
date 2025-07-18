using CSE.WebApp.MVC.Extensions;
using CSE.WebApp.MVC.Models;
using Microsoft.Extensions.Options;

namespace CSE.WebApp.MVC.Services;

public class CatalogoService(HttpClient httpClient,
    IOptions<AppSettings> settings) : Service, ICatalogoService
{
    private readonly HttpClient _httpClient = httpClient;
    private readonly AppSettings _settings = settings.Value;
    private readonly string _catalogoUrl = settings.Value.CatalogoUrl;

    public async Task<ProdutoViewModel> ObterPorId(Guid id)
    {
        var response = await _httpClient.GetAsync($"{_catalogoUrl}catalogo/produtos/{id}");

        TratarErrosResponse(response);

        return await DeserializarObjetoResponse<ProdutoViewModel>(response)
               ?? throw new InvalidOperationException("Produto não encontrado.");
    }

    public async Task<IEnumerable<ProdutoViewModel>> ObterTodos()
    {
        var response = await _httpClient.GetAsync($"{_catalogoUrl}catalogo/produtos/");

        TratarErrosResponse(response);

        return await DeserializarObjetoResponse<IEnumerable<ProdutoViewModel>>(response) ?? [];
    }
}
