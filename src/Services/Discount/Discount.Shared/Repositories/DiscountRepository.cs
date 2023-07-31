using Dapper;
using Discount.DataAccess.Models;
using Discount.DataAccess.Entities;
using Npgsql;

namespace Discount.DataAccess.Repositories
{
    public class DiscountRepository : IDiscountRepository
    {
        private readonly NpgsqlConnection _connection;

        public DiscountRepository(NpgsqlConnection connection)
        {
            _connection = connection;
        }

        public async Task<Result> CreateAsync(Coupon entity, CancellationToken cancellationToken = default)
        {
            try
            {
                var affected = await _connection.ExecuteAsync(
                "INSERT INTO Coupon(ProductName, Description, Amount) VALUES (@ProductName, @Description, @Amount)",
                new { ProductName = entity.ProductName, Description = entity.Description, Amount = entity.Amount });

                return Result.Define(affected > 0);
            }
            catch (Exception ex)
            {
                return Result.Failure(ex);
            }
        }

        public async Task<Result> DeleteCouponAsync(string productName, CancellationToken cancellationToken = default)
        {
            try
            {
                var affected = await _connection.ExecuteAsync(
                "DELETE FROM Coupon WHERE ProductName = @ProductName",
                new { ProductName = productName });

                return Result.Define(affected > 0);
            }
            catch (Exception ex)
            {
                return Result.Failure(ex);
            }
        }

        public async Task<Coupon> GetDiscountAsync(string productName, CancellationToken cancellationToken = default)
        {
            var coupon = await _connection.QueryFirstOrDefaultAsync<Coupon>(
                "SELECT * FROM Coupon WHERE ProductName = @ProductName", 
                new { ProductName = productName });

            if (coupon is null)
            {
                return Coupon.Default();
            }

            return coupon;
        }

        public async Task<Result> UpdateAsync(Coupon entity, CancellationToken cancellationToken = default)
        {
            try
            {
                var affected = await _connection.ExecuteAsync(
                "UPDATE Coupon SET ProductName = @ProductName, Description = @Description, Amount = @Amount " +
                "WHERE Id = @Id",
                new { ProductName = entity.ProductName, Description = entity.Description, Amount = entity.Amount, Id = entity.Id });

                return Result.Define(affected > 0);
            }
            catch (Exception ex)
            {
                return Result.Failure(ex);
            }
        }
    }
}
