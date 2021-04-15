using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Services.Rest
{
    public interface IEmailService
    {
        Task SendAsync(string toEmail, string toName, string templateId, object data);
    }

    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task SendAsync(string toEmail, string toName, string templateId, object data)
        {
            //var sendGridKey = Environment.GetEnvironmentVariable("SendGridKey");
            var client = new SendGridClient(_configuration["SendGrid:Key"]);
            var sendGridMessage = new SendGridMessage();
            sendGridMessage.SetFrom(_configuration["SendGrid:From"], _configuration["SendGrid:Title"]);
            sendGridMessage.AddTo(toEmail, toName);

            sendGridMessage.SetTemplateId(templateId);
            sendGridMessage.SetTemplateData(data);

            await client.SendEmailAsync(sendGridMessage);
        }
    }
}
