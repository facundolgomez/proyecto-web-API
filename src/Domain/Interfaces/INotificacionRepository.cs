using Domain.Entities;
using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface INotificacionRepository
    {
        Notificacion Add(Notificacion notificacion);
        void Update(Notificacion notificacion);
        Notificacion GetById(int id);
        List<Notificacion> GetByUsuarioId(int usuarioId);
        void SaveChanges();
    }
}
