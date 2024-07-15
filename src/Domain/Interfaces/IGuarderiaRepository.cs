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
        public Guarderia? GetReservasByGuarderiaId(int guarderiaId);
        public List<Guarderia> GetAllFullData();

        public string GetDuenoNombre(int duenoId);
    }
}
