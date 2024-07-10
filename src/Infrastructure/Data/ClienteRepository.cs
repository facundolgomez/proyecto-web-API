using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;
using System.Linq.Expressions;

namespace Infrastructure.Data
{
    public class ClienteRepository : GenericRepository<Cliente>, IClienteRepository
    {
        private readonly ApplicationContext _context;
        public ClienteRepository(ApplicationContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<Cliente> GetClientsWithPets()
        {
            return _context.Clientes.Include(c => c.Mascotas);
        }



    }
}
