using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using Blossom.Data.Implementation.Users;
using Blossom.Data.Users;
using Blossom.Data.Model;

namespace Blossom.DependencyInjection
{
    public class DataModule : IDependencyInjectionModule
    {
        private readonly string _connectionString;

        public DataModule(string connectionString) => _connectionString = connectionString;
        
        public void RegisterDependencies(IServiceCollection services)
        {
			services.AddDbContext<BlossomContext>(options => options.UseNpgsql(_connectionString));

			services.AddScoped<IUserRepository, UserRepository>();
		}
    }
}