using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RepairPK.Models;

namespace RepairPK.Repository.Configuration
{
    public class HardwareConfiguration : IEntityTypeConfiguration<Hardware>
    {
        public void Configure(EntityTypeBuilder<Hardware> builder)
        {
            builder.HasData(
                new Hardware
                {
                    Id = 1,
                    OrderId = 1,
                    Type = "Motherboard",
                    Manufacturer = "ASUS",
                    Model = "PRIME B550M",
                    SerialNumber = "SN123456789"
                },
                new Hardware
                {
                    Id = 2,
                    OrderId = 2,
                    Type = "Graphics Card",
                    Manufacturer = "NVIDIA",
                    Model = "RTX 3080",
                    SerialNumber = "SN987654321"
                },
                new Hardware
                {
                    Id = 3,
                    OrderId = 3,
                    Type = "Power Supply",
                    Manufacturer = "Corsair",
                    Model = "RM750x",
                    SerialNumber = "SN112233445"
                },
                new Hardware
                {
                    Id = 4,
                    OrderId = 4,
                    Type = "CPU",
                    Manufacturer = "Intel",
                    Model = "i7-11700K",
                    SerialNumber = "SN998877665"
                },
                new Hardware
                {
                    Id = 5,
                    OrderId = 5,
                    Type = "SSD",
                    Manufacturer = "Samsung",
                    Model = "970 EVO Plus 1TB",
                    SerialNumber = "SN554433221"
                }
            );
        }
    }
}
