using CadastroAPI.Domain.Entities;
using CadastroAPI.Domain.Interfaces;
using CadastroAPI.Infrastructure.Data;

namespace CadastroAPI.Infrastructure.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ClienteContext context;

        public ClienteRepository(ClienteContext context)
        {
            this.context = context;
        }

        public Cliente GetById(int id)
        {
            return context.Clientes.FirstOrDefault(c => c.Id == id);
        }

        public List<Cliente> GetAll()
        {
            return context.Clientes.ToList();
        }

        public void Add(Cliente cliente)
        {
            if (cliente == null)
            {
                throw new ArgumentNullException(nameof(cliente));
            }

            context.Clientes.Add(cliente);
            context.SaveChanges();
        }

        public void Update(Cliente cliente)
        {
            if (cliente == null)
            {
                throw new ArgumentNullException(nameof(cliente));
            }

            context.Clientes.Update(cliente);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            Cliente cliente = context.Clientes.FirstOrDefault(c => c.Id == id);
            if (cliente != null)
            {
                context.Clientes.Remove(cliente);
                context.SaveChanges();
            }
        }
    }
}