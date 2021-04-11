using Blossom.Service.Implementation.Users;
using Blossom.Service.Users;
using Microsoft.Extensions.DependencyInjection;

namespace Blossom.DependencyInjection
{
    public class ServiceModule : IDependencyInjectionModule
    {
        public void RegisterDependencies(IServiceCollection services)
        {
			services.AddScoped<IUserService, UserService>();
		}
    }
}