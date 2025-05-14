using Dapper;
using MS.Discount.Dtos;
using MS.Discount.Context;

namespace MS.Discount.Services;

public class DiscountService : IDiscountService
{
    private readonly DapperContext _context;

    public DiscountService(DapperContext context)
    {
        _context = context;
    }

    public async Task CreateDiscountCouponAsync(CreateDiscountCouponDto cdcdto)
    {
        string query = "Insert Into Coupons (Code, Rate, IsActive, ValidDate) Values (@code,@rate,@isActive,@validDate)";
        var parameters = new DynamicParameters();
        parameters.Add("@code", cdcdto.Code);
        parameters.Add("@rate", cdcdto.Rate);
        parameters.Add("@isActive", cdcdto.IsActive);
        parameters.Add("@validDate", cdcdto.ValidDate);
        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }

    public async Task DeleteDiscountCouponAsync(int id)
    {
        string query = "Delete From Coupons Where CouponId = @couponId";
        var parameters = new DynamicParameters();
        parameters.Add("@couponId", id);
        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }

    public async Task<GetByIdDiscountCouponDto> GetByIdDiscountCouponAsync(int id)
    {
        string query = "Select * From Coupons Where CouponId = @couponId";
        var parameters = new DynamicParameters();
        parameters.Add("@couponId", id);
        using (var connection = _context.CreateConnection())
        {
            var value = await connection.QueryFirstOrDefaultAsync<GetByIdDiscountCouponDto>(query, parameters);
            return value;
        }
    }

    public async Task<List<ResultDiscountCouponDto>> GetAllDiscountCouponAsync()
    {
        string query = "Select * From Coupons";
        using (var connection = _context.CreateConnection())
        {
            var value = await connection.QueryAsync<ResultDiscountCouponDto>(query);
            return value.ToList();
        }
    }

    public async Task UpdateDiscountCouponAsync(UpdateDiscountCouponDto udcdto)
    {
        string query = "Update Coupons Set Code=@code, Rate=@rate, IsActive=@isActive, ValidDate=@validDate Where CouponId=@couponId";
        var parameters = new DynamicParameters();
        parameters.Add("@code", udcdto.Code);
        parameters.Add("@rate", udcdto.Rate);
        parameters.Add("@isActive", udcdto.IsActive);
        parameters.Add("@validDate", udcdto.ValidDate);
        parameters.Add("@couponId", udcdto.CouponId);
        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }

    public async Task<ResultDiscountCouponDto> GetCodeDetailByCodeAsync(string code)
    {
        string query = "select * from Coupons where Code=@code";
        var parameters = new DynamicParameters();
        parameters.Add("@code", code);
        using (var connection = _context.CreateConnection())
        {
            var result = await connection.QueryFirstOrDefaultAsync<ResultDiscountCouponDto>(query, parameters);
            return result;
        }
    }

    public int GetDiscountCouponRateAsync(string code)
    {
        string query = "select Rate from Coupons where Code=@code";
        var parameters = new DynamicParameters();
        parameters.Add("@code", code);
        using (var connection = _context.CreateConnection())
        {
            var result = connection.QueryFirstOrDefault<int>(query, parameters);
            return result;
        }
    }

    public Task<int> GetTotalDiscountCouponCountAsync()
    {
        string query = "select Count(*) From Coupons";
        using (var connection = _context.CreateConnection())
        {
            var result = connection.QueryFirstOrDefault<int>(query);
            return Task.FromResult(result);
        }
    }
}
