using CSE.WebApp.MVC.Models;
using CSE.WebApp.MVC.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace CSE.WebApp.MVC.Controllers;

public class IdentidadeController(IAutenticacaoService autenticacaoService) : MainController
{
    private readonly IAutenticacaoService _iAutenticacaoService = autenticacaoService;

    [HttpGet("nova-conta")]
    public IActionResult Registro()
    {
        return View();
    }

    [HttpPost("nova-conta")]
    public async Task<IActionResult> Registro(UsuarioRegistro usuarioRegistro)
    {
        if (!ModelState.IsValid)
            return View(usuarioRegistro);

        var resposta = await _iAutenticacaoService.Registro(usuarioRegistro);

        if (ResponsePossuiErros(resposta.ResponseResult))
            return View(usuarioRegistro);

        await RealizarLogin(resposta);

        return RedirectToAction("Index", "Home");
    }

    [HttpGet("login")]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(UsuarioLogin usuarioLogin)
    {
        if (!ModelState.IsValid) return View(usuarioLogin);

        var resposta = await _iAutenticacaoService.Login(usuarioLogin);

        if (ResponsePossuiErros(resposta.ResponseResult))
            return View(usuarioLogin);

        await RealizarLogin(resposta);

        return RedirectToAction("Index", "Home");
    }

    [HttpGet("sair")]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction("Index", "Home");
    }

    private async Task RealizarLogin(UsuarioRespostaLogin usuarioRespostaLogin)
    {
        var token = ObterTokenFormatado(usuarioRespostaLogin.AccessToken);

        var claims = new List<Claim>
        {
            new("JWT", usuarioRespostaLogin.AccessToken)
        };
        claims.AddRange(token.Claims);

        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

        var authProperties = new AuthenticationProperties
        {
            ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(usuarioRespostaLogin.ExpiresIn),
            IsPersistent = true
        };

        await HttpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            new ClaimsPrincipal(claimsIdentity), 
            authProperties);
    }

    private static JwtSecurityToken ObterTokenFormatado(string jwtToken)
    {
        return new JwtSecurityTokenHandler().ReadToken(jwtToken) as JwtSecurityToken;
    }
}
