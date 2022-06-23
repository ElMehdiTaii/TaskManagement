using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Entities.Models;
using TaskManagement.Services.Contract.Interface;
using TaskManagement.Services.Mongo.Interfaces;
using TaskManagement.Services.Mongo.Repository;
using TaskManagement.Services.Mongo.Services;

namespace TaskManagement.Services.Mongo
{
    public static class PersistenceContainerMongo
    {
        public static IServiceCollection AddPersistenceServicesMng(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IMongoContext, MongoContext>();

            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();

            services.Configure<DatabaseSettings>(x =>
            {
                x.ConnectionString = configuration["MongoConnection:ConnectionString"].ToString();
                x.DatabaseName = configuration["MongoConnection:DatabaseName"].ToString();
            });
            BsonClassMap.RegisterClassMap<Students>(x =>
            {
                x.AutoMap();
                x.MapIdMember(c => c.Id);
            });


            BsonClassMap.RegisterClassMap<Tasks>(x =>
            {
                x.AutoMap();
                x.MapIdMember(c => c.Id); ;
            });

            BsonClassMap.RegisterClassMap<Teachers>(x =>
            {
                x.AutoMap();
                x.MapIdMember(c => c.Id);
            });
            return services;
        }
    }
}
