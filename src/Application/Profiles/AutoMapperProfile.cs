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
            //cuando AutoMapper encuentra un objeto ClienteCreateRequest debe mapearlo a un entidad Cliente
            //asi funciona desde cada origen a destino
            CreateMap<ClienteCreateRequest, Cliente>();
            CreateMap<ClienteUpdateRequest, Cliente>();
            CreateMap<Cliente, ClienteDto>()
                .ForMember(dest => dest.Mascotas, opt => opt.MapFrom(src => src.Mascotas));

            CreateMap<DuenoCreateRequest, Dueno>();
            CreateMap<DuenoUpdateRequest, Dueno>();
            CreateMap<Dueno, DuenoDto>();

            CreateMap<GuarderiaCreateRequest, Guarderia>();
            CreateMap<GuarderiaUpdateRequest, Guarderia>();
            CreateMap<Guarderia, GuarderiaDto>()
                .ForMember(dest => dest.DuenoNombre, opt => opt.MapFrom(src => src.Dueno != null ? $"{src.Dueno.Nombre} {src.Dueno.Apellido}" : string.Empty))
                .ForMember(dest => dest.CantidadReservas, opt => opt.MapFrom(src => src.Reservas != null ? src.Reservas.Count : 0));


            CreateMap<MascotaCreateRequest, Mascota>();
            CreateMap<MascotaUpdateRequest, Mascota>();
            CreateMap<Mascota, MascotaDto>()
            .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.Nombre));

            CreateMap<ReservaCreateRequest, Reserva>();
            CreateMap<ReservaUpdateRequest, Reserva>();
            CreateMap<Reserva, ReservaDto>()
            .ForMember(dest => dest.TipoMascota, opt => opt.MapFrom(src => src.Mascota.TipoMascota));

            CreateMap<Notificacion, NotificacionDto>();
        }
    }
    
}
