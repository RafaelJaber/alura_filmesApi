using AutoMapper;
using FilmesApi.Data.Dtos;
using FilmesApi.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Controllers
{
    /// <inheritdoc />
    [ApiController]
    [Route("[controller]")]
    public class SessionController : ControllerBase
    {
        private readonly ISessionRepository _repository;
        private readonly IMapper _mapper;

        /// <inheritdoc />
        public SessionController(ISessionRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        /// <summary>
        /// Retorna as sessões cadastradas no banco
        /// </summary>
        /// <param name="skip">Itens a serem ignorados</param>
        /// <param name="take">Quantidades de itens para trazer</param>
        /// <returns>IActionResult</returns>
        /// <response code="200">Caso retorne com sucesso</response>
        [HttpGet]
        [HttpGet]
        public IEnumerable<ReadSessionDto> FindAll([FromQuery] int skip = 0, [FromQuery] int take = 15)
        {
            return _repository.FindAll(skip, take);
        }

        /// <summary>
        /// Busca uma sessão especifica atravez do GUID
        /// </summary>
        /// <param name="uid">UID referente a sessão</param>
        /// <returns>IActionResult</returns>
        /// <response code="200">Caso retorne com sucesso</response>
        [HttpGet("{uid:guid}")]
        public IActionResult FindById(Guid uid)
        {
            ReadSessionDto? sessionDto = _repository.FindById(uid);
            if (sessionDto == null) return NotFound();
            return Ok(sessionDto);
        }

        /// <summary>
        /// Adiciona uma sessão ao banco de dados
        /// </summary>
        /// <param name="dto">Objeto com os campos necessários para criação de uma sessão</param>
        /// <returns>IActionResult</returns>
        /// <response code="201">Caso inserção seja feita com sucesso</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult Create([FromBody] CreateSessionDto dto)
        {
            ReadSessionDto sessionDto = _repository.Create(dto);
            return CreatedAtAction(nameof(FindById), new { uid = sessionDto.Uid, sessionDto });
        }
    }
}
