using Catalog.API.Domains.Entities;
using Catalog.API.Domains.Interfaces;
using Catalog.API.Settings;
using MongoDB.Driver;

namespace Catalog.API.Frameworks.Data
{
    public static class DataServices
    {


        public static IServiceCollection ConfigureDatabase(this IServiceCollection services)
        {
            services.AddSingleton(serviceProvider =>
            {
                var configuration = serviceProvider.GetService<IConfiguration>();

                var mongoDBSettings = configuration?.GetSection(nameof(MongoDBSettings)).Get<MongoDBSettings>() ?? throw new ArgumentNullException("configuration.GetSection(nameof(MongoDBSettings)).Get<MongoDBSettings>()");

                var mongoClient = new MongoClient(mongoDBSettings.ConnectionString);

                return mongoClient.GetDatabase(mongoDBSettings.DatabaseName);

            });

            return services;
        }


        public static IServiceCollection AddMongoRepository(this IServiceCollection services)
        {
            services.AddSingleton<IRepository<Product>, MongoRepository<Product>>();

            return services;

        }
    }
}
