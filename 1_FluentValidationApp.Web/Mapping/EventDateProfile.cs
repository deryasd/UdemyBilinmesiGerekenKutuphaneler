using _1_FluentValidationApp.Web.DTOs;
using _1_FluentValidationApp.Web.Models;
using AutoMapper;

namespace _1_FluentValidationApp.Web.Mapping
{
    public class EventDateProfile:Profile
    {
        public EventDateProfile()
        {
            CreateMap<EventDateDTO, EventDate>()
                 .ForMember(dest => dest.Date, opt => opt.MapFrom(src =>
                    (src.Year > 1 && src.Month > 0 && src.Day > 0)
                        ? new DateTime(src.Year, src.Month, src.Day)
                        : DateTime.MinValue 
    ));

            CreateMap<EventDate, EventDateDTO>()
                .ForMember(dest => dest.Year, opt => opt.MapFrom(src => src.Date.Year))
                .ForMember(dest => dest.Month, opt => opt.MapFrom(src => src.Date.Month))
                .ForMember(dest => dest.Day, opt => opt.MapFrom(src => src.Date.Day));

        }
    }
}
