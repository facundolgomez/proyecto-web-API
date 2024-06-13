using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IDuenoRepository
    {
        Dueno Add(Dueno dueno);
        void Delete(Dueno dueno);
        List<Dueno> GetAll();
        Dueno? GetById(int id);
        void SaveChanges();
        void Update(Dueno dueno);
        
    }
}

