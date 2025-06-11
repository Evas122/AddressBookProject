using AddressBook.Infrastructure.Data;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace AddressBook.Infrastructure.Extensions
{
    public static class InfrastructureExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<AddressBookDbContext>();
            services.AddRepositories();
            services.AddApplicationServices();
            return services;
        }
    }
}