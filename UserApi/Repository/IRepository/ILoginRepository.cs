using FluentResults;
using UserApi.Data.Requests;

namespace UserApi.Repository.IRepository
{
    public interface ILoginRepository
    {
        public Result LoginUser(LoginRequest request);
    }
}