﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Footballers.Persistence;
using Microsoft.EntityFrameworkCore;
using Footballers.Application.Interfaces;

namespace Queries
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistense(this IServiceCollection
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
