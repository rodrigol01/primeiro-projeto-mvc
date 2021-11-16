using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Database
{
    public class Pagina
    {
        private string sqlConn()
        {
            return ConfigurationManager.AppSettings["SqlConn"];
        }

        public DataTable Lista()
        {
            using (SqlConnection connection = new SqlConnection(sqlConn()))
            {
                var queryString = "select * from paginas";

                var command = new SqlCommand(queryString, connection);
                command.Connection.Open();

                var adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;

                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;
            }
        }

        public void Salvar(int id, string nome, string conteudo, DateTime data)
        {
            using (SqlConnection connection = new SqlConnection(sqlConn()))
            {
                var queryString = "insert into paginas (nome, data, conteudo) values ('"+ nome +"','"
                                  + data.ToString("yyyy-MM-dd hh:mm:ss") +"','"+ conteudo +"')";
                if (id != 0)
                {
                    queryString = "update paginas set nome ='"+ nome + "', data='"
                                  + data.ToString("yyyy-MM-dd hh:mm:ss") + "', conteudo='"
                                  + conteudo + "' where id=" + id;
                }
                var command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public DataTable BuscaPorId(int id)
        {
            using (SqlConnection connection = new SqlConnection(sqlConn()))
            {
                var queryString = "select * from paginas where id=" + id;

                var command = new SqlCommand(queryString, connection);
                command.Connection.Open();

                var adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;

                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;
            }
        }

        public void Excluir(int id)
        {
            using (SqlConnection connection = new SqlConnection(sqlConn()))
            {
                var queryString = "delete from paginas where id = " + id;
                
                var command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}