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
        Task AceptarReserva(int reservaId);
        Task RechazarReserva(int reservaId);
        Task CambiarEstadoReserva(int reservaId, EstadoReserva nuevoEstado);
        List<Reserva> ListarReservasPendientes(int guarderiaId); 
    }
}
