using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RepairPK.Models;

namespace RepairPK.Repository.Configuration
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasData(
                new Customer
                {
                    Id = 1,
                    Name = "John Doe",
                    PhoneNumber = "1234567890"
                },
                new Customer
                {
                    Id = 2,
                    Name = "Jane Smith",
                    PhoneNumber = "0987654321"
                },
                new Customer
                {
                    Id = 3,
                    Name = "Michael Johnson",
                    PhoneNumber = "1122334455"
                },
                new Customer
                {
                    Id = 4,
                    Name = "Emily Davis",
                    PhoneNumber = "5566778899"
                },
                new Customer
                {
                    Id = 5,
                    Name = "William Brown",
                    PhoneNumber = "6677889900"
                }
            );
        }
    }
}
