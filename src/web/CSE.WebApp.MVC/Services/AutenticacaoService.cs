using CSE.WebApp.MVC.Extensions;
using CSE.WebApp.MVC.Models;
using Microsoft.Extensions.Options;

namespace CSE.WebApp.MVC.Services;

public class AutenticacaoService(HttpClient httpClient,
    IOptions<AppSettings> settings) : Service, IAutenticacaoService
{
    private readonly HttpClient _httpClient = httpClient;
    private readonly AppSettings _settings = settings.Value;

    public async Task<UsuarioRespostaLogin?> Login(UsuarioLogin usuarioLogin)
    {
        var loginContent = ObterConteudo(usuarioLogin);

        var response = await _httpClient.PostAsync($"{_settings.AutenticacaoUrl}identidade/autenticar", loginContent);

        if (!TratarErrosResponse(response))
        {
            return new UsuarioRespostaLogin
            {
                ResponseResult = await DeserializarObjetoResponse<ResponseResult>(response) ?? new ResponseResult()
            };
        }

        return await DeserializarObjetoResponse<UsuarioRespostaLogin>(response);
    }

    public async Task<UsuarioRespostaLogin?> Registro(UsuarioRegistro usuarioRegistro)
    {
        var registroContent = ObterConteudo(usuarioRegistro);

        var response = await _httpClient.PostAsync($"{_settings.AutenticacaoUrl}identidade/nova-conta", registroContent);

        if (!TratarErrosResponse(response))
        {
            return new UsuarioRespostaLogin
            {
                ResponseResult = await DeserializarObjetoResponse<ResponseResult>(response) ?? new ResponseResult()
            };
        }

        return await DeserializarObjetoResponse<UsuarioRespostaLogin>(response);
    }
}
