using FluentResults;
using Microsoft.AspNetCore.Mvc;
using UserApi.Data.Dto;
using UserApi.Data.Requests;
using UserApi.Repository.IRepository;

namespace UserApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegisterController : ControllerBase
    {
        private readonly IRegisterRepository _repository;

        public RegisterController(IRegisterRepository repository)
        {
            _repository = repository;
        }


        [HttpPost]
        public async Task<IActionResult> RegisterUser(CreateUserDto createDto)
        {
            Result result = await _repository.RegisterUser(createDto);
            if (result.IsFailed) return BadRequest(result.Errors[0]);
            return Ok(result.Successes[0]);
        }

        [HttpGet("/active")]
        public IActionResult ActiveUser([FromQuery] ActivateAccountRequest request)
        {
            Result result = _repository.ActivateAccountUser(request);
            if (result.IsFailed) return StatusCode(500, result.Errors[0]);
            return Ok(result.Successes);
        }

    }
}
