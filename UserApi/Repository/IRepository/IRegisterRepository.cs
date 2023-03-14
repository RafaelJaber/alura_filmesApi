using FluentResults;
using UserApi.Data.Dto;

namespace UserApi.Repository.IRepository
{
    public interface IRegisterRepository
    {
        public Result RegisterUser(CreateUserDto dto);
    }
}
