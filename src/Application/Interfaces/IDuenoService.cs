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
    public interface IDuenoService
    {
        DuenoDto Create(DuenoCreateRequest duenoCreateRequest);
        void Delete(int id);
        List<DuenoDto> GetAll();
        DuenoDto GetById(int id);
        void Update(int id, DuenoUpdateRequest duenoUpdateRequest);


        void AceptarReserva(int reservaId);
        void CancelarReserva(int reservaId);
        GuarderiaDto CrearGuarderia(GuarderiaCreateRequest guarderiaCreateRequest);
        List<ReservaDto> ListarReservasPendientes(int guarderiaId);
        void EnviarMensajeAlCliente(int remitenteId, int clienteId, NotificacionRequest request);
        List<NotificacionDto> VerNotificacionesRecibidas(int duenoId);

        List<NotificacionDto> VerNotificacionesEnviadas(int duenoId);
    }
}

