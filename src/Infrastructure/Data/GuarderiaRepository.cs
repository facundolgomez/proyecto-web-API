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
    public class GuarderiaRepository : GenericRepository<Guarderia>, IGuarderiaRepository
    {
        private readonly ApplicationContext _context;
        public GuarderiaRepository(ApplicationContext context) : base(context)
        {
            _context = context;
        }

        public Guarderia? GetReservasByGuarderiaId(int guarderiaId)
        {
            return _context.Guarderias
                           .Include(g => g.Reservas)
                           .FirstOrDefault(g => g.Id == guarderiaId);
        }

        public List<Guarderia> GetAllFullData()
        {
            return _context.Guarderias
            .Include(g => g.Dueno)
            .Include(g => g.Reservas)
            .ToList();
        }

        public string GetDuenoNombre(int duenoId)
        {
            var dueno = _context.Duenos.FirstOrDefault(d => d.Id == duenoId);
            return dueno != null ? $"{dueno.Nombre} {dueno.Apellido}" : string.Empty;
        }





    }
}
