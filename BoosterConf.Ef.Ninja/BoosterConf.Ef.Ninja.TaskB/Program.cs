
using BoosterConf.Ef.Ninja.TaskB.Constants;
using BoosterConf.Ef.Ninja.TaskB.Extensions;
using BoosterConf.Ef.Ninja.TaskB.Storage.Contexts;
using Microsoft.EntityFrameworkCore;

namespace BoosterConf.Ef.Ninja.TaskB
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddCustomServices();

            builder.Services.AddDbContextPool<InsuranceDbContext>(options =>
            {
                var connectionString = builder.Configuration[EnvironmentVariables.DatabaseConnection];
                options.UseSqlServer(connectionString!,
                    sqlServerOptions =>
                    {
                        sqlServerOptions.EnableRetryOnFailure();
                    });
            });

            builder.Services.AddAutoMapper();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}