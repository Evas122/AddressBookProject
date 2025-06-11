using AddressBook.Core.Interfaces.Repositories;
using AddressBook.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace AddressBook.Infrastructure.Extensions
{
    public static class RepositoryExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IContactRepository, ContactRepository>();
            services.AddScoped<ICityRepository, CityRepository>();

            return services;
        }
    }
}