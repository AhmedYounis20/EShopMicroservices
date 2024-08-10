using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ordering.Domain.Enums;
using Ordering.Domain.Models;
using Ordering.Domain.ValueObjects;

namespace Ordering.Infrastructure.Data;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).HasConversion(orderId => orderId.Value, dbId => OrderId.Of(dbId));
        builder.HasOne<Customer>().WithMany().HasForeignKey(e => e.CustomerId).IsRequired();
        builder.HasMany<OrderItem>(e => e.OrderItems).WithOne().HasForeignKey(e=>e.OrderId);
        builder.ComplexProperty(e => e.OrderName, newBuilder =>
        {
            newBuilder.Property(e => e.Value).HasColumnName(nameof(Order.OrderName)).HasMaxLength(100).IsRequired();
        });
        builder.ComplexProperty(e => e.ShippingAddress, newBuilder =>
        {
            newBuilder.Property(e => e.FirstName).HasMaxLength(50).IsRequired();
            newBuilder.Property(e => e.LastName).HasMaxLength(50).IsRequired();
            newBuilder.Property(e => e.EmailAddress).HasMaxLength(50).IsRequired();
            newBuilder.Property(e => e.AddressLine).HasMaxLength(50).IsRequired();
            newBuilder.Property(e => e.Country).HasMaxLength(50).IsRequired();
            newBuilder.Property(e => e.State).HasMaxLength(50).IsRequired();
            newBuilder.Property(e => e.ZipCode).HasMaxLength(5).IsRequired();
        });
        builder.ComplexProperty(e => e.BillingAddress, newBuilder =>
        {
            newBuilder.Property(e => e.FirstName).HasMaxLength(50).IsRequired();
            newBuilder.Property(e => e.LastName).HasMaxLength(50).IsRequired();
            newBuilder.Property(e => e.EmailAddress).HasMaxLength(50).IsRequired();
            newBuilder.Property(e => e.AddressLine).HasMaxLength(50).IsRequired();
            newBuilder.Property(e => e.Country).HasMaxLength(50).IsRequired();
            newBuilder.Property(e => e.State).HasMaxLength(50).IsRequired();
            newBuilder.Property(e => e.ZipCode).HasMaxLength(5).IsRequired();
        });
        builder.ComplexProperty(e => e.Payment, newBuilder =>
        {
            newBuilder.Property(e => e.CardName).HasMaxLength(50).IsRequired();
            newBuilder.Property(e => e.CardNumber).HasMaxLength(24).IsRequired();
            newBuilder.Property(e => e.Expiration).HasMaxLength(10).IsRequired();
            newBuilder.Property(e => e.Cvv).HasMaxLength(3).IsRequired();
            newBuilder.Property(e => e.PaymentMethod).HasMaxLength(50).IsRequired();
        });
        builder.Property(e => e.Status).HasDefaultValue(OrderStatus.Pending).HasConversion(e => e.ToString(),
            dbStatus => (OrderStatus) Enum.Parse(typeof(OrderStatus), dbStatus));
    }
}