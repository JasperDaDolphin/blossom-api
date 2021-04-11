using Microsoft.Extensions.DependencyInjection;

namespace Blossom.DependencyInjection
{
    public interface IDependencyInjectionModule
    {
        void RegisterDependencies(IServiceCollection services);
    }
}