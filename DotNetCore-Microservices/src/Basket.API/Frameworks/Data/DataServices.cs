using Basket.API.Domains.Interfaces;

namespace Basket.API.Frameworks.Data
{
    public static class DataServices
    {
        public static IServiceCollection Configure(this IServiceCollection services)
        {
            return services;
        }

        public static IServiceCollection AddRedisRepository(this IServiceCollection services)
        {
            services.AddScoped<IBasketRepository, BasketRepository>();

            return services;
        }
    }
}
