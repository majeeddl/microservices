﻿using Dapper;
using Discount.Grpc.Domains.Entities;
using Discount.Grpc.Domains.Interfaces;
using Npgsql;

namespace Discount.Grpc.Frameworks.Data
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
            await using var connection = new NpgsqlConnection(_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));

            var coupon = await connection.QueryFirstOrDefaultAsync<Coupon>("SELECT * FROM Coupon WHERE ProductName = @ProductName", new { ProductName = productName});

            return coupon;
        }

        public async Task<bool> CreateDiscount(Coupon coupon)
        {
            await using var connection =
                new NpgsqlConnection(_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));

            var affected = await connection.ExecuteAsync(
                "INSERT INTO Coupon ( ProductName, Description, Amount) VALUES (@ProductName, @Description, @Amount)",
                new
                {
                    coupon.ProductName,
                    coupon.Description,
                    coupon.Amount
                });

            return affected != 0;
        }

        public async Task<bool> UpdateDiscount(Coupon coupon)
        {
            await using var connection =
                new NpgsqlConnection(_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));

            var affected = await connection.ExecuteAsync(
                "UPDATE Coupon SET ProductName=@ProductName, @Description=Description, @Amount=Amount WHERE Id = @Id",
                new
                {
                    coupon.Id,
                    coupon.ProductName,
                    coupon.Description,
                    coupon.Amount
                });

            return affected != 0;
        }

        public async Task<bool> DeleteDiscount(string productName)
        {
            await using var connection =
                new NpgsqlConnection(_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));

            var affected = await connection.ExecuteAsync(
                "DELETE FROM Coupon WHERE ProductName=@ProductName",
                new
                {
                    ProductName = productName
                });

            return affected != 0;
        }
    }
}
