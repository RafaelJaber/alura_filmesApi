using FluentResults;

namespace UserApi.Services.IServices
{
    public interface IEmailService
    {
        public Result SendEmail(string[] recipient, string subject, Guid userId, string code);
    }
}
