using Application.Models;
using Application.Models.Requests;
using Domain.Entities;
using Domain.Enums;
using System.Collections.Generic;

namespace Application.Interfaces
{
    
    public interface IClienteService
    {
        ClienteDto Create(ClienteCreateRequest clienteCreateRequest);
        void Delete(int id);
        List<ClienteDto> GetAll();
        List<ClienteDto> GetClientsWithPets();
        ClienteDto GetById(int id);
        void Update(int id, ClienteUpdateRequest clienteUpdateRequest);


        void AsignarMascota(int clienteId, int mascotaId);
        ReservaDto CrearReserva(int mascotaId, ReservaCreateRequest reservaCreateRequest);
        void CancelarReserva(int reservaId);
        void EnviarMensajeAlDueno(int remitenteId, int duenoId,string mensaje);
        List<NotificacionDto> VerNotificaciones(int clienteId);

        
    }
}
