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
    }
}