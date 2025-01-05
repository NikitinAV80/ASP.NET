using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PromoCodeFactory.Core.Domain.Administration;
using PromoCodeFactory.Core.Domain.PromoCodeManagement;
using PromoCodeFactory.DataAccess.Data;

namespace PromoCodeFactory.DataAccess.EntityFramework;

public sealed class DatabaseContext : DbContext
{
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Preference> Preferences { get; set; }
    public DbSet<PromoCode> PromoCodes { get; set; }


    private static bool initDb = false;
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
        if (!initDb)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
            initDb = true;
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<PromoCode>(entity =>
        {
            entity
                .HasOne(p => p.Customer)
                .WithMany(p => p.PromoCodes)
                .HasForeignKey(p => p.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);
            
            entity
                .HasOne(p => p.Preference)
                .WithMany(p => p.PromoCodes)
                .HasForeignKey(p => p.PreferenceId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity
                .HasOne(p => p.Role)
                .WithOne(p => p.Employee)
                .HasForeignKey<Employee>(p => p.RoleId)
                .OnDelete(DeleteBehavior.SetNull);
        });
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);

        optionsBuilder.UseSeeding((context, _) =>
        {
            var employees = Employees.Any();
            
            if (!employees)
            {
                Employees.AddRange(FakeDataFactory.Employees);
                Customers.AddRange(FakeDataFactory.Customers);
                context.SaveChanges();
            }
        })
        .UseAsyncSeeding(async (context, _, cancellationToken) =>
        {
            var employees = await Employees.AnyAsync(cancellationToken: cancellationToken);

            if (!employees)
            {
                Employees.AddRange(FakeDataFactory.Employees);
                Customers.AddRange(FakeDataFactory.Customers);
                await context.SaveChangesAsync(cancellationToken);
            }
        });
    }
}