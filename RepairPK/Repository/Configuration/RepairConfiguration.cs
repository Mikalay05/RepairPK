using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RepairPK.Models;

namespace RepairPK.Repository.Configuration
{
    public class RepairConfiguration : IEntityTypeConfiguration<Repair>
    {
        public void Configure(EntityTypeBuilder<Repair> builder) 
        {
            builder.HasData(
                new Repair
                {
                    Id = 1,
                    HardwareId = 1,
                    RepairDate = new DateTime(2024, 6, 25),
                    Description = "Замена конденсаторов на материнской плате",
                    Cost = 120.00m,
                    PartId = 1,
                    CountPart = 4
                },
                new Repair
                {
                    Id = 2,
                    HardwareId = 2,
                    RepairDate = new DateTime(2024, 6, 26),
                    Description = "Пайка чипа видеокарты",
                    Cost = 200.00m,
                    PartId = 2,
                    CountPart = 1
                },
                new Repair
                {
                    Id = 3,
                    HardwareId = 3,
                    RepairDate = new DateTime(2024, 6, 27),
                    Description = "Замена блока питания на новый",
                    Cost = 150.00m,
                    PartId = 3,
                    CountPart = 1
                },
                new Repair
                {
                    Id = 4,
                    HardwareId = 4,
                    RepairDate = new DateTime(2024, 6, 28),
                    Description = "Установка системы охлаждения для процессора",
                    Cost = 90.00m,
                    PartId = 4,
                    CountPart = 2
                },
                new Repair
                {
                    Id = 5,
                    HardwareId = 5,
                    RepairDate = new DateTime(2024, 6, 29),
                    Description = "Установка SSD и перенос данных",
                    Cost = 80.00m,
                    PartId = 5,
                    CountPart = 1
                }
            );
        }
    }
}
