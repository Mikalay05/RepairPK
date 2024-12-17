using Microsoft.EntityFrameworkCore;
using RepairPK.Contracts;
using RepairPK.Repository;

namespace RepairPK
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var connectionString = builder.Configuration.GetConnectionString("MySQLinDB");
            builder.Services.AddDbContextPool<RepositoryContext>(
                options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

            builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
            builder.Services.AddScoped<IPartRepository, PartRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.MapControllers();
            app.UseAuthorization();


            app.Run();
        }
    }
}
