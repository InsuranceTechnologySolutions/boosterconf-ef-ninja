﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace BoosterConf.Ef.Ninja.TaskB.Storage.Contexts
{
    public class InsuranceDbContextFactory : IDesignTimeDbContextFactory<InsuranceDbContext>
    {
        public InsuranceDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<InsuranceDbContext>();
            builder.UseSqlServer(
                connectionString: "Server=(localdb)\\mssqllocaldb;Database=BoosterConfEfNinjaTaskOne-TaskB;Trusted_Connection=True;MultipleActiveResultSets=true");

            return new InsuranceDbContext(builder.Options);
        }
    }
}