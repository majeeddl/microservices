using Discount.Grpc.Frameworks.Data;
using Discount.Grpc.Domains.Interfaces;

namespace Discount.Grpc.Frameworks.Data
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
