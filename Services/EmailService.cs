using Microsoft.AspNet.Identity;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace ConstosoUniversityCodeFirst1.Services
{
    public class EmailService : IIdentityMessageService
    {
        public async Task SendAsync(IdentityMessage message)
        {
            await ConfigSMTPasync(message);
        }

        private Task ConfigSMTPasync(IdentityMessage message)
        {
            SmtpClient client = new SmtpClient
            {
                Port = 587,
                Host = "smtp.gmail.com", //or another email sender provider
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(ConfigurationManager.AppSettings["emailService:Account"], ConfigurationManager.AppSettings["emailService:Password"])
            };

            return client.SendMailAsync(ConfigurationManager.AppSettings["emailService:Account"], message.Destination, message.Subject, message.Body);
        }
    }
}