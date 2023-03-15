using FluentResults;
using Microsoft.AspNetCore.Mvc;
using UserApi.Data.Requests;
using UserApi.Repository.IRepository;

namespace UserApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ILoginRepository _repository;

        public LoginController(ILoginRepository repository)
        {
            _repository = repository;
        }
        
        
        [HttpPost]
        public IActionResult LoginUser(LoginRequest request)
        {
            Result result = _repository.LoginUser(request);
            if (result.IsFailed) return Unauthorized();
            return Ok();
        }
    }
}
