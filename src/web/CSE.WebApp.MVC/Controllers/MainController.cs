using CSE.WebApp.MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace CSE.WebApp.MVC.Controllers;

public class MainController : Controller
{
    protected bool ResponsePossuiErros(ResponseResult resposta)
    {
        if (resposta != null && resposta.Errors.Mensagens.Count != 0)
        {
            foreach (var mensagem in resposta.Errors.Mensagens)
            {
                ModelState.AddModelError(string.Empty, mensagem);
            }

            return true;
        }

        return false;
    }
}
