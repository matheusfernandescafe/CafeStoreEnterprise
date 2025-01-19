using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace CSE.WebApp.MVC.Models;

public class UsuarioRegistro
{
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [EmailAddress(ErrorMessage = "O campo {0} está em formato inválido")]
    public string Email { get; set; } = null!;

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 6)]
    public string Senha { get; set; } = null!;

    [DisplayName("Confirme sua senha")]
    [Compare("Senha", ErrorMessage = "As senhas não conferem.")]
    public string SenhaConfirmacao { get; set; } = null!;
}

public class UsuarioLogin
{
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [EmailAddress(ErrorMessage = "O campo {0} está em formato inválido")]
    public string Email { get; set; } = null!;

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 6)]
    public string Senha { get; set; } = null!;
}

public class UsuarioRespostaLogin
{
    public string AccessToken { get; set; } = null!;
    public double ExpiresIn { get; set; }
    public UsuarioToken UsuarioToken { get; set; } = new();
    //public ResponseResult ResponseResult { get; set; } = new();
}

public class UsuarioToken
{
    public string Id { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public IEnumerable<UsuarioClaim> Claims { get; set; } = [];
}

public class UsuarioClaim
{
    public string Value { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
}
