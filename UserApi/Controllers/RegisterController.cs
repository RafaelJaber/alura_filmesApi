using FluentResults;
using Microsoft.AspNetCore.Mvc;
using UserApi.Data.Dto;
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
        public IActionResult RegisterUser(CreateUserDto createDto)
        {
            Result result = _repository.RegisterUser(createDto);
            if (result.IsFailed) return BadRequest(result.Errors);
            return Ok();
        }
    }
}
