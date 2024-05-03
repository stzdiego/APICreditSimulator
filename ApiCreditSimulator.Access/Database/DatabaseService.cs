// <copyright file="DatabaseService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ApiCreditSimulator.Access.Database;
using System.Linq.Expressions;
using ApiCreditSimulator.Access.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

/// <summary>
/// Defines the <see cref="DatabaseService" />.
/// </summary>
public class DatabaseService : IDatabaseService
{
    private readonly IApiCreditSimulatorContext context;
    private readonly ILogger<DatabaseService> logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="DatabaseService"/> class.
    /// </summary>
    /// <param name="context">Context.</param>
    /// <param name="logger">Logger.</param>
    public DatabaseService(IApiCreditSimulatorContext context, ILogger<DatabaseService> logger)
    {
        this.context = context;
        this.logger = logger;
    }

    /// <inheritdoc/>
    public async Task<T> Create<T>(T entity)
        where T : class
    {
        try
        {
            await this.context.Set<T>().AddAsync(entity);
            await this.context.SaveChangesAsync();
            return entity;
        }
        catch (Exception ex)
        {
            this.logger.LogError(ex, "Error creating entity");
            throw;
        }
    }

    /// <inheritdoc/>
    public async Task<T?> Find<T>(int id)
        where T : class
    {
        try
        {
            return await this.context.Set<T>().FindAsync(id);
        }
        catch (Exception ex)
        {
            this.logger.LogError(ex, "Error finding entity");
            throw;
        }
    }

    /// <inheritdoc/>
    public async Task<T> Update<T>(T entity)
        where T : class
    {
        try
        {
            this.context.Set<T>().Update(entity);
            await this.context.SaveChangesAsync();
            return entity;
        }
        catch (Exception ex)
        {
            this.logger.LogError(ex, "Error updating entity");
            throw;
        }
    }

    /// <inheritdoc/>
    public async Task Delete<T>(T entity)
        where T : class
    {
        try
        {
            this.context.Set<T>().Remove(entity);
            await this.context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            this.logger.LogError(ex, "Error deleting entity");
            throw;
        }
    }

    /// <inheritdoc/>
    public async Task<List<T>> GetAll<T>()
        where T : class
    {
        try
        {
            return await this.context.Set<T>().ToListAsync();
        }
        catch (Exception ex)
        {
            this.logger.LogError(ex, "Error getting all entities");
            throw;
        }
    }

    /// <inheritdoc/>
    public async Task<List<T>> GetWhere<T>(Expression<Func<T, bool>> predicate)
        where T : class
    {
        try
        {
            return await this.context.Set<T>().Where(predicate).ToListAsync();
        }
        catch (Exception ex)
        {
            this.logger.LogError(ex, "Error getting entities by predicate");
            throw;
        }
    }

    /// <inheritdoc/>
    public async Task<bool> Exists<T>(int id)
        where T : class
    {
        try
        {
            return await this.context.Set<T>().FindAsync(id) != null;
        }
        catch (Exception ex)
        {
            this.logger.LogError(ex, "Error checking if entity exists");
            throw;
        }
    }
}
