using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class DuenoRepository : IRepository<Dueno>
    {
        
        private readonly ApplicationContext _context;

        public DuenoRepository(ApplicationContext context)
        {
            _context = context;
        }

        public Dueno Add(Dueno dueno)
        {
            
            _context.Duenos.Add(dueno);
            _context.SaveChanges();
            return dueno;
        }

        public void Delete(Dueno dueno)
        {
            _context.Remove(dueno);
            _context.SaveChanges();

        }

        public List<Dueno> GetAll()
        {
            return _context.Duenos.ToList();    
        }

        public Dueno? GetById(int id)
        {
            return _context.Duenos.FirstOrDefault(x => x.Id == id);
        }

        public void Update(Dueno dueno)
        {
            _context.Update(dueno);
            _context.SaveChanges();

        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

    }
}
