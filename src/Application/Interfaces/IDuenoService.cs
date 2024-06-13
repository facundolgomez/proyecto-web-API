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
    public interface IDuenoService
    {
        Dueno Create(DuenoCreateRequest duenoCreateRequest);
        void Delete(int id);
        List<DuenoDto> GetAll();
        List<Dueno> GetAllFullData();
        DuenoDto GetById(int id);
        void Update(int id, DuenoUpdateRequest duenoUpdateRequest);
    }
}
