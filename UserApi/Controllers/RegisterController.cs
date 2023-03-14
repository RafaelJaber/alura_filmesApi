using Microsoft.AspNetCore.Mvc;
using UserApi.Data.Dto;

namespace UserApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegisterController : ControllerBase
    {

        [HttpPost]
        public IActionResult RegisterUser(CreateUserDto createDto)
        {
            //TODO chamar o repositório
            return Ok();
        }
    }
}
