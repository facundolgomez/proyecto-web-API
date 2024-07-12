using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models.Requests;
using Application.Models;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IGuarderiaService
    {
        GuarderiaDto Create(GuarderiaCreateRequest guarderiaCreateRequest);
        void Update(int id, GuarderiaUpdateRequest guarderiaUpdateRequest);
        void Delete(int id);
        List<GuarderiaDto> GetAll();
        List<Guarderia> GetAllFullData();
        GuarderiaDto GetById(int id);

        
    }
}
