using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.Dtos;
using FilmesApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
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

        
        /// <summary>
        /// Retorna os filmes cadastrados no banco
        /// </summary>
        /// <param name="skip">Itens a serem ignorados</param>
        /// <param name="take">Quantidades de itens para trazer</param>
        /// <returns>IActionResult</returns>
        /// <response code="200">Caso retorne com sucesso</response>
        [HttpGet]
        public IEnumerable<ReadMovieDto> GetMovies([FromQuery] int skip = 0, [FromQuery] int take = 15)
        {
            return 
                _mapper.Map<List<ReadMovieDto>>(
                    _context.Movies.Skip(skip).Take(take).ToList()
                    );
        }

        
        /// <summary>
        /// Busca um filme especifico atravez do GUID
        /// </summary>
        /// <param name="uid">UID referente ao filme</param>
        /// <returns>IActionResult</returns>
        /// <response code="200">Caso retorne com sucesso</response>
        [HttpGet("{uid:guid}")]
        public IActionResult GetMovie(Guid uid)
        {
            Movie movie = _context.Movies.FirstOrDefault(movie => movie.Id == uid)!;
            if (movie == null) return NotFound();
            ReadMovieDto movieDto = _mapper.Map<ReadMovieDto>(movie);
            return Ok(movieDto);
        }

        
        /// <summary>
        /// Adiciona um filme ao banco de dados
        /// </summary>
        /// <param name="movieDto">Objeto com os campos necessários para criação de um filme</param>
        /// <returns>IActionResult</returns>
        /// <response code="201">Caso inserção seja feita com sucesso</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [Authorize(Roles = "admin")]
        public IActionResult AddMovie([FromBody] CreateMovieDto movieDto)
        {
            Movie movie = _mapper.Map<Movie>(movieDto);
            _context.Movies.Add(movie);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetMovie), new { uid = movie.Id }, movie);
        }

        
        /// <summary>
        /// Atualiza um filme no banco de dados
        /// </summary>
        /// <param name="uid">UID referente ao filme</param>
        /// <param name="movieDto">Objeto com os campos necessários para atualizar um filme</param>
        /// <returns>IActionResult</returns>
        /// <response code="204">Caso a atualização seja feita com sucesso</response>
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
        
        
        /// <summary>
        /// Atualiza um um parametro do filme no banco de dados
        /// </summary>
        /// <param name="uid">UID referente ao filme</param>
        /// <param name="patch">Objeto com os campos necessários para atualizar um filme por Path</param>
        /// <returns>IActionResult</returns>
        /// <response code="204">Caso a atualização seja feita com sucesso</response>
        [HttpPatch("{uid:guid}")]
        public IActionResult UpdateMoviePatch(Guid uid, JsonPatchDocument<UpdateMovieDto> patch)
        {
            Movie movie = _context.Movies.FirstOrDefault(
                movie => movie.Id == uid)!;
            if (movie == null) return NotFound();

            UpdateMovieDto? movieToUpdate = _mapper.Map<UpdateMovieDto>(movie);
            patch.ApplyTo(movieToUpdate, ModelState);

            if (!TryValidateModel(movieToUpdate)) return ValidationProblem(ModelState);
            
            _mapper.Map(movieToUpdate, movie);
            _context.SaveChanges();
            return NoContent();
        }

        
        /// <summary>
        /// Realiza o delete de um filme no banco de dados
        /// </summary>
        /// <param name="uid">UID referente ao filme</param>
        /// <returns>IActionResult</returns>
        /// <response code="204">Caso o detele seja feita com sucesso</response>
        [HttpDelete("{uid:guid}")]
        public IActionResult DeleteMovie(Guid uid)
        {
            Movie movie = _context.Movies.FirstOrDefault(
                movie => movie.Id == uid)!;
            if (movie == null) return NotFound();

            _context.Remove(movie);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
