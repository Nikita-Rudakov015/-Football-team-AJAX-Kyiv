using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Footballers.Application.Interfaces;

namespace Footballer.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection
            services, IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];
            services.AddDbContext<FootballersDbContext>(options =>
            {
                options.UseSqlite(connectionString);
            });
            services.AddScoped<IFootballersDbContext>(provider =>
                provider.GetService<FootballersDbContext>());
            return services;
        }
    }
}
