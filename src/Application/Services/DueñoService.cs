using Application.Interfaces;
using Application.Models;
using Application.Models.Requests;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class DueñoService : IDueñoService
    {
        private readonly IDueñoRepository _dueñoRepository;

        public DueñoService(IDueñoRepository repository)
        {
            _dueñoRepository = repository;
        }

        public List<DueñoDto> GetAll()
        {
            var list = _dueñoRepository.GetAll();

            return DueñoDto.CreateList(list);
        }

        public List<Dueño> GetAllFullData()
        {
            return _dueñoRepository.GetAll();
        }

        public DueñoDto GetById(int id)
        {
            var obj = _dueñoRepository.GetById(id)
            ?? throw new NotFoundException(nameof(Dueño), id);


            var dto = DueñoDto.Create(obj);

            return dto;
        }

        public Dueño Create(DueñoCreateRequest dueñoCreateRequest)
        {
            var obj = new Dueño();
            obj.Nombre = dueñoCreateRequest.Nombre;
            obj.Apellido = dueñoCreateRequest.Apellido;
            obj.Contraseña = dueñoCreateRequest.Contraseña;
            obj.Email = dueñoCreateRequest.Email;
            obj.NombreUsuario = dueñoCreateRequest.NombreUsuario;
            return _dueñoRepository.Add(obj);
        }

        public void Update(int id, DueñoUpdateRequest dueñoUpdateRequest)
        {

            var obj = _dueñoRepository.GetById(id);

            if (obj == null)
                throw new NotFoundException(nameof(Dueño), id);

            if (dueñoUpdateRequest.Nombre != string.Empty) obj.Nombre = dueñoUpdateRequest.Nombre;

            if (dueñoUpdateRequest.Apellido != string.Empty) obj.Apellido = dueñoUpdateRequest.Apellido;

            if (dueñoUpdateRequest.Email != string.Empty) obj.Email = dueñoUpdateRequest.Email;

            if (dueñoUpdateRequest.NombreUsuario != string.Empty) obj.NombreUsuario = dueñoUpdateRequest.NombreUsuario;

            _dueñoRepository.Update(obj);

        }

        public void Delete(int id)
        {
            var obj = _dueñoRepository.GetById(id);

            if (obj == null)
                throw new NotFoundException(nameof(Dueño), id);

            _dueñoRepository.Delete(obj);
        }

    }
}
