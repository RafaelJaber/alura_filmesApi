using FluentResults;
using UserApi.Data.Dto;
using UserApi.Data.Requests;

namespace UserApi.Repository.IRepository
{
    public interface IRegisterRepository
    {
        public Task<Result> RegisterUser(CreateUserDto dto);
        public Result ActivateAccountUser(ActivateAccountRequest request);
    }
}
