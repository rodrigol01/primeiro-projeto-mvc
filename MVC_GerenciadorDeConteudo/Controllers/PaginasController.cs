using System;
using System.IO;
using System.Text;
using System.Web.Mvc;
using Business;
using NVelocity;
using NVelocity.App;

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
        
        public ActionResult Editar(int id)
        {
            var pagina = Pagina.BuscaPorId(id);
            ViewBag.Pagina = pagina;
            return View();
        }
        
        public ActionResult Preview(int id)
        {
            var pagina = Pagina.BuscaPorId(id);
            ViewBag.Pagina = pagina;
            return View();  
        }
        
        public ActionResult PreviewDinamico(int id)
        {
            var pagina = Pagina.BuscaPorId(id);
            Velocity.Init();

            var modelo = new
            {
                Header = "lista de dados dinamicos",
                Itens = new[]
                {
                    new {ID = 1, Nome = "Texto 001", Negrito = false},
                    new {ID = 2, Nome = "Texto 002", Negrito = true},
                    new {ID = 3, Nome = "Texto 003", Negrito = false},
                }
            };

            var velocityContext = new VelocityContext();
            velocityContext.Put("model", modelo);

            var html = new StringBuilder();
            bool result = Velocity.Evaluate(velocityContext, new StringWriter(html), "NomeParaCapturarLogError"
                , new StringReader(pagina.Conteudo));

            ViewBag.Html = html.ToString();
            return View();
        }
        
        
        public void Excluir(int id)
        {
            Pagina.Excluir(id);
            Response.Redirect("/paginas");
        }
        
        [HttpPost]
        [ValidateInput(false)]
        public void Alterar(int id)
        {
            try
            {
                var pagina = Pagina.BuscaPorId(id);

                DateTime.TryParse(Request["data"], out var data);
            
                pagina.Nome = Request["nome"];
                pagina.Conteudo = Request["conteudo"];
                pagina.Data = data;
                pagina.Save();

                TempData["Sucesso"] = "Página alterada com sucesso";
            }
            catch (Exception e)
            {
                TempData["Erro"] = $"Página não pode ser alterada: {e.Message}";
            }
            
            Response.Redirect("/paginas");

        }
    }
}