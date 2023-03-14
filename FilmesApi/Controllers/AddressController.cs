using AutoMapper;
using FilmesApi.Data.Dtos;
using FilmesApi.Repository.IRepository;
using FluentResults;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Controllers
{
    /// <inheritdoc />
    [ApiController]
    [Route("[controller]")]
    public class AddressController : ControllerBase
    {
        private readonly IAddressRepository _repository;
        private readonly IMapper _mapper;
        /// <inheritdoc />
        public AddressController(IAddressRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        
        /// <summary>
        /// Retorna os endereços cadastrados no banco
        /// </summary>
        /// <param name="skip">Itens a serem ignorados</param>
        /// <param name="take">Quantidades de itens para trazer</param>
        /// <returns>IActionResult</returns>
        /// <response code="200">Caso retorne com sucesso</response>
        [HttpGet]
        public IEnumerable<ReadAddressDto> FindAll([FromQuery] int skip = 0, [FromQuery] int take = 15)
        {
            return _repository.FindAll(skip, take);
        }
        
        /// <summary>
        /// Busca um endereço especifico atravez do GUID
        /// </summary>
        /// <param name="uid">UID referente ao cinema</param>
        /// <returns>IActionResult</returns>
        /// <response code="200">Caso retorne com sucesso</response>
        [HttpGet("{uid:guid}")]
        public IActionResult FindById(Guid uid)
        {
            ReadAddressDto? addressDto = _repository.FindById(uid);
            if (addressDto == null) return NotFound();
            return Ok(addressDto);
        }
        
        /// <summary>
        /// Adiciona um endereço ao banco de dados
        /// </summary>
        /// <param name="dto">Objeto com os campos necessários para criação de um endereço</param>
        /// <returns>IActionResult</returns>
        /// <response code="201">Caso inserção seja feita com sucesso</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult AddMovie([FromBody] CreateAddressDto dto)
        {
            ReadAddressDto addressDto = _repository.Create(dto);
            return CreatedAtAction(nameof(FindById), new { uid = addressDto.Uid }, addressDto);
        }

        /// <summary>
        /// Atualiza um endereço no banco de dados
        /// </summary>
        /// <param name="uid">UID referente ao endereço</param>
        /// <param name="dto">Objeto com os campos necessários para atualizar um endereço</param>
        /// <returns>IActionResult</returns>
        /// <response code="204">Caso a atualização seja feita com sucesso</response>
        [HttpPut("{uid:guid}")]
        public IActionResult UpdateAddress(Guid uid, [FromBody] UpdateAddressDto dto)
        {
            Result state = _repository.Update(uid, dto);
            if (state.IsFailed) return NotFound(state.Errors);
            return NoContent();
        }
        
        /// <summary>
        /// Atualiza um um parametro do endereço no banco de dados
        /// </summary>
        /// <param name="uid">UID referente ao endereço</param>
        /// <param name="patch">Objeto com os campos necessários para atualizar um endereço por Path</param>
        /// <returns>IActionResult</returns>
        /// <response code="204">Caso a atualização seja feita com sucesso</response>
        [HttpPatch("{uid:guid}")]
        public IActionResult UpdatePatch(Guid uid, JsonPatchDocument<UpdateAddressDto> patch)
        {
            ReadAddressDto? addressDto = _repository.FindById(uid);
            if (addressDto == null) return NotFound();

            UpdateAddressDto? addressToUpdate = _mapper.Map<UpdateAddressDto>(addressDto);
            
            patch.ApplyTo(addressToUpdate, ModelState);
            if (!TryValidateModel(addressToUpdate)) return ValidationProblem(ModelState);
        
            _repository.Update(uid, addressToUpdate);
            return NoContent();
        }
        
        /// <summary>
        /// Realiza o delete de um endereço no banco de dados
        /// </summary>
        /// <param name="uid">UID referente ao endereço</param>
        /// <returns>IActionResult</returns>
        /// <response code="204">Caso o detele seja feita com sucesso</response>
        [HttpDelete("{uid:guid}")]
        public IActionResult DeleteAddress(Guid uid)
        {
            Result state = _repository.Delete(uid);
            if (state.IsFailed) return NotFound(state.Errors);
            return NoContent();
        }
    }
}
