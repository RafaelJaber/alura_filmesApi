using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.Dtos;
using FilmesApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        private readonly MovieContext _context;
        private readonly IMapper _mapper;

        public MovieController(MovieContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        
        [HttpGet]
        public IEnumerable<Movie> GetMovies([FromQuery] int skip = 0, [FromQuery] int take = 15)
        {
            return _context.Movies.Skip(skip).Take(take);
        }

        [HttpGet("{uid:guid}")]
        public IActionResult GetMovie(Guid uid)
        {
            Movie movie = _context.Movies.FirstOrDefault(movie => movie.Id == uid)!;
            if (movie == null) return NotFound();
            return Ok(movie);
        }

        [HttpPost]
        public IActionResult AddMovie([FromBody] CreateMovieDto movieDto)
        {
            Movie movie = _mapper.Map<Movie>(movieDto);
            _context.Movies.Add(movie);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetMovie), new { uid = movie.Id }, movie);
        }

        [HttpPut("{uid:guid}")]
        public IActionResult UpdateMovie(Guid uid, [FromBody] UpdateMovieDto movieDto)
        {
            Movie movie = _context.Movies.FirstOrDefault(
                movie => movie.Id == uid)!;
            if (movie == null) return NotFound();
            _mapper.Map(movieDto, movie);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
