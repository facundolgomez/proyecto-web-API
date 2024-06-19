using Application.Interfaces;
using Application.Models;
using Application.Models.Requests;
using Domain.Entities;
using Domain.Interfaces;
using AutoMapper;

namespace Application.Services
{ 
    public class ReservaService : IService<Reserva, ReservaCreateRequest, ReservaUpdateRequest, ReservaDto>
    {
        private readonly GenericService<Reserva, ReservaCreateRequest, ReservaUpdateRequest, ReservaDto> _genericService;

        public ReservaService(IRepository<Reserva> repository, IMapper mapper)
        {
            _genericService = new GenericService<Reserva, ReservaCreateRequest, ReservaUpdateRequest, ReservaDto>(repository, mapper);
        }

        public ReservaDto Create(ReservaCreateRequest reservaCreateRequest)
        {
            return _genericService.Create(reservaCreateRequest);
        }

        public void Delete(int id)
        {
            _genericService.Delete(id);
        }

        public List<ReservaDto> GetAll()
        {
            return _genericService.GetAll();
        }

        public List<Reserva> GetAllFullData()
        {
            return _genericService.GetAllFullData();
        }

        public ReservaDto GetById(int id)
        {
            return _genericService.GetById(id);
        }

        public void Update(int id, ReservaUpdateRequest reservaUpdateRequest)
        {
            _genericService.Update(id, reservaUpdateRequest);
        }
    }
}