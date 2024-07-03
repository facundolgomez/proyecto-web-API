using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class MascotaRepository : GenericRepository<Mascota>, IMascotaRepository
    {
        private readonly ApplicationContext _context;

        public MascotaRepository(ApplicationContext context) : base(context)
        {
            _context = context;
        }

        public Mascota GetByIdWithCliente(int id)
        {
            return _context.Mascotas.Include(m => m.Cliente).FirstOrDefault(m => m.Id == id);
        }
    }
}
