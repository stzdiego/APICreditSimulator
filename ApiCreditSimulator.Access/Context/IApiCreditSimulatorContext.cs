// <copyright file="IApiCreditSimulatorContext.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ApiCreditSimulator.Access.Context;

using System.Collections.Generic;
using ApiCreditSimulator.Shared.Entities;
using Microsoft.EntityFrameworkCore;

/// <summary>
/// Defines the <see cref="IApiCreditSimulatorContext" />.
/// </summary>
public interface IApiCreditSimulatorContext
{
    /// <summary>
    /// Gets or sets the Users.
    /// </summary>
    DbSet<User> Users { get; set; }

    /// <summary>
    /// Gets or sets the Credits.
    /// </summary>
    DbSet<Credit> Credits { get; set; }

    /// <summary>
    /// Gets or sets the UserLogs.
    /// </summary>
    DbSet<UserLog> UserLogs { get; set; }

    /// <summary>
    /// The SaveChanges.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// The Set.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    DbSet<T> Set<T>()
        where T : class;
}
