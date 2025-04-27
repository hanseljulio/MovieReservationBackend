using MovieReservation.ApplicationServices.EntityImplementations;
using MovieReservation.ApplicationServices.EntityInterfaces;
using MovieReservation.Domain.Repositories;
using MovieReservation.Infrastructure.EntityRepositories;

namespace MovieReservationBackend.API.Extensions
{
    public static class ServiceCollectionDependenciesExtensions
    {
        public static IServiceCollection ConfigureDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IUserService, UserService>();


            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
