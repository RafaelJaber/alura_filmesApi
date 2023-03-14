using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.Dtos;
using FilmesApi.Models;
using FilmesApi.Repository.IRepository;
using FluentResults;
using Microsoft.EntityFrameworkCore;

namespace FilmesApi.Repository
{
    public class MovieTheaterRepository : IMovieTheaterRepository
    {
        private readonly MovieContext _context;
        private readonly IMapper _mapper;

        public MovieTheaterRepository(MovieContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        /// <inheritdoc />
        public IEnumerable<ReadMovieTheaterDto> FindAll(int skip = 0, int take = 15)
        {
            return _mapper.Map<List<ReadMovieTheaterDto>>(
                _context.MovieTheaters
                    .ToList()
                    .Skip(skip)
                    .Take(take)
                );
        }

        public IEnumerable<ReadMovieTheaterDto> FindByByAddress(Guid addressUid)
        {
            List<MovieTheater> movieTheaters = _context.MovieTheaters.FromSqlRaw(
                $"SELECT Uid, Name, AddressUid FROM TB_MovieTheataers WHERE AddressUid = {addressUid}")
                .ToList();
            return _mapper.Map<List<ReadMovieTheaterDto>>(movieTheaters);
        }

        /// <inheritdoc />
        public ReadMovieTheaterDto FindById(Guid uid)
        {
            MovieTheater movieTheater = 
                _context.MovieTheaters
                    .FirstOrDefault(theater => theater.Uid == uid)!;
            if (movieTheater == null) return null!;
            return _mapper.Map<ReadMovieTheaterDto>(movieTheater);
        }

        /// <inheritdoc />
        public ReadMovieTheaterDto Create(CreateMovieTheaterDto dto)
        {
            MovieTheater movieTheater = _mapper.Map<MovieTheater>(dto);
            _context.MovieTheaters.Add(movieTheater);
            _context.SaveChanges();
            return _mapper.Map<ReadMovieTheaterDto>(movieTheater);
        }

        /// <inheritdoc />
        public Result Update(Guid uid, UpdateMovieTheaterDto dto)
        {
            MovieTheater movieTheater = _context.MovieTheaters
                .FirstOrDefault(theater => theater.Uid == uid)!;
            if (movieTheater == null) return Result.Fail("Filme não encontrado");
            _mapper.Map(dto, movieTheater);
            _context.SaveChanges();
            return Result.Ok();
        }

        /// <inheritdoc />
        public Result Delete(Guid uid)
        {
            MovieTheater movieTheater = _context.MovieTheaters
                .FirstOrDefault(theater => theater.Uid == uid)!;
            if (movieTheater == null) return Result.Fail("Filme não encontrado");
            _context.Remove(movieTheater);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}
