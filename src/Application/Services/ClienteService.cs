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
    public class ClienteService : IClienteService
    {
        private readonly IRepository<Cliente> _clienteRepository;
        public ClienteService(IRepository<Cliente> repository)
        {
            _clienteRepository = repository;
        }

        public List<ClienteDto> GetAll()
        {
            var list = _clienteRepository.GetAll();

            return ClienteDto.CreateList(list);
        }

        public List<Cliente> GetAllFullData()
        {
            return _clienteRepository.GetAll();
        }

        public ClienteDto GetById(int id)
        {
            var obj = _clienteRepository.GetById(id)
            ?? throw new NotFoundException(nameof(Cliente), id);


            var dto = ClienteDto.Create(obj);

            return dto;
        }

        public Cliente Create(ClienteCreateRequest clienteCreateRequest)
        {
            var obj = new Cliente();
            obj.Nombre = clienteCreateRequest.Nombre;
            obj.Apellido = clienteCreateRequest.Apellido;
            obj.Contrasena = clienteCreateRequest.Contrasena;
            obj.Email = clienteCreateRequest.Email;
            obj.NombreUsuario = clienteCreateRequest.NombreUsuario;
            return _clienteRepository.Add(obj);
        }

        public void Update(int id, ClienteUpdateRequest clienteUpdateRequest)
        {

            var obj = _clienteRepository.GetById(id);

            if (obj == null)
                throw new NotFoundException(nameof(Cliente), id);

            if (clienteUpdateRequest.Nombre != string.Empty) obj.Nombre = clienteUpdateRequest.Nombre;

            if (clienteUpdateRequest.Apellido != string.Empty) obj.Apellido = clienteUpdateRequest.Apellido;

            if (clienteUpdateRequest.Email != string.Empty) obj.Email = clienteUpdateRequest.Email;

            if (clienteUpdateRequest.NombreUsuario != string.Empty) obj.NombreUsuario = clienteUpdateRequest.NombreUsuario;

            _clienteRepository.Update(obj);

        }

        public void Delete(int id)
        {
            var obj = _clienteRepository.GetById(id);

            if (obj == null)
                throw new NotFoundException(nameof(Cliente), id);

            _clienteRepository.Delete(obj);
        }

    }
}
