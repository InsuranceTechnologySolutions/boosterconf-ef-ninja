using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BoosterConf.Ef.Ninja.DbFirstDatabase;

public partial class EfNinjaTaskDContext : DbContext
{
    public EfNinjaTaskDContext()
    {
    }

    public EfNinjaTaskDContext(DbContextOptions<EfNinjaTaskDContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Claim> Claims { get; set; }

    public virtual DbSet<ClaimStatus> ClaimStatuses { get; set; }

    public virtual DbSet<Cover> Covers { get; set; }

    public virtual DbSet<CoverType> CoverTypes { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<CustomerAddress> CustomerAddresses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=EfNinja-TaskD;Trusted_Connection=True;MultipleActiveResultSets=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Claim>(entity =>
        {
            entity.HasIndex(e => e.CoverId, "IX_Claims_CoverId");

            entity.HasIndex(e => e.StatusId, "IX_Claims_StatusId");

            entity.Property(e => e.Amount).HasColumnType("decimal(14, 4)");
            entity.Property(e => e.Description).HasMaxLength(200);

            entity.HasOne(d => d.Cover).WithMany(p => p.Claims).HasForeignKey(d => d.CoverId);

            entity.HasOne(d => d.Status).WithMany(p => p.Claims).HasForeignKey(d => d.StatusId);
        });

        modelBuilder.Entity<ClaimStatus>(entity =>
        {
            entity.Property(e => e.Description).HasMaxLength(200);
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Cover>(entity =>
        {
            entity.HasIndex(e => e.CoverTypeId, "IX_Covers_CoverTypeId");

            entity.HasIndex(e => e.CustomerId, "IX_Covers_CustomerId");

            entity.Property(e => e.Premium).HasColumnType("decimal(14, 4)");

            entity.HasOne(d => d.CoverType).WithMany(p => p.Covers).HasForeignKey(d => d.CoverTypeId);

            entity.HasOne(d => d.Customer).WithMany(p => p.Covers).HasForeignKey(d => d.CustomerId);
        });

        modelBuilder.Entity<CoverType>(entity =>
        {
            entity.Property(e => e.Description).HasMaxLength(200);
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasIndex(e => e.AddressId, "IX_Customers_AddressId");

            entity.HasIndex(e => new { e.FirstName, e.LastName }, "IX_Customers_FirstName_LastName").IsUnique();

            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.LastName).HasMaxLength(100);
            entity.Property(e => e.PhoneNumber).HasMaxLength(100);

            entity.HasOne(d => d.Address).WithMany(p => p.Customers).HasForeignKey(d => d.AddressId);
        });

        modelBuilder.Entity<CustomerAddress>(entity =>
        {
            entity.Property(e => e.City).HasMaxLength(100);
            entity.Property(e => e.Country).HasMaxLength(100);
            entity.Property(e => e.PostalCode).HasMaxLength(100);
            entity.Property(e => e.Street).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
