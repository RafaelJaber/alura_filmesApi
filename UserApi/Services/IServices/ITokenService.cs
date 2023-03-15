using Microsoft.AspNetCore.Identity;
using UserApi.Models;

namespace UserApi.Services.IServices
{
    public interface ITokenService
    {
        public Token CreateToken(IdentityUser<Guid> user);
    }
}
