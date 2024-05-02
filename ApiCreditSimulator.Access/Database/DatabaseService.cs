using System.Linq.Expressions;
using ApiCreditSimulator.Access.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ApiCreditSimulator.Access.Database;

public class DatabaseService : IDatabaseService
{
    private readonly IApiCreditSimulatorContext _context;
    private readonly ILogger<DatabaseService> _logger;

    public DatabaseService(IApiCreditSimulatorContext context, ILogger<DatabaseService> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<T> Create<T>(T entity) where T : class
    {
        try
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error creating entity");
            throw;
        }
    }

    public async Task<T?> Find<T>(int id) where T : class
    {
        try
        {
            return await _context.Set<T>().FindAsync(id);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error finding entity");
            throw;
        }
    }

    public async Task<T> Update<T>(T entity) where T : class
    {
        try
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating entity");
            throw;
        }
    }

    public async Task Delete<T>(T entity) where T : class
    {
        try
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error deleting entity");
            throw;
        }
    }

    public async Task<List<T>> GetAll<T>() where T : class
    {
        try
        {
            return await _context.Set<T>().ToListAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting all entities");
            throw;
        }
    }

    public async Task<List<T>> GetWhere<T>(Expression<Func<T, bool>> predicate) where T : class
    {
        try
        {
            return await _context.Set<T>().Where(predicate).ToListAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting entities by predicate");
            throw;
        }
    }

    public async Task<bool> Exists<T>(int id) where T : class
    {
        try
        {
            return await _context.Set<T>().FindAsync(id) != null;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error checking if entity exists");
            throw;
        }
    }
}
