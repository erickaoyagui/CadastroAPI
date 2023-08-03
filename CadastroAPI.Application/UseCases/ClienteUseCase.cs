using CadastroAPI.Domain.Entities;
using CadastroAPI.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroAPI.Application.UseCases
{
    public class ClienteUseCase
    {
        private readonly IClienteRepository clienteRepository;

        public ClienteUseCase(IClienteRepository clienteRepository)
        {
            this.clienteRepository = clienteRepository;
        }

        public List<Cliente> GetAllClientes()
        {
            return clienteRepository.GetAll();
        }

        public void AddCliente(Cliente cliente)
        {
            clienteRepository.Add(cliente);
        }
    }
}
