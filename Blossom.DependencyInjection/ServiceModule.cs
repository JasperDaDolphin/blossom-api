using AutoMapper.Configuration;
using Blossom.Service.BusinessProfiles;
using Blossom.Service.Implementation.BusinessProfiles;
using Blossom.Service.Implementation.StudentProfiles;
using Blossom.Service.Implementation.Users;
using Blossom.Service.StudentProfiles;
using Blossom.Service.Users;
using Microsoft.Extensions.DependencyInjection;

namespace Blossom.DependencyInjection
{
    public class ServiceModule : IDependencyInjectionModule
    {
        public void RegisterDependencies(IServiceCollection services)
        {
			services.AddScoped<IUserService, UserService>();
            services.AddScoped<IBusinessProfileService, BusinessProfileService>();
            services.AddScoped<IStudentProfileService, StudentProfileService>();
        }
    }
}