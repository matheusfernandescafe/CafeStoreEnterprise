namespace CSE.WebApp.MVC.Models;

public class ErrorViewModel
{
    public string? RequestId { get; set; }

    public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
}

public class ErrorViewModel2
{
    public int ErroCode { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public string Mensagem { get; set; } = string.Empty;
}

public class ResponseResult
{
    public string Title { get; set; } = string.Empty;
    public int Status { get; set; }
    public ResponseErrorMessages Errors { get; set; } = new();
}

public class ResponseErrorMessages
{
    public List<string> Mensagens { get; set; } = [];
}
