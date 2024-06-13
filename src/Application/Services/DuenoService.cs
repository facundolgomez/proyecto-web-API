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
    public class DuenoService : IDuenoService
    {
        private readonly IDuenoRepository _duenoRepository;

        public DuenoService(IDuenoRepository repository)
        {
            _duenoRepository = repository;
        }

        public List<DuenoDto> GetAll()
        {
            var list = _duenoRepository.GetAll();

            return DuenoDto.CreateList(list);
        }

        public List<Dueno> GetAllFullData()
        {
            return _duenoRepository.GetAll();
        }

        public DuenoDto GetById(int id)
        {
            var obj = _duenoRepository.GetById(id)
            ?? throw new NotFoundException(nameof(Dueno), id);


            var dto = DuenoDto.Create(obj);

            return dto;
        }

        public Dueno Create(DuenoCreateRequest duenoCreateRequest)
        {
            var obj = new Dueno();
            obj.Nombre = duenoCreateRequest.Nombre;
            obj.Apellido = duenoCreateRequest.Apellido;
            obj.Contrasena = duenoCreateRequest.Contrasena;
            obj.Email = duenoCreateRequest.Email;
            obj.NombreUsuario = duenoCreateRequest.NombreUsuario;
            return _duenoRepository.Add(obj);
        }

        public void Update(int id, DuenoUpdateRequest duenoUpdateRequest)
        {

            var obj = _duenoRepository.GetById(id);

            if (obj == null)
                throw new NotFoundException(nameof(Dueno), id);

            if (duenoUpdateRequest.Nombre != string.Empty) obj.Nombre = duenoUpdateRequest.Nombre;

            if (duenoUpdateRequest.Apellido != string.Empty) obj.Apellido = duenoUpdateRequest.Apellido;

            if (duenoUpdateRequest.Email != string.Empty) obj.Email = duenoUpdateRequest.Email;

            if (duenoUpdateRequest.NombreUsuario != string.Empty) obj.NombreUsuario = duenoUpdateRequest.NombreUsuario;

            _duenoRepository.Update(obj);

        }

        public void Delete(int id)
        {
            var obj = _duenoRepository.GetById(id);

            if (obj == null)
                throw new NotFoundException(nameof(Dueno), id);

            _duenoRepository.Delete(obj);
        }

    }
}
