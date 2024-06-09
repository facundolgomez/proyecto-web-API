using Application.Models;
using Application.Models.Requests;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IDueñoService
    {
        Dueño Create(DueñoCreateRequest dueñoCreateRequest);
        void Delete(int id);
        List<DueñoDto> GetAll();
        List<Dueño> GetAllFullData();
        DueñoDto GetById(int id);
        void Update(int id, DueñoUpdateRequest dueñoUpdateRequest);
    }
}
