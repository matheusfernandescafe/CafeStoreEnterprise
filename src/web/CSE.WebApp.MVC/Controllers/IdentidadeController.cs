using CSE.WebApp.MVC.Models;
using CSE.WebApp.MVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace CSE.WebApp.MVC.Controllers;

public class IdentidadeController(IAutenticacaoService autenticacaoService) : Controller
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
        if (!ModelState.IsValid) return View(usuarioRegistro);

        var resposta = await _iAutenticacaoService.Registro(usuarioRegistro);

        return View(usuarioRegistro);
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

        if (false) return View(usuarioLogin);

        return RedirectToAction("Index", "Home");
    }
    
    [HttpGet("sair")]
    public async Task<IActionResult> Logout()
    {
        return RedirectToAction("Index", "Home");
    }

}
