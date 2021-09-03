using AutoMapper.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Blossom.DependencyInjection
{
    public class SmtpModule : IDependencyInjectionModule
    {
        private readonly string _emailSmtpHost;
        private readonly int _emailSmtpPort;
        private readonly string _emailSmtpUsername;
        private readonly string _emailSmtpPassword;

        public SmtpModule(string emailSmtpHost, int emailSmtpPort, string emailSmtpUsername, string emailSmtpPassword)
        {
            _emailSmtpHost = emailSmtpHost;
            _emailSmtpPort = emailSmtpPort;
            _emailSmtpUsername = emailSmtpUsername;
            _emailSmtpPassword = emailSmtpPassword;
        }

        public void RegisterDependencies(IServiceCollection services)
        {
            services.AddScoped<SmtpClient>((serviceProvider) =>
            {
                SmtpClient SmtpServer = new SmtpClient(_emailSmtpHost);

                SmtpServer.Port = _emailSmtpPort;
                SmtpServer.Credentials = new System.Net.NetworkCredential(_emailSmtpUsername, _emailSmtpPassword);
                SmtpServer.EnableSsl = true;

                return SmtpServer;
            });
        }
    }
}