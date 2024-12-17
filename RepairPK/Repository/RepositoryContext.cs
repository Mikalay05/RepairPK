using Microsoft.EntityFrameworkCore;
using RepairPK.Models;
using RepairPK.Repository.Configuration;
using System.Data.Common;

namespace RepairPK.Repository
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options) : base(options) { }
        public DbSet<Customer> Customers { get; set; } = null!;
        public DbSet<Appointment> Appointments { get; set; } = null!;
        public DbSet<Feedback> Feedbacks { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<Hardware> Hardwares { get; set; } = null!;
        public DbSet<Part> Parts { get; set; } = null!;
        public DbSet<Repair> Repairs { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AppointmentConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new PartConfiguration());
            modelBuilder.ApplyConfiguration(new FeedbackConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new HardwareConfiguration());
            modelBuilder.ApplyConfiguration(new RepairConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
