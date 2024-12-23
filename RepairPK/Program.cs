using Microsoft.EntityFrameworkCore;
using RepairPK.Contracts;
using RepairPK.Repository;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RepairPK.Middleware;

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

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Repair API", Version = "v1" });
            });
            

            builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
            builder.Services.AddScoped<IPartRepository, PartRepository>();
            builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();
            builder.Services.AddScoped<IFeedbackRepository, FeedbackRepository>();
            builder.Services.AddScoped<IOrderRepository, OrderRepository>();
            builder.Services.AddScoped<IHardwareRepository, HardwareRepository>();
            builder.Services.AddScoped<IRepairRepository, RepairRepository>();

            builder.Services.AddAutoMapper(typeof(Program));

            var app = builder.Build();

            app.ConfigureExceptionHandler();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting(); // Обязательно добавьте этот вызов

            app.UseAuthorization();

            // Настройка Swagger
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Repair API V1");
                options.RoutePrefix = string.Empty; // Доступ к Swagger UI по корневому URL
            });

            app.MapControllers();
            app.Run();
        }
    }
}