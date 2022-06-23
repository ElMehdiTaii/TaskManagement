using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Services.Contract.Interface;
using TaskManagement.Services.EF.Repository;
using TaskManagement.Services.EF.Services;

namespace TaskManagement.Services.EF
{
    public static class PersistenceContainerEF
    {
        public static IServiceCollection AddPersistenceServicesEF(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();

            services.AddDbContext<EfContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("ConnectionString")));

            return services;
        }
    }
}
