using Microsoft.AspNetCore.Mvc;
using NSE.WebApp.MVC.Models;
using System.Linq;

namespace NSE.WebApp.MVC.Controllers
{
    public class MainController : Controller
    {
        protected bool ResponsePossuiErros(ResponseResult resposta)
        {
            var naoNuloEContemMensagens = resposta != null && resposta.Errors.Mensagens.Any();
            if (naoNuloEContemMensagens)
            {
                resposta.Errors.Mensagens
                    .ForEach(errorMessage => ModelState.AddModelError(string.Empty, errorMessage));
                return true;
            }

            return false;
        }
    }
}
