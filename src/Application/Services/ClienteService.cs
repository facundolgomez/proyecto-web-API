using Application.Interfaces;
using Application.Models;
using Application.Models.Requests;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class ClienteService : IService<Cliente, ClienteCreateRequest, ClienteUpdateRequest, ClienteDto>
    {
        private readonly GenericService<Cliente, ClienteCreateRequest, ClienteUpdateRequest, ClienteDto> _genericService;

        public ClienteService(IRepository<Cliente> repository, IMapper mapper)
        {
            _genericService = new GenericService<Cliente, ClienteCreateRequest, ClienteUpdateRequest, ClienteDto>(repository, mapper);
        }

        public ClienteDto Create(ClienteCreateRequest clienteCreateRequest)
        {
            return _genericService.Create(clienteCreateRequest);
        }

        public void Delete(int id)
        {
            _genericService.Delete(id);
        }

        public List<ClienteDto> GetAll()
        {
            return _genericService.GetAll();
        }

        public List<Cliente> GetAllFullData()
        {
            return _genericService.GetAllFullData();
        }

        public ClienteDto GetById(int id)
        {
            return _genericService.GetById(id);
        }

        public void Update(int id, ClienteUpdateRequest clienteUpdateRequest)
        {
            _genericService.Update(id, clienteUpdateRequest);
        }
    }
}
