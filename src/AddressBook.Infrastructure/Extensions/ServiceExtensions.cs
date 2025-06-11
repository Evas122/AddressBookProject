using AddressBook.Core.Interfaces.Services;
using AddressBook.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AddressBook.Infrastructure.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IContactService, ContactService>();
            services.AddScoped<ICityService, CityService>();

            return services;
        }
    }
}