using AutoMapper;
using PromoCodeFactory.Core.Domain.PromoCodeManagement;
using PromoCodeFactory.WebHost.Models.Preference;

namespace PromoCodeFactory.WebHost.Mapping;

public class PreferenceMappingProfile : Profile
{
    public PreferenceMappingProfile()
    {
        CreateMap<Preference, PreferenceResponse>();
    }
}