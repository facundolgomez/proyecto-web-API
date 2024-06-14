using AutoMapper;
using Application.Models;
using Application.Models.Requests;
using Domain.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Application.Profiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ClienteCreateRequest, Cliente>();
            CreateMap<ClienteUpdateRequest, Cliente>();
            CreateMap<Cliente, ClienteDto>();
            
            CreateMap<DuenoCreateRequest, Guarderia>();
            CreateMap<DuenoUpdateRequest, Guarderia>();
            CreateMap<Guarderia, DuenoDto>();

            CreateMap<GuarderiaCreateRequest, Guarderia>();
            CreateMap<GuarderiaUpdateRequest, Guarderia>();
            CreateMap<Guarderia, GuarderiaDto>();

            CreateMap<MascotaCreateRequest, Mascota>();
            CreateMap<MascotaUpdateRequest, Mascota>();
            CreateMap<Mascota, MascotaDto>();
        }
    }
}
