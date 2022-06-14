using TaskManagement.Business.Interfaces;
using TaskManagement.Services.EF;
using TaskManagement.Services.Mongo;

namespace TaskManagement.Host.Api.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigurePersistence(this
            IServiceCollection services, IConfiguration config)
        {
            var persistenceType = config["Persistence:PersistenceType"];
            if (persistenceType == "Ef")
            {
                services.AddPersistenceServicesEF(config);
            }
            else if (persistenceType == "MongoDb")
            {
               services.AddPersistenceServicesMng(config);
            }
            services.AddScoped<ITaskManagementService, TaskManagementService>();
        }
        public static void ConfigureNewtonsoftJson(this
            IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson(options =>
      options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

        }
    }
}
