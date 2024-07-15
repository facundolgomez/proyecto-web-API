using Application.Interfaces;
using Application.Models;
using Application.Models.Requests;
using Domain.Entities;
using Domain.Interfaces;
using AutoMapper;
using Domain.Exceptions;

namespace Application.Services
{
    public class GuarderiaService : IGuarderiaService
    {
        private readonly IRepository<Dueno> _duenoRepository;
        private readonly IGuarderiaRepository _guarderiaRepositorySpecific;
        private readonly IRepository<Guarderia> _guarderiaRepository;
        private readonly IRepository<Reserva> _reservaRepository;
        private readonly IMapper _mapper;

        public GuarderiaService(IRepository<Guarderia> guarderiaRepository, IRepository<Reserva> reservaRepository, IGuarderiaRepository guarderiaRepositorySpecific, IRepository<Dueno> duenoRepository, IMapper mapper)
        {
            _duenoRepository = duenoRepository;
            _guarderiaRepositorySpecific = guarderiaRepositorySpecific; 
            _guarderiaRepository = guarderiaRepository;
            _reservaRepository = reservaRepository;
            _mapper = mapper;
        }

        public GuarderiaDto Create(GuarderiaCreateRequest guarderiaCreateRequest)
        {
            
            var duenoGuarderia = _duenoRepository.GetById(guarderiaCreateRequest.DuenoId);
            if (duenoGuarderia == null)
            {
                throw new NotFoundException($"No se encontró el dueno con el id {guarderiaCreateRequest.DuenoId}");
            }

            
            var guarderia = _mapper.Map<Guarderia>(guarderiaCreateRequest);

            
            guarderia.Dueno = duenoGuarderia;

            
            _guarderiaRepository.Add(guarderia);

            
            var guarderiaDto = _mapper.Map<GuarderiaDto>(guarderia);

            
            guarderiaDto.DuenoNombre = $"{duenoGuarderia.Nombre} {duenoGuarderia.Apellido}";

            return guarderiaDto;
        }

        public void Delete(int id)
        {
            var guarderia = _guarderiaRepository.GetById(id);
            if (guarderia == null)
                throw new NotFoundException($"No se encontró la guardería con el id {id}");

            _guarderiaRepository.Delete(guarderia);
        }

        public List<GuarderiaDto> GetAll()
        {
            var guarderias = _guarderiaRepository.GetAll();
            return _mapper.Map<List<GuarderiaDto>>(guarderias);
        }

        public List<GuarderiaDto> GetAllFullData()
        {
            var guarderias = _guarderiaRepositorySpecific.GetAllFullData();
            return _mapper.Map<List<GuarderiaDto>>(guarderias);
        }


        public GuarderiaDto GetById(int id)
        {
            var guarderia = _guarderiaRepository.GetById(id);
            if (guarderia == null)
                throw new NotFoundException($"No se encontró la guardería con el id {id}");

            return _mapper.Map<GuarderiaDto>(guarderia);
        }

        public void Update(int id, GuarderiaUpdateRequest guarderiaUpdateRequest)
        {
            var guarderia = _guarderiaRepository.GetById(id);
            if (guarderia == null)
                throw new NotFoundException($"No se encontró la guardería con el id {id}");

            _mapper.Map(guarderiaUpdateRequest, guarderia);
            _guarderiaRepository.Update(guarderia);
        }

       
    }

}
