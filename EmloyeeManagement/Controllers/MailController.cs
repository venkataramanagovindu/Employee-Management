using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SendGrid;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SendGrid.Helpers.Mail;
using EmployeeManagement.Models.DTO;
using EmployeeManagement.IRepository;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json.Linq;
using Microsoft.Extensions.Configuration;

namespace EmloyeeManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailController : ControllerBase
    {
        public IHTTP _hTTP;
        private readonly IConfiguration _configuration;
        public MailController(IHTTP hTTP, IConfiguration configuration)
        {
            _hTTP = hTTP;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("ContactListSendMail")]
        public async Task<HTTPResponse> ContactListSendMail(Email email)
        {
            string listId = "950f94c8-5463-4c69-9820-c48dcb16c350";
            HTTPResponse HTTPResponse = await _hTTP.Get("v3/marketing/lists/" + listId +"?contact_sample=true");

            HTTPResponse.data = JObject.Parse(HTTPResponse.data);
            JObject JObj = (JObject)HTTPResponse.data;
            List<EmailAddress> EmailAddress = new List<EmailAddress>();
            foreach (var mailDetails in JObj["contact_sample"])
            {
                EmailAddress.Add(new EmailAddress(mailDetails["email"].ToString(), mailDetails["first_name"].ToString() + " " + mailDetails["last_name"].ToString()));
            }

            var apiKey = _configuration["API_KEY"];
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress(_configuration["FROM_MAIL_ID"], "Example User");
            var subject = email.Subject;// "Sending with SendGrid is Fun";
            var plainTextContent = "and easy to do anywhere, even with C#";
            var htmlContent = email.Body;// "<strong>and easy to do anywhere, even with C#</strong>";
            var msg = MailHelper.CreateSingleEmailToMultipleRecipients(from, EmailAddress, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
            if (response.IsSuccessStatusCode == true)
            {
                return new HTTPResponse()
                {
                    statusCode = 200,
                    data = "Send mail Successfully"
                };
            }
            else
            {
                return new HTTPResponse()
                {
                    statusCode = 500,
                    data = "Mail sending Unsuccessfull"
                };
            }
        }
    }
}
