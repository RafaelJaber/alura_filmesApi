using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using UserApi.Data;
using UserApi.Data.Dto;
using UserApi.Models;
using UserApi.Repository.IRepository;

namespace UserApi.Repository
{
    public class RegisterRepository : IRegisterRepository
    {
        private readonly UserDbContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<IdentityUser<Guid>> _userManager;

        public RegisterRepository(UserDbContext context, IMapper mapper, UserManager<IdentityUser<Guid>> userManager)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
        }


        public Result RegisterUser(CreateUserDto dto)
        {
            User user = _mapper.Map<User>(dto);
            IdentityUser<Guid> userIdentity = _mapper.Map<IdentityUser<Guid>>(user);
            Task<IdentityResult> resultIdentity = _userManager.CreateAsync(userIdentity, dto.Password);
            if (resultIdentity.Result.Succeeded) return Result.Ok();
            List<IdentityError> errorList = resultIdentity.Result.Errors.ToList();
            return Result.Fail(
                string
                    .Join(", ", errorList.Select(e => e.Description))
                );
        }
    }
}
