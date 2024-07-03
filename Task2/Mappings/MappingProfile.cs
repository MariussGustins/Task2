using AutoMapper;
using Task2.Models;
using Task2.DTOs;

namespace Task2.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Resident, ResidentDto>().ReverseMap();
            CreateMap<House, HouseDto>().ReverseMap();
            CreateMap<Apartment, ApartmentDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();

        }
    }
}