using AutoMapper;
using SecureAPIRestWithJwtTokens.Models.DTO;
using SecureAPIRestWithJwtTokens.Models.InternalDTO;

namespace SecureAPIRestWithJwtTokens.Mappings
{
    public class FarmaciaStockProfile : Profile
    {
        public FarmaciaStockProfile()
        {
            // Mapeo de FarmaciaStock a StockFarmaciasResponse
            CreateMap<FarmaciaStock, StockFarmaciaDto>()
                .ForMember(dest => dest.IdFarmacia, opt => opt.MapFrom(src => src.IdFarmacia))
                .ForMember(dest => dest.Descripcion, opt => opt.MapFrom(src => src.Descripcion))
                .ForMember(dest => dest.Direccion, opt => opt.MapFrom(src => src.Direccion))
                .ForMember(dest => dest.Stock, opt => opt.MapFrom(src => src.Stock));
        }
    }
}
