using AutoMapper;
using MessmeApi.DTOs;
using MessmeApi.Models;

// Create a mapping profile
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserDto>().ReverseMap();
        CreateMap<HomeData, HomeDataDto>().ReverseMap()
        //formember = models from = dto
        .ForMember(dest => dest.create_date, opt => opt.MapFrom(src => src.create_date))
        .ForMember(dest => dest.update_date, opt => opt.MapFrom(src => src.update_date));
        
    }
}
