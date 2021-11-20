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
                "paginas_editar",
                "paginas/{id}/editar",
                new {controller = "Paginas", action = "editar", id = 0}
            );
            
            routes.MapRoute(
                "paginas_alterar",
                "paginas/{id}/alterar",
                new {controller = "Paginas", action = "alterar", id = 0}
            );
            
            routes.MapRoute(
                "paginas_excluir",
                "paginas/{id}/excluir",
                new {controller = "Paginas", action = "excluir", id = 0}
            );
            
            routes.MapRoute(
                "paginas_preview",
                "paginas/{id}/preview",
                new {controller = "Paginas", action = "preview", id = 0}
            );
            
            routes.MapRoute(

                "paginas_preview_dinamico",
                "paginas/{id}/preview-dinamico",
                new {controller = "Paginas", action = "previewDinamico", id = 0}
            );

            routes.MapRoute(
                "paginas_preview_dinamico_notema",
                "paginas/{id}/preview-dinamico-notema",
                new {controller = "Paginas", action = "previewDinamicoNoTema", id = 0}
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