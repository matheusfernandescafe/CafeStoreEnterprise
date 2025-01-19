using CSE.WebApp.MVC.Models;

namespace CSE.WebApp.MVC.Services;

public interface IAutenticacaoService
{
    Task<UsuarioRespostaLogin> Login(UsuarioLogin usuarioLogin);
    Task<UsuarioRespostaLogin> Registro(UsuarioRegistro usuarioRegistro);
}
