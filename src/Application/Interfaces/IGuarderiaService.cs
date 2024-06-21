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
    public interface IGuarderiaService : IService<Guarderia, GuarderiaCreateRequest, GuarderiaUpdateRequest, GuarderiaDto>
    {
        public void AsignarReserva(int guarderiaId, int reservaId);
    }
}
