using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using static CSE.Identidade.API.Models.UserViewModels;

namespace CSE.Identidade.API.Controllers;

[ApiController]
[Route("api/identidade")]
public class AuthController(SignInManager<IdentityUser> signInManager,
                      UserManager<IdentityUser> userManager
                      //IOptions<AppSettings> appSettings
    ) : Controller
{
    private readonly SignInManager<IdentityUser> _signInManager = signInManager;
    private readonly UserManager<IdentityUser> _userManager = userManager;
    //private readonly AppSettings _appSettings = appSettings.Value;

    [HttpPost("nova-conta")]
    public async Task<ActionResult> Registrar(UsuarioRegistro usuarioRegistro)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var user = new IdentityUser
        {
            UserName = usuarioRegistro.Email,
            Email = usuarioRegistro.Email,
            EmailConfirmed = true
        };

        var result = await _userManager.CreateAsync(user, usuarioRegistro.Senha);

        if (result.Succeeded)
        {
            await _signInManager.SignInAsync(user, isPersistent: false);
            return Ok();
        }

        return BadRequest();
    }

    [HttpPost("autenticar")]
    public async Task<ActionResult> Login(UsuarioLogin usuarioLogin)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var result = await _signInManager.PasswordSignInAsync(usuarioLogin.Email, usuarioLogin.Senha,
            false, true);

        if (result.Succeeded)
        {
            return Ok();
        }

        return BadRequest();
    }
 }
