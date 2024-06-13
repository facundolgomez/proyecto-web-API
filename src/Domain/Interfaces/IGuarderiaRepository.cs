using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IGuarderiaRepository
    {
        Guarderia Add(Guarderia guarderia);
        void Delete(Guarderia guarderia);
        List<Guarderia> GetAll();
        Guarderia? GetById(int id);
        void SaveChanges();
        void Update(Guarderia guarderia);
        
    }
}
