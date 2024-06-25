using Application.Models;
using Application.Models.Requests;
using Domain.Entities;
using Domain.Enums;
using System.Collections.Generic;

namespace Application.Interfaces
{
    //IClienteService hereda de la interfaz IService, esto lo hice 
    //porque era necesario agregar metodos especificos mas allá de los genéricos
    //(en este caso para cliente)
    public interface IClienteService : IService<Cliente, ClienteCreateRequest, ClienteUpdateRequest, ClienteDto>
    {
        void AsignarMascota(int clienteId, int mascotaId);
        ReservaDto SolicitarReserva(int clienteId, ReservaCreateRequest reservaCreateRequest);
        void CancelarReserva(int reservaId);
        void EnviarMensajeAlDueno(int reservaId, string mensaje);
        List<NotificacionDto> VerNotificaciones(int clienteId);
    }
}
