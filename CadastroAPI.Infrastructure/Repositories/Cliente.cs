using CadastroAPI.Domain.Entities;
using CadastroAPI.Domain.Interfaces;

namespace CadastroAPI.Infrastructure.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private List<Cliente> clientes = new List<Cliente>();

        public Cliente GetById(int id)
        {
            return clientes.FirstOrDefault(c => c.Id == id);
        }

        public List<Cliente> GetAll()
        {
            return clientes;
        }

        public void Add(Cliente cliente)
        {
            clientes.Add(cliente);
        }

        public void Update(Cliente cliente)
        {
            var existingCliente = clientes.FirstOrDefault(c => c.Id == cliente.Id);
            if (existingCliente != null)
            {
                existingCliente.Nome = cliente.Nome;
                existingCliente.Sobrenome = cliente.Sobrenome;
                existingCliente.Idade = cliente.Idade;
                existingCliente.Pais = cliente.Pais;
            }
        }

        public void Delete(int id)
        {
            clientes.RemoveAll(c => c.Id == id);
        }
    }
}