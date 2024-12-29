using AutoMapper;
using PromoCodeFactory.Core.Domain.PromoCodeManagement;
using PromoCodeFactory.WebHost.Models.Promocode;

namespace PromoCodeFactory.WebHost.Mapping;

public class PromoCodeMappingProfile  : Profile
{
    public PromoCodeMappingProfile()
    {
        CreateMap<PromoCode, PromoCodeShortResponse>()
            .ForMember(z => z.BeginDate, map => map.MapFrom(src => src.BeginDate.ToString("dd.MM.yyyy HH:mm")))
            .ForMember(z => z.EndDate, map => map.MapFrom(src => src.EndDate.ToString("dd.MM.yyyy HH:mm")))
            .ReverseMap();
    }
}