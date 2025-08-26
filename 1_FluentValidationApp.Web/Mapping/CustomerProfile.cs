using _1_FluentValidationApp.Web.DTOs;
using _1_FluentValidationApp.Web.Models;
using AutoMapper;

namespace _1_FluentValidationApp.Web.Mapping
{
    public class CustomerProfile:Profile
    {
        public CustomerProfile()
        {
            CreateMap<CreditCard, CustomerDto>();
            CreateMap<Customer, CustomerDto>()
                .IncludeMembers(x=>x.CreditCard)
                .ForMember(dest => dest.Isim, opt => opt.MapFrom(x => x.Name))
                .ForMember(dest => dest.Eposta, opt => opt.MapFrom(x => x.Email))
                .ForMember(dest => dest.Yas, opt => opt.MapFrom(x => x.Age));
              
        }
    }
}

