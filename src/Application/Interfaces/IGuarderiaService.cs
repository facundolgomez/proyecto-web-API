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
    public interface IGuarderiaService
    {
        Guarderia Create(GuarderiaCreateRequest guarderiaCreateRequest);
        void Delete(int id);
        List<GuarderiaDto> GetAll();
        List<Guarderia> GetAllFullData();
        GuarderiaDto GetById(int id);
        void Update(int id, GuarderiaUpdateRequest guarderiaUpdateRequest);
    }
}
