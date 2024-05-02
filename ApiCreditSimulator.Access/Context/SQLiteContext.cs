using ApiCreditSimulator.Shared.Bases;
using ApiCreditSimulator.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiCreditSimulator.Access.Context;

public class SQLiteContext : DbContext, IApiCreditSimulatorContext
{
    public SQLiteContext()
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Credit> Credits { get; set; }
    public DbSet<UserLog> UserLogs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=ApiCreditSimulator.db");
    }

    public override int SaveChanges()
    {
        var entries = ChangeTracker.Entries().Where(e => e.Entity is BaseEntity && (e.State == EntityState.Added || e.State == EntityState.Modified));

        foreach (var entityEntry in entries)
        {
            ((BaseEntity)entityEntry.Entity).UpdatedAt = DateTime.Now;

            if (entityEntry.State == EntityState.Added)
            {
                ((BaseEntity)entityEntry.Entity).CreatedAt = DateTime.Now;
            }
        }

        return base.SaveChanges();
    }
}