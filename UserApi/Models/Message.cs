using MimeKit;

namespace UserApi.Models
{
    public class Message
    {
        public List<MailboxAddress> Recipient { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }

        public Message(IEnumerable<string> recipient ,string subject, Guid userId, string code)
        {
            Recipient = new List<MailboxAddress>();
            Recipient.AddRange(recipient.Select(d => new MailboxAddress(d, d)));
            Subject = subject;
            Content = $"https://localhost:6244/active?UserId={userId}&ActivationCode={code}";
        }
    }
}
