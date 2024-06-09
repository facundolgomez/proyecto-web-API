using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class DueñoRepository : IDueñoRepository
    {
        
        private readonly ApplicationContext _context;

        public DueñoRepository(ApplicationContext context)
        {
            _context = context;
        }

        public Dueño Add(Dueño dueño)
        {
            
            _context.Dueños.Add(dueño);
            _context.SaveChanges();
            return dueño;
        }

        public void Delete(Dueño dueño)
        {
            _context.Remove(dueño);
            _context.SaveChanges();

        }

        public List<Dueño> GetAll()
        {
            return _context.Dueños.ToList();    
        }

        public Dueño? GetById(int id)
        {
            return _context.Dueños.FirstOrDefault(x => x.Id == id);
        }

        public void Update(Dueño dueño)
        {
            _context.Update(dueño);
            _context.SaveChanges();

        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

    }
}
