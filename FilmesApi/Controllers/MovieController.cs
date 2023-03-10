using FilmesApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        private static readonly List<Movie> Movies = new List<Movie>();


        [HttpGet]
        public IEnumerable<Movie> GetMovies([FromQuery] int skip = 0, [FromQuery] int take = 15)
        {
            return Movies.Skip(skip).Take(take);
        }

        [HttpGet("{uid:guid}")]
        public IActionResult GetMovie(Guid uid)
        {
            Movie movie = Movies.FirstOrDefault(movie => movie.Id == uid);
            if (movie == null) return NotFound();
            return Ok(movie);
        }
        
        [HttpPost]
        public IActionResult AddMovie([FromBody] Movie movie)
        {
            Movies.Add(movie);
            return CreatedAtAction(nameof(GetMovie), new { uid = movie.Id }, movie);
        }
    }
}
