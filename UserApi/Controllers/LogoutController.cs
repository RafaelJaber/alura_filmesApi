using FluentResults;
using Microsoft.AspNetCore.Mvc;
using UserApi.Repository.IRepository;

namespace UserApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LogoutController : ControllerBase
    {
        private readonly ILogoutRepository _logoutRepository;

        
        public LogoutController(ILogoutRepository logoutRepository)
        {
            _logoutRepository = logoutRepository;
        }

        [HttpPost]
        public IActionResult LogoutUser()
        {
            Result result = _logoutRepository.Logout();
            if (result.IsFailed) return Unauthorized(result.Errors[0]);
            return Ok();
        }
    }
}
