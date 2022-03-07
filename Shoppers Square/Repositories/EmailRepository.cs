using Microsoft.Extensions.Options;
using Shoppers_Square.IRepositories;
using Shoppers_Square.Models;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Shoppers_Square.Repositories
{
    public class EmailRepository: IEmailRepository
    {
        private readonly SMTPConfigModel _smtpconfig;

        public EmailRepository(IOptions<SMTPConfigModel> smtpconfig)
        {
            _smtpconfig = smtpconfig.Value;
        }

        public async Task SendEmailTest(string Name, string Email, string Token, string Subject)
        {
            string Body = "<html>" +
                "<head></head>" +
                "<body>" + "<h3 style='background:#ccc; padding:20px;text-align:center;'>"+
                Name.ToUpper() + " " +
                Subject.ToUpper() + "<h3/>" + "</br>"+
                Token +
                "</body>"+
                "</html>";
            await SendEmail(Email,Body, Subject);
        }

        private async Task SendEmail(string Email, string Body, string Subject)
        {
            MailMessage mail = new MailMessage
            {
                Subject = Subject,
                Body = Body,
                From = new MailAddress(_smtpconfig.SenderAddress,_smtpconfig.SenderDisplayName),
                IsBodyHtml = _smtpconfig.IsBodyHTML
            };
            mail.To.Add(Email);
            NetworkCredential networkCredential = new NetworkCredential(_smtpconfig.Username,_smtpconfig.Password);
            SmtpClient smtpClient = new SmtpClient
            {
                Host = _smtpconfig.Host,
                Port = _smtpconfig.Port,
                EnableSsl = _smtpconfig.EnableSSL,
                UseDefaultCredentials = _smtpconfig.UseDefaultCredentials,
                Credentials = networkCredential
            };
            mail.BodyEncoding = Encoding.Default;
            await smtpClient.SendMailAsync(mail);
        }
    }
}
