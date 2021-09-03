using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using Blossom.DependencyInjection;
using Blossom.Data.Model;
using Microsoft.EntityFrameworkCore;
using Blossom.Api.Middleware;
using AspNetCoreRateLimit;

namespace Blossom.Api
{
	public class Startup
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfiguration _configuration;

        public Startup(IWebHostEnvironment env, IConfiguration configuration)
        {
            _env = env;
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("DefaultCorsPolicy", policy =>
                {
                    policy.AllowAnyHeader();
                    policy.AllowAnyMethod();
                    policy.AllowAnyOrigin();
                });
            });

            services.AddOptions();

            // needed to store rate limit counters and ip rules
            services.AddMemoryCache();

            //load general configuration from appsettings.json
            services.Configure<IpRateLimitOptions>(_configuration.GetSection("IpRateLimiting"));

            //load ip rules from appsettings.json
            services.Configure<IpRateLimitPolicies>(_configuration.GetSection("IpRateLimitPolicies"));

            // inject counter and rules stores
            services.AddInMemoryRateLimiting();

            // configuration (resolvers, counter key builders)
            services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();

            services.AddControllers();

            services.AddMvc(options => options.EnableEndpointRouting = false);

            string domain = $"https://{_configuration["Auth0:Domain"]}/";
            string audience = _configuration["Auth0:Audience"];

            string database = _configuration.GetConnectionString("BlossomDatabase");
            string databaseVersion = _configuration.GetConnectionString("BlossomDatabaseVersion");

            string emailSmtpHost = _configuration["Email:Smtp:Host"];
            int emailSmtpPort = _configuration.GetValue<int>("Email:Smtp:Port");
            string emailSmtpUsername = _configuration["Email:Smtp:Username"];
            string emailSmtpPassword = _configuration["Email:Smtp:Password"];

            var modules = new List<IDependencyInjectionModule>
            {
                new MappingModule(),
                new AuthModule(domain, audience),
                new DataModule(database, databaseVersion),
                new ServiceModule(),
                new SmtpModule(emailSmtpHost, emailSmtpPort, emailSmtpUsername, emailSmtpPassword)
            };
            modules.ForEach(module => module.RegisterDependencies(services));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, BlossomContext dataContext)
        {
            // migrate any database changes on startup (includes initial db creation)
            dataContext.Database.Migrate();

            // exceptions
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
				app.UseMiddleware<ExceptionMiddleware>();
				app.UseHttpsRedirection();
			}

			// routing
			app.UseRouting();

            // global cors policy
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseIpRateLimiting();

            app.UseClientRateLimiting();

            // auth
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
