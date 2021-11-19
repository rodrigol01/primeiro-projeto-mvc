using System.Web.Mvc;
using System.Web.Script.Serialization;
using Business;

namespace MVC_GerenciadorDeConteudo.Controllers
{
    public class CepController : Controller
    {
        
        public ActionResult Index()
        {
            ViewBag.Cep = Cep.Busca("09931410");
            return View();
        }

        public string Consulta(string cep)
        {
            var cepObj = Cep.Busca(cep);
            return new JavaScriptSerializer().Serialize(cepObj);
        }
    }
}