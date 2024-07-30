using Discount.Grpc.Data;
using Discount.Grpc.Models;
using Grpc.Core;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Discount.Grpc.Services;

public class DiscountService(DiscountContext dbContext, ILogger<DiscountService> logger)
    : DiscountProtoService.DiscountProtoServiceBase
{
    public override async Task<CouponModel> CreateDiscount(CreateDiscountRequest request, ServerCallContext context)
    {

        var coupon = request.Coupon.Adapt<Coupon>();
        if (coupon is null)
            throw new RpcException(new Status(StatusCode.InvalidArgument, "null coupon is provided"));
        
        var result = await dbContext.Coupons.AddAsync(coupon);
        await dbContext.SaveChangesAsync();
        var model =  result.Entity.Adapt<CouponModel>();
        logger.LogInformation("Coupon is Created Successfully, ProductName: {productName},Amount{amount} ",model.ProductName,model.Amount);
        return model;
    }

    public override async Task<CouponModel> GetDiscount(GetDiscountRequest request, ServerCallContext context)
    {
        var coupon = await dbContext.Coupons.Where(e => e.ProductName == request.ProductName)
            .FirstOrDefaultAsync();
        
        coupon = coupon ?? new Coupon {ProductName = "No Discount", Amount = 0, Description = "No Description"};
        logger.LogInformation("Discount is retrieved for Product:{ProductName}, Amount:{Amount}", coupon.ProductName,
            coupon.Amount);
        return coupon.Adapt<CouponModel>();
    }

    public override async Task<CouponModel> UpdateDiscount(UpdateDiscountRequest request, ServerCallContext context)
    { 
        var oldCoupon = await dbContext.Coupons.Where(e => e.Id == request.Coupon.Id)
            .FirstOrDefaultAsync();
        var newCoupon = request.Coupon.Adapt<Coupon>();
        if (oldCoupon is null || newCoupon is null)
            throw new RpcException(new Status(StatusCode.InvalidArgument, "null coupon is provided"));
        
        var result =  dbContext.Coupons.Update(newCoupon);
        await dbContext.SaveChangesAsync();
        var model =  result.Entity.Adapt<CouponModel>();
        logger.LogInformation("Coupon is Updated Successfully, ProductName: {productName},Amount{amount} ",model.ProductName,model.Amount);
        return model;    
    }

    public override async Task<DeleteDiscountResponse> DeleteDiscount(DeleteDiscountRequest request,
        ServerCallContext context)
    {
        var coupon = await dbContext.Coupons.Where(e => e.ProductName == request.ProductName)
            .FirstOrDefaultAsync();
        
        if (coupon is null)
            throw new RpcException(new Status(StatusCode.InvalidArgument, "null coupon is provided"));
        
        var result =  dbContext.Coupons.Remove(coupon);
        await dbContext.SaveChangesAsync();
        logger.LogInformation("Coupon is Deleted Successfully, ProductName: {productName}",coupon.ProductName);
        return new DeleteDiscountResponse
        {
            IsSuccess = true
        };    
    }
}