using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using task29August.NewFolder.RequestDto;


namespace task29August.repository
{
    public class Email : IEmail
    {
        private readonly EmailSettings _email;
        public Email(IOptions<EmailSettings> options)
        {
           this._email = options.Value;
        }
        public async Task SendingMailAsync(MailRequest request)
        {
            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(_email.Email);
            email.To.Add(MailboxAddress.Parse(request.ToEmail));
            email.Subject=request.Subject;
            var builder=new BodyBuilder();
            builder.HtmlBody = request.Body;
            email.Body=builder.ToMessageBody();
            using var smtp = new SmtpClient();
            smtp.Connect(_email.Host, _email.Port, SecureSocketOptions.StartTls);
            smtp.Authenticate(_email.Email, _email.Password);
            await smtp.SendAsync(email);
            smtp.Disconnect(true);
        }
    }
}
