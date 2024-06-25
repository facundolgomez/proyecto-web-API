using Domain.Entities;
using Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Application.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class NotificacionRepository : INotificacionRepository
    {
        private readonly ApplicationContext _context;

        public NotificacionRepository(ApplicationContext context)
        {
            _context = context;
        }

        public Notificacion Add(Notificacion entity)
        {
            _context.Notificaciones.Add(entity);
            SaveChanges();
            return entity;
        }

        public void Delete(Notificacion entity)
        {
            _context.Notificaciones.Remove(entity);
            SaveChanges();
        }

        public List<Notificacion> GetAll()
        {
            return _context.Notificaciones.ToList();
        }

        public Notificacion GetById(int id)
        {
            return _context.Notificaciones.Find(id);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Update(Notificacion entity)
        {
            _context.Notificaciones.Update(entity);
            SaveChanges();
        }

        public List<Notificacion> GetByUsuarioId(int usuarioId)
        {
            return _context.Notificaciones.Where(n => n.UsuarioId == usuarioId).ToList();
        }
    }
}

