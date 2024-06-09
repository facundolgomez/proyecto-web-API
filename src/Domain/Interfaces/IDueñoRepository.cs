using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IDueñoRepository
    {
        Dueño Add(Dueño dueño);
        void Delete(Dueño dueño);
        List<Dueño> GetAll();
        Dueño? GetById(int id);
        void SaveChanges();
        void Update(Dueño dueño);
        
    }
}

