using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RepairPK.Models;

namespace RepairPK.Repository.Configuration
{
    public class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.HasData(
                            new Appointment
                            {
                                Id = 1,
                                CustomerId = 1,
                                Content = "Консультация по ремонту материнской платы",
                                AppointmentDate = new DateTime(2024, 6, 15, 10, 0, 0)
                            },
                            new Appointment
                            {
                                Id = 2,
                                CustomerId = 2,
                                Content = "Диагностика видеокарты",
                                AppointmentDate = new DateTime(2024, 6, 16, 11, 30, 0)
                            },
                            new Appointment
                            {
                                Id = 3,
                                CustomerId = 3,
                                Content = "Замена блока питания",
                                AppointmentDate = new DateTime(2024, 6, 17, 14, 0, 0)
                            },
                            new Appointment
                            {
                                Id = 4,
                                CustomerId = 4,
                                Content = "Чистка системы охлаждения",
                                AppointmentDate = new DateTime(2024, 6, 18, 9, 30, 0)
                            },
                            new Appointment
                            {
                                Id = 5,
                                CustomerId = 5,
                                Content = "Установка SSD диска",
                                AppointmentDate = new DateTime(2024, 6, 19, 15, 0, 0)
                            }
                        );
        }
    }
}
