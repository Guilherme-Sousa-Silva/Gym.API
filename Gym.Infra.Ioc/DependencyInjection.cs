using Gym.Application.Interfaces;
using Gym.Application.Mappings;
using Gym.Application.Services;
using Gym.Domain.Interfaces;
using Gym.Infra.Data.Context;
using Gym.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Gym.Infra.Ioc
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                x => x.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName));
            });

            services.AddScoped<IGymRepository, GymRepository>();
            services.AddScoped<IGymService, GymService>();

            services.AddAutoMapper(typeof(DomainToDtoMapping));

            return services;
        }
    }
}
