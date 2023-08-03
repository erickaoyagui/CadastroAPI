using CadastroAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroAPI.Domain.Interfaces
{
    public interface IClienteRepository
    {
        Cliente GetById(int id);
        List<Cliente> GetAll();
        void Add(Cliente cliente);
        void Update(Cliente cliente);
        void Delete(int id);
    }
}
