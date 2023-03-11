using AutoMapper;
using FilmesApi.Data.Dtos;
using FilmesApi.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilmesApi.Profiles
{
    [Table("TB_MovieTheater")]
    public class MovieTheaterProfile : Profile
    {
        public MovieTheaterProfile()
        {
            CreateMap<MovieTheater, ReadMovieTheaterDto>()
                .ForMember(dto => dto.AddressDto, opt => 
                    opt.MapFrom(mTheater => mTheater.Address))
                .ForMember(dto => dto.Sessions, opt => 
                    opt.MapFrom(mTheater => mTheater.Sessions));
            CreateMap<CreateMovieTheaterDto, MovieTheater>();
            CreateMap<UpdateMovieTheaterDto, MovieTheater>();
            CreateMap<ReadMovieTheaterDto, MovieTheater>();
        }
    }
}
