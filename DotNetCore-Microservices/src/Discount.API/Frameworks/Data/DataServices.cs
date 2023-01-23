using Discount.API.Domains.Interfaces;

namespace Discount.API.Frameworks.Data
{
    public static class DataServices
    {

        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddScoped<IDiscountRepository, DiscountRepository>();

            return services;
        }
    }
}
