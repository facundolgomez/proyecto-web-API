using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IClienteRepository
    {
        Cliente Add(Cliente cliente);
        void Delete(Cliente cliente);
        List<Cliente> GetAll();
        Cliente? GetById(int id);
        void SaveChanges();
        void Update(Cliente cliente);

    }
}
