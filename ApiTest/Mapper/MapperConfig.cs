using ApiTest.DTO;
using ApiTest.Entities;
using AutoMapper;

namespace ApiTest.Mapper
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<TipoIdentificacion, TipoIdentificacionDTO>().ReverseMap();
            
            CreateMap<Persona, PersonaDTO>()
                .ForMember(dest => dest.NombreCompleto, opt => opt.MapFrom(src => src.NombreCompleto))
                .ForMember(dest => dest.TipoIdentificacion, opt => opt.MapFrom(src => src.TipoIdentificacion.Nombre));
        }
    }
}
