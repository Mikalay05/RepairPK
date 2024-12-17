using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RepairPK.Models;

namespace RepairPK.Repository.Configuration
{
    public class FeedbackConfiguration : IEntityTypeConfiguration<Feedback>
    {
        public void Configure(EntityTypeBuilder<Feedback> builder)
        {
            builder.HasData(
                new Feedback
                {
                    Id = 1,
                    CustomerId = 1,
                    Rating = 5,
                    Comment = "Отличная работа! Быстро и качественно.",
                    Date = DateTime.UtcNow
                },
                new Feedback
                {
                    Id = 2,
                    CustomerId = 2,
                    Rating = 4,
                    Comment = "Хорошая диагностика, но могли бы сделать скидку.",
                    Date = DateTime.UtcNow
                },
                new Feedback
                {
                    Id = 3,
                    CustomerId = 3,
                    Rating = 5,
                    Comment = "Понравилось обслуживание, рекомендую!",
                    Date = DateTime.UtcNow
                },
                new Feedback
                {
                    Id = 4,
                    CustomerId = 4,
                    Rating = 3,
                    Comment = "Работу сделали, но сроки немного затянули.",
                    Date = DateTime.UtcNow
                },
                new Feedback
                {
                    Id = 5,
                    CustomerId = 5,
                    Rating = 5,
                    Comment = "Супер! Всё работает как надо.",
                    Date = DateTime.UtcNow
                }
            );
        }
    }
}
