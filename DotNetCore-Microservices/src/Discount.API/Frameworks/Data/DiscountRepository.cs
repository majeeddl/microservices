using Dapper;
using Discount.API.Domains.Entities;
using Discount.API.Domains.Interfaces;
using Npgsql;

namespace Discount.API.Frameworks.Data
{
    public class DiscountRepository : IDiscountRepository
    {

        private readonly IConfiguration _configuration;


        public DiscountRepository(IConfiguration configuration)
        {
            this._configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }
        public async Task<Coupon> GetDiscount(string productName)
        {
            using var connection = new NpgsqlConnection(_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));

            var coupon = await connection.QueryFirstOrDefaultAsync<Coupon>("SELECT * FROM Coupon WHERE ProductName = @ProductName", new { ProductName = productName});

            return coupon;
        }

        public async Task<bool> CreateDiscount(Coupon coupon)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateDiscount(Coupon coupon)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteDiscount(string productName)
        {
            throw new NotImplementedException();
        }
    }
}
