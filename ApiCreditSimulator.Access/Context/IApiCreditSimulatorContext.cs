
using System.Collections.Generic;
using ApiCreditSimulator.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiCreditSimulator.Access.Context;

public interface IApiCreditSimulatorContext
{
    DbSet<User> Users { get; set; }
    DbSet<Credit> Credits { get; set; }
    DbSet<UserLog> UserLogs { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    DbSet<T> Set<T>() where T : class;
}
