using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using SpotifyAuth.Domain.Interfaces.IRepository;
using SpotifyAuth.Persistence.Data;
using SpotifyAuth.Persistence.Repository;

namespace SpotifyAuth.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<AppDbContext>(x =>
            {
                x.UseMySql(
                        connectionString,
                        new MariaDbServerVersion(new Version(10, 5, 9)),
                        mysqlOptions => mysqlOptions.CharSetBehavior(CharSetBehavior.NeverAppend))
                    .EnableSensitiveDataLogging()
                    .EnableDetailedErrors();
            });

            services.AddTransient<IUserRepository, UserRepository>();

            return services;
        }
    }
}