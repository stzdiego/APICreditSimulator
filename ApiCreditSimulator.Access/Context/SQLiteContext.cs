// Copyright (c) Diego Santacruz. All Rights Reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ApiCreditSimulator.Access.Context;

using ApiCreditSimulator.Shared.Bases;
using ApiCreditSimulator.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

/// <summary>
/// Defines the <see cref="SQLiteContext" />.
/// </summary>
public class SQLiteContext : DbContext, IApiCreditSimulatorContext
{
    private readonly IConfiguration configuration;

    /// <summary>
    /// Initializes a new instance of the <see cref="SQLiteContext"/> class.
    /// </summary>
    /// <param name="configuration">The configuration<see cref="IConfiguration"/>.</param>
    public SQLiteContext(IConfiguration configuration)
    {
        this.configuration = configuration;
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
        optionsBuilder.UseSqlite(this.configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("ApiCreditSimulator.Api"));
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