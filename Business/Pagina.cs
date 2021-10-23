using System;
using System.Collections.Generic;
using System.Data;

namespace Business
{
    public class Pagina
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Conteudo { get; set; }
        public DateTime Data { get; set; }

        public List<Pagina> Lista()
        {
            var paginaDb = new Database.Pagina();
            var lista = new List<Pagina>();
            
            foreach (DataRow row in paginaDb.Lista().Rows)
            {
                var pagina = new Pagina();
                pagina.Id = Convert.ToInt32(row["id"]);
                pagina.Nome = row["nome"].ToString();
                pagina.Conteudo = row["conteudo"].ToString();
                pagina.Data = Convert.ToDateTime(row["data"]);
                
                lista.Add(pagina);
            }

            return lista;
        }
    }
}