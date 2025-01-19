using System.Security.Claims;

namespace CSE.WebApp.MVC.Extensions;

public interface IUser
{
    string Name { get; }
    Guid ObterUserId();
    string ObterUserEmail();
    string ObterUserToken();
    bool EstaAutenticado();
    bool PossuiRole(string role);
    IEnumerable<Claim> ObterClaims();
    HttpContext? ObterHttpContext();
}

public class AspNetUser(IHttpContextAccessor accessor) : IUser
{
    private readonly IHttpContextAccessor _accessor = accessor;

    public string Name => _accessor.HttpContext?.User.Identity?.Name ?? string.Empty;

    public Guid ObterUserId()
    {
        return EstaAutenticado() ? Guid.Parse(_accessor.HttpContext?.User.GetUserId() ?? string.Empty) : Guid.Empty;
    }

    public string ObterUserEmail()
    {
        return EstaAutenticado() ? _accessor.HttpContext?.User.GetUserEmail() ?? string.Empty : string.Empty;
    }

    public string ObterUserToken()
    {
        return EstaAutenticado() ? _accessor.HttpContext?.User.GetUserToken() ?? string.Empty : string.Empty;
    }

    public bool EstaAutenticado()
    {
        return _accessor.HttpContext?.User.Identity?.IsAuthenticated ?? false;
    }
        
    public bool PossuiRole(string role)
    {
        return _accessor?.HttpContext?.User.IsInRole(role) ?? false;
    }

    public IEnumerable<Claim> ObterClaims()
    {
        return _accessor.HttpContext?.User.Claims ?? [];
    }

    public HttpContext? ObterHttpContext()
    {
        return _accessor.HttpContext;
    }
}

public static class ClaimsPrincipalExtensions
{
    public static string GetUserId(this ClaimsPrincipal principal)
    {
        if (principal == null)
        {
            throw new ArgumentException(null, nameof(principal));
        }

        var claim = principal.FindFirst("sub");
        return claim?.Value ?? string.Empty;
    }

    public static string GetUserEmail(this ClaimsPrincipal principal)
    {
        if (principal == null)
        {
            throw new ArgumentException(null, nameof(principal));
        }

        var claim = principal.FindFirst("email");
        return claim?.Value ?? string.Empty;
    }

    public static string GetUserToken(this ClaimsPrincipal principal)
    {
        if (principal == null)
        {
            throw new ArgumentException(null, nameof(principal));
        }

        var claim = principal.FindFirst("JWT");
        return claim?.Value ?? string.Empty;
    }
}