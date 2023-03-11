using AutoMapper;
using FilmesApi.Data.Dtos;
using FilmesApi.Models;

namespace FilmesApi.Profiles
{
    public class AddressProfile : Profile
    {
        public AddressProfile()
        {
            CreateMap<CreateAddressDto, Address>();
            CreateMap<UpdateAddressDto, Address>();
            CreateMap<Address, ReadAddressDto>();
            CreateMap<ReadAddressDto, Address>();
        }
    }
}
