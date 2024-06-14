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
    public class MascotaService : IMascotaService
    {
        private readonly IRepository<Mascota> _mascotaRepository;

        public MascotaService(IRepository<Mascota> repository)
        {
            _mascotaRepository = repository;
        }

        public List<MascotaDto> GetAll()
        {
            var list = _mascotaRepository.GetAll();

            return MascotaDto.CreateList(list);
        }

        public List<Mascota> GetAllFullData()
        {
            return _mascotaRepository.GetAll();
        }

        public MascotaDto GetById(int id)
        {
            var obj = _mascotaRepository.GetById(id)
            ?? throw new NotFoundException(nameof(Mascota), id);


            var dto = MascotaDto.Create(obj);

            return dto;
        }

        public Mascota Create(MascotaCreateRequest mascotaCreateRequest)
        {
            var obj = new Mascota();
            obj.Nombre = mascotaCreateRequest.Nombre;
            obj.tipoMascota = mascotaCreateRequest.TipoMascota;


            return _mascotaRepository.Add(obj);
        }

        public void Update(int id, MascotaUpdateRequest mascotaUpdateRequest)
        {

            var obj = _mascotaRepository.GetById(id);

            if (obj == null)
                throw new NotFoundException(nameof(Mascota), id);

            if (mascotaUpdateRequest.Nombre != string.Empty) obj.Nombre = mascotaUpdateRequest.Nombre;






            _mascotaRepository.Update(obj);

        }

        public void Delete(int id)
        {
            var obj = _mascotaRepository.GetById(id);

            if (obj == null)
                throw new NotFoundException(nameof(Mascota), id);

            _mascotaRepository.Delete(obj);
        }

    }

}