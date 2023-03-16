using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using System.Web;
using UserApi.Data;
using UserApi.Data.Dto;
using UserApi.Data.Requests;
using UserApi.Models;
using UserApi.Repository.IRepository;
using UserApi.Services.IServices;

namespace UserApi.Repository
{
    public class RegisterRepository : IRegisterRepository
    {
        private readonly UserDbContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<IdentityUser<Guid>> _userManager;
        private readonly IEmailService _emailService;

        public RegisterRepository(UserDbContext context, IMapper mapper, UserManager<IdentityUser<Guid>> userManager, IEmailService emailService)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
            _emailService = emailService;
        }


        public async Task<Result> RegisterUser(CreateUserDto dto)
        {
            User user = _mapper.Map<User>(dto);
            IdentityUser<Guid> userIdentity = _mapper.Map<IdentityUser<Guid>>(user);
            Task<IdentityResult> resultIdentity = _userManager.CreateAsync(userIdentity, dto.Password);
            if (resultIdentity.Result.Succeeded)
            {
                string code = await _userManager.GenerateEmailConfirmationTokenAsync(userIdentity);
                string encodedCode = HttpUtility.UrlEncode(code);
                _emailService.SendEmail(
                    new string[] { userIdentity.Email },
                    "Link de ativação",
                    userIdentity.Id, encodedCode
                );
                return Result.Ok().WithSuccess(code);
            }
            List<IdentityError> errorList = resultIdentity.Result.Errors.ToList();
            return Result.Fail(
                string
                    .Join(", ", errorList.Select(e => e.Description))
                );
        }

        public Result ActivateAccountUser(ActivateAccountRequest request)
        {
            IdentityUser<Guid> identityUser = _userManager
                .Users
                .FirstOrDefault(u => u.Id == request.UserId)!;
            IdentityResult identityResult = _userManager
                .ConfirmEmailAsync(identityUser, request.ActivationCode).Result;
            if (identityResult.Succeeded) return Result.Ok();
            List<IdentityError> errorList = identityResult.Errors.ToList();
            return Result.Fail(
                string
                    .Join(", ", errorList.Select(e => e.Description))
            );
        }
    }
}
