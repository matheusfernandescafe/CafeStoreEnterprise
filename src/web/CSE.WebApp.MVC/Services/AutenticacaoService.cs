using CSE.WebApp.MVC.Models;
using System.Text;
using System.Text.Json;

namespace CSE.WebApp.MVC.Services;

public class AutenticacaoService(HttpClient httpClient) : IAutenticacaoService
{
    private readonly HttpClient _httpClient = httpClient;

    public async Task<UsuarioRespostaLogin> Login(UsuarioLogin usuarioLogin)
    {
        var loginContent = new StringContent(
            JsonSerializer.Serialize(usuarioLogin),
            Encoding.UTF8,
            "application/json");

        var response = await _httpClient.PostAsync("https://localhost:5001/api/identidade/autenticar", loginContent);

        var responseSeralizer = JsonSerializer.Deserialize<UsuarioRespostaLogin>(await response.Content.ReadAsStringAsync(), new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });

        return responseSeralizer!;
    }

    public async Task<UsuarioRespostaLogin> Registro(UsuarioRegistro usuarioRegistro)
    {
        var loginContent = new StringContent(
            JsonSerializer.Serialize(usuarioRegistro),
            Encoding.UTF8,
            "application/json");

        var response = await _httpClient.PostAsync("https://localhost:5001/api/identidade/nova-conta", loginContent);

        var responseSeralizer = JsonSerializer.Deserialize<UsuarioRespostaLogin>(await response.Content.ReadAsStringAsync(), new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });

        return responseSeralizer!;
    }
}
