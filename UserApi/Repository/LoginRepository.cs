using FluentResults;
using Microsoft.AspNetCore.Identity;
using UserApi.Data.Requests;
using UserApi.Models;
using UserApi.Repository.IRepository;
using UserApi.Services.IServices;

namespace UserApi.Repository
{
    public class LoginRepository : ILoginRepository
    {
        private readonly SignInManager<IdentityUser<Guid>> _signInManager;
        private readonly ITokenService _tokenService;

        public LoginRepository(SignInManager<IdentityUser<Guid>> signInManager, ITokenService tokenService)
        {
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        public Result LoginUser(LoginRequest request)
        {
            Task<SignInResult> resultIdentity = _signInManager
                .PasswordSignInAsync(request.Username, request.Password, false, false);
            if (resultIdentity.Result.Succeeded)
            {
                IdentityUser<Guid> identityUser = _signInManager
                    .UserManager
                    .Users
                    .FirstOrDefault(u 
                        => u.NormalizedUserName == request.Username.ToUpper())!;
                Token token = _tokenService.CreateToken(identityUser);
                return Result.Ok().WithSuccess(token.Value);
            }
            return Result.Fail(resultIdentity.Result.ToString());
        }

        public Result RequestPasswordReset(ResetPasswordRequest request)
        {
            IdentityUser<Guid> identityUser = GetIdentityUser(request.Email);

            if (identityUser != null)
            {
                string recoveryCode = _signInManager.UserManager.GeneratePasswordResetTokenAsync(identityUser).Result;
                return Result.Ok().WithSuccess(recoveryCode);
            }
            return Result.Fail("Falha ao solicitar a redefinição da senha");
        }

        public Result ResetPassword(PerformResetRequest request)
        {
            var identityUser = GetIdentityUser(request.Email);
            IdentityResult identityResult = _signInManager
                .UserManager.ResetPasswordAsync(identityUser, request.Token, request.Password)
                .Result;
            
            if (identityResult.Succeeded) return Result.Ok().WithSuccess("Senha redefinida");
            List<IdentityError> errorList = identityResult.Errors.ToList();
            return Result.Fail(
                string
                    .Join(", ", errorList.Select(e => e.Description))
            );
        }

        private IdentityUser<Guid> GetIdentityUser(string email)
        {
            IdentityUser<Guid> identityUser = _signInManager
                .UserManager
                .Users
                .FirstOrDefault(u => u.NormalizedEmail == email.ToUpper())!;
            return identityUser;
        }
    }
}
