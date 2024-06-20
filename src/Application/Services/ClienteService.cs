using Application.Interfaces;
using Application.Models;
using Application.Models.Requests;
using AutoMapper;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Interfaces;

namespace Application.Services
{
    public class ClienteService : IClienteService
    {
        private readonly GenericService<Cliente, ClienteCreateRequest, ClienteUpdateRequest, ClienteDto> _genericService;
        private readonly IRepository<Mascota> _mascotaRepository;

        public ClienteService(IRepository<Cliente> repository, IRepository<Mascota> mascotaRepository, IMapper mapper)
        {
            _genericService = new GenericService<Cliente, ClienteCreateRequest, ClienteUpdateRequest, ClienteDto>(repository, mapper);
            _mascotaRepository = mascotaRepository;
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

        public void AsignarMascota(int clienteId, int mascotaId)
        {
            var cliente = _genericService.GetById(clienteId);
            if (cliente == null)
                throw new NotFoundException($"No se encontro el cliente con el id {clienteId}");

            var mascota = _mascotaRepository.GetById(mascotaId);
            if (mascota == null)
                throw new NotFoundException($"No se encontro la mascota con el id {mascotaId}");

            // asociamos la mascota al cliente
            mascota.ClienteId = clienteId;
            _mascotaRepository.Update(mascota);

        }
    }
}
