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
            CreateMap<MovieTheater, ReadMovieTheaterDto>();
            CreateMap<CreateMovieTheaterDto, MovieTheater>();
            CreateMap<UpdateMovieTheaterDto, MovieTheater>();
            CreateMap<ReadMovieTheaterDto, MovieTheater>();
        }
    }
}
