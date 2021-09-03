using Microsoft.Extensions.DependencyInjection;
using Blossom.Mapping;

namespace Blossom.DependencyInjection
{
	public class MappingModule : IDependencyInjectionModule
    {
        public void RegisterDependencies(IServiceCollection services)
        {
			services.AddAutoMapper(typeof(ApiMappingProfile).Assembly);
		}
    }
}
