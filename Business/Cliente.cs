using System.Collections.Generic;

namespace Business
{
    public class Cliente
    {
        public string Nome { get; set; }
        public List<Cliente> Clientes(string cliente)
        {
            var clientes = new List<Cliente>();
            clientes.Add(new Cliente(){Nome = "Rodrigo"});
            return clientes;
        }
    }
}