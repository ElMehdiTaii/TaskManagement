using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaskManagement.Services.Contract.Services;

namespace TaskManagement.Services.EF
{
    public static class PersistenceContainerEF
    {
        public static IServiceCollection AddPersistenceServicesEF(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();

            services.AddDbContext<RepositoryContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("ConnectionString")));

            return services;
        }
    }
}
