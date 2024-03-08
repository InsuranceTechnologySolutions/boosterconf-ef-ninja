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

app.MapGet(
    "/claims",
    async (InsuranceDbContext ctx) =>
    {
        var allItems = await ctx.Claims.ToArrayAsync();
        return allItems.Select(DtoMapper.ToDto);
    }
);
app.MapGet(
    "/claims/{id}",
    async (Guid id, InsuranceDbContext ctx) =>
    {
        var claim = await ctx.Claims.SingleOrDefaultAsync(it => it.ExternalId == id);
        return claim?.ToDto();
    }
);

app.MapGet(
    "/covers",
    async (InsuranceDbContext ctx) =>
    {
        var covers = await ctx.Covers.ToArrayAsync();
        return covers.Select(it => it.ToDto());
    }
);
app.MapGet(
    "/covers/{id}",
    async (Guid id, InsuranceDbContext ctx) => {
        var cover = await ctx.Covers.SingleOrDefaultAsync(it => it.ExternalId == id);
        return cover?.ToDto();
    }
);

app.MapGet(
    "/customers",
    async (InsuranceDbContext ctx) =>
    {
        var customers = await ctx.Customers.ToArrayAsync();
        return customers.Select(it => it.ToDto());
    }
);
app.MapGet(
    "/customers/{id}",
    async (Guid id, InsuranceDbContext ctx) =>
    {
        var customer = await ctx.Customers.SingleOrDefaultAsync(it => it.ExternalId == id);
        return customer?.ToDto();
    }
);

app.Run();
