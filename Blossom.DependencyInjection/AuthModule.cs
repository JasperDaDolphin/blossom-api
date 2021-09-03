using Microsoft.Extensions.DependencyInjection;
using Blossom.Mapping;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using Blossom.Api.Model.Authentication;

namespace Blossom.DependencyInjection
{
	public class AuthModule : IDependencyInjectionModule
    {
        private readonly string _domain;
        private readonly string _audience;

        public AuthModule(string domain, string audience) {
            _domain = domain;
            _audience = audience;
        }

        public void RegisterDependencies(IServiceCollection services)
        {
            services
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.Authority = _domain;
                    options.Audience = _audience;
                    // If the access token does not have a `sub` claim, `User.Identity.Name` will be `null`. Map it to a different claim by setting the NameClaimType below.
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        NameClaimType = ClaimTypes.NameIdentifier
                    };
                });

            services.AddAuthorization(options =>
            {
				foreach (var policyItem in Policies.All)
				{
					options.AddPolicy(policyItem, policy => policy.Requirements.Add(new HasScopeRequirement(policyItem, _domain)));
				}
			});

			// Register the scope authorization handler
			services.AddSingleton<IAuthorizationHandler, HasScopeHandler>();
		}
    }
}
