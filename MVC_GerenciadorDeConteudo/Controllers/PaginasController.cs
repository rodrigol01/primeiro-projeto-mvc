using System;
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