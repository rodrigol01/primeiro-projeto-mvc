using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVC_GerenciadorDeConteudo
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            
            //mapeando uma rota por parametro
            routes.MapRoute(
                "sobre_rodrigo_parametro",
                "sobre/{id}/rodrigo",
                new {controller = "Home", action = "about", id = 0}
            );
            
            
            routes.MapRoute(
                "sobre",
                "sobre",
                new {controller = "Home", action = "about"}
            );
            
            routes.MapRoute(
                "paginas_novo",
                "pagina/novo",
                new {controller = "Paginas", action = "novo"}
            );
            
            routes.MapRoute(
                "paginas_criar",
                "pagina/criar",
                new {controller = "Paginas", action = "criar"}
            );

            routes.MapRoute(
                "paginas",
                "paginas",
                new {controller = "Paginas", action = "Index"}
            );
            
            routes.MapRoute(
                "contato",
                "contato",
                new {controller = "Home", action = "contact"}
            );
            
            //rota padrão sempre por ultimo para ela não sobrescrever as outras
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new {controller = "Home", action = "Index", id = UrlParameter.Optional}
            );
        }
    }
}