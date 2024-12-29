using AutoMapper;
using PromoCodeFactory.Core.Domain.PromoCodeManagement;
using PromoCodeFactory.WebHost.Models.Customer;


namespace PromoCodeFactory.WebHost.Mapping;

public class CustomerMappingProfile : Profile
{
    public CustomerMappingProfile()
    {
        CreateMap<Customer, CustomerShortResponse>();
        CreateMap<Customer, CustomerResponse>();
    }
}