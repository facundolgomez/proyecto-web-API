using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class GuarderiaRepository : IGuarderiaRepository
    {
        
        private readonly ApplicationContext _context;

        public GuarderiaRepository(ApplicationContext context)
        {
            _context = context;
        }

        public Guarderia Add(Guarderia guarderia)
        {
            
            _context.Guarderias.Add(guarderia);
            _context.SaveChanges();
            return guarderia;
        }

        public void Delete(Guarderia guarderia)
        {
            _context.Remove(guarderia);
            _context.SaveChanges();

        }

        public List<Guarderia> GetAll()
        {
            return _context.Guarderias.ToList();    
        }

        public Guarderia? GetById(int id)
        {
            return _context.Guarderias.FirstOrDefault(x => x.Id == id);
        }

        public void Update(Guarderia guarderia)
        {
            _context.Update(guarderia);
            _context.SaveChanges();

        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

    }
}
