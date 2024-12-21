using AutoMapper;
using PromoCodeFactory.Core.Domain.PromoCodeManagement;
using PromoCodeFactory.WebHost.Models.Customer;

namespace PromoCodeFactory.WebHost.Mapping;

public class CustomerMappingProfile : Profile
{
    public CustomerMappingProfile()
    {
        CreateMap<Customer, CustomerShortResponse>();
        CreateMap<Customer, CustomerResponse>()
            .ForMember(z => z.Preferences, map => map.MapFrom(m => m.Preferences))
            .ForMember(z => z.PromoCodes, map => map.MapFrom(m => m.PromoCodes));

    // public List<PreferenceResponse> Preferences { get; set; }
    // public List<PromoCodeShortResponse> PromoCodes { get; set; }
    
    // public class Customer : BaseEntity
    // {//
    //     /// <summary>
    //     ///     Навигационное свойство предпочтения.
    //     /// </summary>
    //     public virtual List<Preference> Preferences { get; set; }
    //
    //     /// <summary>
    //     ///     Навигационное свойство промокод.
    //     /// </summary>
    //     public virtual List<PromoCode> PromoCodes { get; set; }
    // }
    }

}