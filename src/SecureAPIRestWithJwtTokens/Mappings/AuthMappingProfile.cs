using AutoMapper;
using SecureAPIRestWithJwtTokens.Models.DTO;
using SecureAPIRestWithJwtTokens.Models.Entities;

namespace SecureAPIRestWithJwtTokens.Mappings
{
    /// <summary>
    /// Perfil de mapeo para autenticación y usuarios
    /// </summary>
    public class AuthMappingProfile : Profile
    {
        public AuthMappingProfile()
        {
            // Mapeo de Usuario a UserInfo
            CreateMap<Usuario, UserInfoDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.UsrId))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UsrLogin))
                .ForMember(dest => dest.PerfilId, opt => opt.MapFrom(src => src.PeaId))
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => 
                    !string.IsNullOrEmpty(src.UsrNombre) ? src.UsrNombre : src.UsrLogin));
        }
    }
}