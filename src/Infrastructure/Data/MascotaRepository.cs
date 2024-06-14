using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class MascotaRepository : IRepository<Mascota>
    {

        private readonly ApplicationContext _context;

        public MascotaRepository(ApplicationContext context)
        {
            _context = context;
        }

        public Mascota Add(Mascota mascota)
        {

            _context.Mascotas.Add(mascota);
            _context.SaveChanges();
            return mascota;
        }

        public void Delete(Mascota mascota)
        {
            _context.Remove(mascota);
            _context.SaveChanges();

        }

        public List<Mascota> GetAll()
        {
            return _context.Mascotas.ToList();
        }

        public Mascota? GetById(int id)
        {
            return _context.Mascotas.FirstOrDefault(x => x.MascotaId == id);
        }

        public void Update(Mascota mascota)
        {
            _context.Update(mascota);
            _context.SaveChanges();

        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

    }
}
