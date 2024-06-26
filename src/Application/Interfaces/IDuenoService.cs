using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models.Requests;
using Application.Models;
using Domain.Entities;
using Domain.Enums;

namespace Application.Interfaces
{
    public interface IDuenoService : IService<Dueno, DuenoCreateRequest, DuenoUpdateRequest, DuenoDto>
    {
        void AceptarReserva(int reservaId);
        void CancelarReserva(int reservaId);
        GuarderiaDto CrearGuarderia(GuarderiaCreateRequest guarderiaCreateRequest);
        List<ReservaDto> ListarReservasPendientes(int guarderiaId);
        void EnviarMensajeAlCliente(int reservaId, string mensaje);
    }
}
