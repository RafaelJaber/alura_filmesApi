using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.Dtos;
using FilmesApi.Models;
using FilmesApi.Repository.IRepository;

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
        public bool Update(Guid uid, UpdateMovieTheaterDto dto)
        {
            MovieTheater movieTheater = _context.MovieTheaters
                .FirstOrDefault(theater => theater.Uid == uid)!;
            if (movieTheater == null) return false;
            _mapper.Map(dto, movieTheater);
            _context.SaveChanges();
            return true;
        }

        /// <inheritdoc />
        public bool Delete(Guid uid)
        {
            MovieTheater movieTheater = _context.MovieTheaters
                .FirstOrDefault(theater => theater.Uid == uid)!;
            if (movieTheater == null) return false;
            _context.Remove(movieTheater);
            _context.SaveChanges();
            return true;
        }
    }
}
