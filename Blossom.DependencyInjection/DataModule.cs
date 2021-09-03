using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using Blossom.Data.Implementation.Users;
using Blossom.Data.Implementation.BusinessProfiles;
using Blossom.Data.Users;
using Blossom.Data.BusinessProfiles;
using Blossom.Data.Model;
using Blossom.Data.StudentProfiles;
using Blossom.Data.Implementation.StudentProfiles;
using MySqlConnector;
using System;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace Blossom.DependencyInjection
{
    public class DataModule : IDependencyInjectionModule
    {
        private readonly string _connectionString;
        private readonly string _serverVersion;

        public DataModule(string connectionString, string serverVersion)
        {
            _connectionString = connectionString;
            _serverVersion = serverVersion;
        }
        
        public void RegisterDependencies(IServiceCollection services) {

            var serverVersion = new MySqlServerVersion(_serverVersion);
            services.AddDbContext<BlossomContext>(options => options.UseMySql(_connectionString, serverVersion));

            //Repositorys
			services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IBusinessProfilesRepository, BusinessProfilesRepository>();
            services.AddScoped<IStudentProfilesRepository, StudentProfilesRepository>();
        }
    }
}