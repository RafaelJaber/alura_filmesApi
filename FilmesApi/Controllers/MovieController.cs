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
        public IEnumerable<Movie> GetMovies()
        {
            return Movies;
        }

        [HttpGet("{uid:guid}")]
        public Movie? GetMovie(Guid uid)
        {
            return Movies.FirstOrDefault(movie => movie.Id == uid);
        }
        
        [HttpPost]
        public void AddMovie([FromBody] Movie movie)
        {
            Movies.Add(movie);
            Console.WriteLine(movie.Title);
            Console.WriteLine(movie.Id);
        }
    }
}
