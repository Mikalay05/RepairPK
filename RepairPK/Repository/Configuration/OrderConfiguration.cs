using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RepairPK.Models;

namespace RepairPK.Repository.Configuration
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasData(
                            new Order
                            {
                                Id = 1,
                                CustomerId = 1,
                                TotalAmount = 250.00m,
                                CompletionDate = new DateTime(2024, 6, 20),
                                PaymentStatus = true
                            },
                            new Order
                            {
                                Id = 2,
                                CustomerId = 2,
                                TotalAmount = 180.00m,
                                CompletionDate = new DateTime(2024, 6, 21),
                                PaymentStatus = false
                            },
                            new Order
                            {
                                Id = 3,
                                CustomerId = 3,
                                TotalAmount = 300.00m,
                                CompletionDate = new DateTime(2024, 6, 22),
                                PaymentStatus = true
                            },
                            new Order
                            {
                                Id = 4,
                                CustomerId = 4,
                                TotalAmount = 90.00m,
                                CompletionDate = new DateTime(2024, 6, 23),
                                PaymentStatus = true
                            },
                            new Order
                            {
                                Id = 5,
                                CustomerId = 5,
                                TotalAmount = 400.00m,
                                CompletionDate = new DateTime(2024, 6, 24),
                                PaymentStatus = false
                            }
                        );
        }
    }
}
