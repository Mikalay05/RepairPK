using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RepairPK.Models;

namespace RepairPK.Repository.Configuration
{
    public class PartConfiguration : IEntityTypeConfiguration<Part>
    {
        public void Configure(EntityTypeBuilder<Part> builder)
        {
            builder.HasData(
                new Part
                {
                    Id = 1,
                    Name = "SSD 512GB",
                    QuantityAvailable = 10,
                    Price = 120.50m
                },
                new Part
                {
                    Id = 2,
                    Name = "Power Supply 600W",
                    QuantityAvailable = 5,
                    Price = 75.00m
                },
                new Part
                {
                    Id = 3,
                    Name = "RAM 16GB DDR4",
                    QuantityAvailable = 20,
                    Price = 89.99m
                },
                new Part
                {
                    Id = 4,
                    Name = "CPU Intel i5-12400F",
                    QuantityAvailable = 7,
                    Price = 199.99m
                },
                new Part
                {
                    Id = 5,
                    Name = "GPU Nvidia RTX 3060",
                    QuantityAvailable = 3,
                    Price = 399.99m
                }
            );
        }
    }
}
