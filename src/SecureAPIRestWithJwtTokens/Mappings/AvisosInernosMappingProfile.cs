using AutoMapper;
using SecureAPIRestWithJwtTokens.Models.DTO;
using SecureAPIRestWithJwtTokens.Models.Entities;

namespace SecureAPIRestWithJwtTokens.Mappings
{
    public class AvisosInernosMappingProfile : Profile
    {
        public AvisosInernosMappingProfile()
        {
            CreateMap<AvisoInterno, AvisoInternoDto>()
                .ForMember(dest => dest.IdAviso, opt => opt.MapFrom(src => src.AviId))
                //.ForMember(dest => dest.Emisor, opt => opt.MapFrom(src => src.Emisor))
                .ForMember(dest => dest.Importancia, opt => opt.MapFrom(src => src.AviImportancia))
                .ForMember(dest => dest.Recibido, opt => opt.MapFrom(src => src.AviFecha))
                .ForMember(dest => dest.IdProceso, opt => opt.MapFrom(src => src.ProId))
                .ForMember(dest => dest.Proceso, opt => opt.MapFrom(src => src.Proceso.ProNombre ?? string.Empty))
                .ForMember(dest => dest.Asunto, opt => opt.MapFrom(src => src.AviAsunto))
                .ForMember(dest => dest.Visto, opt => opt.MapFrom(src => src.AviVisto ? "Si" : "No"));
        }

    }
}