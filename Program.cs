
using Microsoft.EntityFrameworkCore;
using WarehouseAccounting.DB;
using WarehouseAccounting.Interfaces;
using WarehouseAccounting.Services;

namespace WarehouseAccounting
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
            });

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            // Сервисы для работы с базой данных
            string connection = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<MyDbContext>(options => options.UseSqlServer(connection));
            builder.Services.AddTransient<IResourceStorage, ResourceStorage>();
            builder.Services.AddTransient<IUnitOfMeasurementStorage, UnitOfMeasurementStorage>();
            builder.Services.AddTransient<IAdmissionDocumentsStorage, AdmissionDocumentsStorage>();
            builder.Services.AddTransient<IResourceOfAdmissionsStorage, ResourceOfAdmissionsStorage>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseCors("AllowAll");

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
