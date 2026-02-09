using AutoMapper;
using SecureAPIRestWithJwtTokens.Models.DTO;
using SecureAPIRestWithJwtTokens.Models.Entities;

namespace SecureAPIRestWithJwtTokens.Mappings
{
    /// <summary>
    /// Perfil de mapeo para entidades geográficas
    /// </summary>
    public class GeografiaMappingProfile : Profile
    {
        /// <summary>
        /// Perfiles
        /// </summary>
        public GeografiaMappingProfile()
        {
            // Mapeo de Pais a PaisDto
            CreateMap<Pais, PaisDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.PaiId))
                .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.PaiNombre));

            // Mapeo de ComunidadAut a ComunidadAutResponse
            CreateMap<ComunidadAut, ComunidadAutDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.CauId))
                .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.CauNombre))
                .ForMember(dest => dest.IdPais, opt => opt.MapFrom(src => src.PaiId))
                .ForMember(dest => dest.ExencionIVA, opt => opt.MapFrom(src => src.CauExencionIva))
                .ForMember(dest => dest.ComunidadConsejoId, opt => opt.MapFrom(src => src.CauConsejo));

            // Mapeo de Provincia a ProvinciaResponse
            CreateMap<Provincia, ProvinciaDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.PrvId))
                .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.PrvNombre))
                .ForMember(dest => dest.IdComunidadAut, opt => opt.MapFrom(src => src.CauId))
                .ForMember(dest => dest.IdPais, opt => opt.MapFrom(src => src.PaiId));

            // Mapeo de Poblacion a PoblacionResponse
            CreateMap<Poblacion, PoblacionDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.PobId))
                .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.PobNombre))
                .ForMember(dest => dest.IdProvincia, opt => opt.MapFrom(src => src.PrvId    ))
                .ForMember(dest => dest.IdPais, opt => opt.MapFrom(src => src.PaiId));
        }
    }
}