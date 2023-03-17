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
            if (result.IsFailed) return Unauthorized(result.Errors[0]);
            return Ok(result.Successes[0]);
        }

        [HttpPost("/reset-password")]
        public IActionResult ResetPassword(ResetPasswordRequest request)
        {
            Result result = _repository.RequestPasswordReset(request);
            if (result.IsFailed) return Unauthorized(result.Errors[0]);
            return Ok(result.Successes[0]);
        }
        
        [HttpPost("/perform-password")]
        public IActionResult ResetPerform(PerformResetRequest request)
        {
            Result result = _repository.ResetPassword(request);
            if (result.IsFailed) return Unauthorized(result.Errors[0]);
            return Ok(result.Successes[0]);
        }
    }
}
