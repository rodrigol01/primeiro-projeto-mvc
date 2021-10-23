using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business;

namespace MVC_GerenciadorDeConteudo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Paginas = new Pagina().Lista();
            return View();
        }

        //usando essa ação para a rota com id criada na routeConfig
        public ActionResult About(int id)
        {
            ViewBag.Message = "Agora passo um id como parametro para usar a rota com id no  RouteConfig.";
            return View();
        }
        
        /*
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }
        */
        

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }
}