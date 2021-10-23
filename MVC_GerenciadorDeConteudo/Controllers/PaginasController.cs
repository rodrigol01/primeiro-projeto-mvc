using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business;

namespace MVC_GerenciadorDeConteudo.Controllers
{
    public class PaginasController : Controller
    {

        public ActionResult Index()
        {
            ViewBag.Paginas = new Pagina().Lista();
            return View();
        }

        public ActionResult Novo()
        {
            return View();
        }
        
        [HttpPost]
        public void Criar()
        {
            DateTime data;
            DateTime.TryParse(Request["data"], out data);
            var pagina = new Pagina();
            pagina.Nome = Request["nome"];
            pagina.Conteudo = Request["conteudo"];
            pagina.Data = data;
            pagina.Save();
            Response.Redirect("/paginas");
        }
    }
}