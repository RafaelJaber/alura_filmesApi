using FluentResults;
using Microsoft.AspNetCore.Identity;
using UserApi.Repository.IRepository;

namespace UserApi.Repository
{
    public class LogoutRepository : ILogoutRepository
    {
        private readonly SignInManager<IdentityUser<Guid>> _signInManager;

        
        public LogoutRepository(SignInManager<IdentityUser<Guid>> signInManager)
        {
            _signInManager = signInManager;
        }

        public Result Logout()
        {
            Task resultIdentity = _signInManager.SignOutAsync();
            if (resultIdentity.IsCompletedSuccessfully) return Result.Ok();
            return Result.Fail("Logout falhou");
        }
    }
}
