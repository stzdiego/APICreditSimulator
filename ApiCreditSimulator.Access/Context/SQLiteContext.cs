// <copyright file="SQLiteContext.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ApiCreditSimulator.Access.Context;

using ApiCreditSimulator.Shared.Bases;
using ApiCreditSimulator.Shared.Entities;
using Microsoft.EntityFrameworkCore;

/// <summary>
/// Defines the <see cref="SQLiteContext" />.
/// </summary>
public class SQLiteContext : DbContext, IApiCreditSimulatorContext
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SQLiteContext"/> class.
    /// </summary>
    public SQLiteContext()
    {
    }

    /// <summary>
    /// Gets or sets initializes a new instance of the <see cref="SQLiteContext"/> class.
    /// </summary>
    public DbSet<User> Users { get; set; }

    /// <summary>
    /// Gets or sets the Credits.
    /// </summary>
    public DbSet<Credit> Credits { get; set; }

    /// <summary>
    /// Gets or sets the UserLogs.
    /// </summary>
    public DbSet<UserLog> UserLogs { get; set; }

    /// <summary>
    /// The OnConfiguring.
    /// </summary>
    /// <param name="optionsBuilder">The optionsBuilder<see cref="DbContextOptionsBuilder"/>.</param>
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=ApiCreditSimulator.db");
    }

#pragma warning disable SA1202 // ElementsMustBeOrderedByAccess
    /// <summary>
    /// The OnModelCreating.
    /// </summary>
    /// <returns> The <see cref="void"/>. </returns>
    public override int SaveChanges()
    {
        var entries = this.ChangeTracker.Entries().Where(e => e.Entity is BaseEntity && (e.State == EntityState.Added || e.State == EntityState.Modified));

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
#pragma warning restore SA1202 // ElementsMustBeOrderedByAccess
}