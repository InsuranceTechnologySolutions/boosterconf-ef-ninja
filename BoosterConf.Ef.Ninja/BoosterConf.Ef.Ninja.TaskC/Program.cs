using BoosterConf.Ef.Ninja.TaskC.Constants;
using BoosterConf.Ef.Ninja.TaskC.Extensions;
using BoosterConf.Ef.Ninja.TaskC.Storage;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCustomServices();
builder.Services.AddAutoMapper();

builder.Services.AddDbContextPool<InsuranceDbContext>(options =>
{
    var connectionString = builder.Configuration[EnvironmentVariables.DatabaseConnection];
    options.UseSqlServer(
        connectionString!,
        sqlServerOptions =>
        {
            sqlServerOptions.EnableRetryOnFailure();
        }
    );
});

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();