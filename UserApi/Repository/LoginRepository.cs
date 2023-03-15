using FluentResults;
using Microsoft.AspNetCore.Identity;
using UserApi.Data.Requests;
using UserApi.Repository.IRepository;

namespace UserApi.Repository
{
    public class LoginRepository : ILoginRepository
    {
        private readonly SignInManager<IdentityUser<Guid>> _signInManager;

        public LoginRepository(SignInManager<IdentityUser<Guid>> signInManager)
        {
            _signInManager = signInManager;
        }

        public Result LoginUser(LoginRequest request)
        {
            Task<SignInResult> resultIdentity = _signInManager
                .PasswordSignInAsync(request.Username, request.Password, false, false);
            if (resultIdentity.Result.Succeeded) return Result.Ok();
            return Result.Fail("Login falhou");
        }
    }
}
