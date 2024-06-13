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
    public class GuarderiaService : IGuarderiaService 
    {
         private readonly IGuarderiaRepository _guarderiaRepository;

        public GuarderiaService(IGuarderiaRepository repository)
        {
            _guarderiaRepository = repository;
        }

        public List<GuarderiaDto> GetAll()
        {
            var list = _guarderiaRepository.GetAll();

            return GuarderiaDto.CreateList(list);
        }

        public List<Guarderia> GetAllFullData()
        {
            return _guarderiaRepository.GetAll();
        }

        public GuarderiaDto GetById(int id)
        {
            var obj = _guarderiaRepository.GetById(id)
            ?? throw new NotFoundException(nameof(Guarderia), id);


            var dto = GuarderiaDto.Create(obj);

            return dto;
        }

        public Guarderia Create(GuarderiaCreateRequest guarderiaCreateRequest)
        {
            var obj = new Guarderia();
            obj.Nombre = guarderiaCreateRequest.Nombre;
            obj.Direccion = guarderiaCreateRequest.Direccion;
            
            
            return _guarderiaRepository.Add(obj);
        }

        public void Update(int id, GuarderiaUpdateRequest guarderiaUpdateRequest)
        {

            var obj = _guarderiaRepository.GetById(id);

            if (obj == null)
                throw new NotFoundException(nameof(guarderia), id);

            if (guarderiaUpdateRequest.Nombre != string.Empty) obj.Nombre = guarderiaUpdateRequest.Nombre;

            if (guarderiaUpdateRequest.Direccion != string.Empty) obj.Direccion = guarderiaUpdateRequest.Direccion;

            

            

            _guarderiaRepository.Update(obj);

        }

        public void Delete(int id)
        {
            var obj = _guarderiaRepository.GetById(id);

            if (obj == null)
                throw new NotFoundException(nameof(Guarderia), id);

            _guarderiaRepository.Delete(obj);
        }

    }

    }
}