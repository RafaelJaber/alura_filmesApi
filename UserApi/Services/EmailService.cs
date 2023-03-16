using FluentResults;
using MailKit.Net.Smtp;
using MimeKit;
using UserApi.Models;
using UserApi.Services.IServices;

namespace UserApi.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public Result SendEmail(string[] recipient, string subject, Guid userId, string code)
        {
            Message mensage = new Message(recipient, subject, userId, code);
            MimeMessage messageMail = GenerateEmailBody(mensage);
            return Send(messageMail);
        }

        private MimeMessage GenerateEmailBody(Message message)
        {
            MimeMessage messageMail = new MimeMessage();
            messageMail.From.Add(new MailboxAddress("App Filmes", _configuration.GetValue<string>("EmailSettings:From")));
            messageMail.To.AddRange(message.Recipient);
            messageMail.Subject = message.Subject;
            messageMail.Body = new TextPart(MimeKit.Text.TextFormat.Text)
            {
                Text = message.Content
            };
            return messageMail;
        }

        private Result Send(MimeMessage messageMail)
        {
            using SmtpClient client = new SmtpClient();
            try
            {
                client.Connect(_configuration
                    .GetValue<string>("EmailSettings:SmtpServer"),
                    _configuration.GetValue<int>("EmailSettings:Port"), true);
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                client.Authenticate(
                    _configuration.GetValue<string>("EmailSettings:From"), 
                    _configuration.GetValue<string>("EmailSettings:Password"));
                
                client.Send(messageMail);
                return Result.Ok();
            }
            catch (ArgumentException e)
            {
                return Result.Fail(e.Message);
                throw;
            }
            finally
            {
                client.Disconnect(true);
                client.Dispose();
            }
        }
    }
}
