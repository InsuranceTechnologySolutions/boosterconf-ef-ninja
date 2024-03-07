using BoosterConf.Ef.Ninja.Api;
using BoosterConf.Ef.Ninja.Database;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContextPool<InsuranceDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("InsuranceDb"),
        sqlServerOptions =>
        {
            sqlServerOptions.EnableRetryOnFailure();
            sqlServerOptions.MigrationsAssembly(typeof(InsuranceDbContext).Assembly.FullName);
        }
    )
);

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();

var mapper = new DtoMapper();

app.MapGet(
    "/claims",
    (InsuranceDbContext ctx) =>
        ctx.Claims
            .ToArrayAsync()
            .ContinueWith(it => it.Result.Select(mapper.ToDto))
);
app.MapGet(
    "/claims/{id}",
    (Guid externalId, InsuranceDbContext ctx) =>
        ctx.Claims
            .SingleOrDefaultAsync(it => it.ExternalId == externalId)
            .ContinueWith(it => mapper.ToDto(it.Result!))
);

app.MapGet(
    "/covers",
    (InsuranceDbContext ctx) =>
        ctx.Covers
            .ToArrayAsync()
            .ContinueWith(it => it.Result.Select(mapper.ToDto))
);
app.MapGet(
    "/covers/{id}",
    (Guid externalId, InsuranceDbContext ctx) =>
        ctx.Covers
            .SingleOrDefaultAsync(it => it.ExternalId == externalId)
            .ContinueWith(it => mapper.ToDto(it.Result!))
);

app.MapGet(
    "/customers",
    (InsuranceDbContext ctx) =>
        ctx.Customers
            .ToArrayAsync()
            .ContinueWith(it => it.Result.Select(mapper.ToDto))
);
app.MapGet(
    "/customers/{id}",
    (Guid externalId, InsuranceDbContext ctx) =>
        ctx.Customers
            .SingleOrDefaultAsync(it => it.ExternalId == externalId)
            .ContinueWith(it => mapper.ToDto(it.Result!))
);

app.Run();