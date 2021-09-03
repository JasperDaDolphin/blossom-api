using AutoMapper;
using Blossom.Service.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using Blossom.Api.Model.Contact;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Configuration;
using WebApiThrottle;

namespace Blossom.Api.Controllers
{
	[Route("api/contact")]
	[ApiController]
	public class ContactController : ControllerBase
    {
        private SmtpClient _smtpClient;

        private readonly IConfiguration _configuration;
        public ContactController(
            SmtpClient smtpClient,
            IConfiguration configuration
        )
        {
            _smtpClient = smtpClient;
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<IActionResult> SendEmail([FromBody] SendContactRequest request)
        {
            try
			{
				MailMessage mail = new MailMessage();

                mail.From = new MailAddress(_configuration["Email:Smtp:Username"]);
                mail.To.Add(_configuration["Email:ContactAddress"]);
                mail.Subject = $"Contact Request: {request.Name}";

                #region body
                var body = $@"<b>Name:</b> {request.Name} <br/> <b>Phone:</b> {request?.PhoneNumber} <br/> <b>Email:</b> {request.Email} <br/> <b>Message:</b> <br/> {request.Body}";
                #endregion

                mail.Body = body;
                mail.IsBodyHtml = true;

				await _smtpClient.SendMailAsync(mail);
                return Ok();
            }
            catch
			{
                return NoContent();
            }
        }
    }
}
