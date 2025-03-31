using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace OnlineBookstore.Services.Utilities
{
    public class EmailHelper
    {
        private readonly string _smtpServer;
        private readonly int _port;
        private readonly string _fromEmail;
        private readonly string _password;

        public EmailHelper(string smtpServer, int port, string fromEmail, string password)
        {
            _smtpServer = smtpServer;
            _port = port;
            _fromEmail = fromEmail;
            _password = password;
        }

        public async Task<bool> SendEmailAsync(string toEmail, string subject, string body)
        {
            try
            {
                using (var client = new SmtpClient(_smtpServer, _port))
                {
                    client.Credentials = new NetworkCredential(_fromEmail, _password);
                    client.EnableSsl = true;

                    var mailMessage = new MailMessage
                    {
                        From = new MailAddress(_fromEmail),
                        Subject = subject,
                        Body = body,
                        IsBodyHtml = true
                    };

                    mailMessage.To.Add(toEmail);

                    await client.SendMailAsync(mailMessage);
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
