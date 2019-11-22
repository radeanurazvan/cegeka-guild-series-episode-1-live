using Cegeka.Guild.Pokeverse.DAL.Abstracts;
using Cegeka.Guild.Pokeverse.DAL.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace Cegeka.Guild.Pokeverse.DAL
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDAL(this IServiceCollection services)
        {
            return services.AddSingleton(typeof(IRepository<>), typeof(Repository<>));
        }
    }
}