using AutoMapper;
using FilmesApi.Data.Dtos;
using FilmesApi.Models;
using FilmesApi.Repository.IRepository;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieTheaterController : ControllerBase
    {
        private readonly IMovieTheaterRepository _repository;
        private readonly IMapper _mapper;
        
        public MovieTheaterController(IMovieTheaterRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        
        /// <summary>
        /// Retorna os cinemas cadastrados no banco
        /// </summary>
        /// <param name="skip">Itens a serem ignorados</param>
        /// <param name="take">Quantidades de itens para trazer</param>
        /// <returns>IActionResult</returns>
        /// <response code="200">Caso retorne com sucesso</response>
        [HttpGet]
        public IEnumerable<ReadMovieTheaterDto> FindAll([FromQuery] int skip = 0, [FromQuery] int take = 15)
        {
            return _repository.FindAll(skip, take);
        }

        [HttpGet("{AddressUid:guid}")]
        public IEnumerable<ReadMovieTheaterDto> FindByAdress(Guid addressUid)
        {
            return _repository.FindByByAddress(addressUid);
        }
        
        /// <summary>
        /// Busca um cinema especifico atravez do GUID
        /// </summary>
        /// <param name="uid">UID referente ao cinema</param>
        /// <returns>IActionResult</returns>
        /// <response code="200">Caso retorne com sucesso</response>
        [HttpGet("{uid:guid}")]
        public IActionResult FindById(Guid uid)
        {
            ReadMovieTheaterDto? movieDto = _repository.FindById(uid);
            if (movieDto == null) return NotFound();
            return Ok(movieDto);
        }
        
        /// <summary>
        /// Adiciona um cinema ao banco de dados
        /// </summary>
        /// <param name="dto">Objeto com os campos necessários para criação de um cinema</param>
        /// <returns>IActionResult</returns>
        /// <response code="201">Caso inserção seja feita com sucesso</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult AddMovie([FromBody] CreateMovieTheaterDto dto)
        {
            ReadMovieTheaterDto movieTheaterDto = _repository.Create(dto);
            return CreatedAtAction(nameof(FindById), new { uid = movieTheaterDto.Uid }, movieTheaterDto);
        }
        
        /// <summary>
        /// Atualiza um cinema no banco de dados
        /// </summary>
        /// <param name="uid">UID referente ao cinema</param>
        /// <param name="movieTheaterDto">Objeto com os campos necessários para atualizar um cinema</param>
        /// <returns>IActionResult</returns>
        /// <response code="204">Caso a atualização seja feita com sucesso</response>
        [HttpPut("{uid:guid}")]
        public IActionResult UpdateMovie(Guid uid, [FromBody] UpdateMovieTheaterDto movieTheaterDto)
        {
            bool state = _repository.Update(uid, movieTheaterDto);
            if (state) return NoContent();
            return NotFound();
        }
        
        /// <summary>
        /// Atualiza um um parametro do cinema no banco de dados
        /// </summary>
        /// <param name="uid">UID referente ao cinema</param>
        /// <param name="patch">Objeto com os campos necessários para atualizar um cinema por Path</param>
        /// <returns>IActionResult</returns>
        /// <response code="204">Caso a atualização seja feita com sucesso</response>
        [HttpPatch("{uid:guid}")]
        public IActionResult UpdatePatch(Guid uid, JsonPatchDocument<UpdateMovieTheaterDto> patch)
        {
            ReadMovieTheaterDto movieTheaterDto = _repository.FindById(uid);
            if (movieTheaterDto == null) return NotFound();

            UpdateMovieTheaterDto? mTheater = _mapper.Map<UpdateMovieTheaterDto>(movieTheaterDto);
            
            patch.ApplyTo(mTheater, ModelState);
            if (!TryValidateModel(mTheater)) return ValidationProblem(ModelState);
        
            _repository.Update(uid, mTheater);
            return NoContent();
        }
        
        /// <summary>
        /// Realiza o delete de um cinema no banco de dados
        /// </summary>
        /// <param name="uid">UID referente ao cinema</param>
        /// <returns>IActionResult</returns>
        /// <response code="204">Caso o detele seja feita com sucesso</response>
        [HttpDelete("{uid:guid}")]
        public IActionResult DeleteMovie(Guid uid)
        {
            bool state = _repository.Delete(uid);
            if (state) return NoContent();
            return BadRequest();
        }
    }
}
