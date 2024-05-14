// Copyright (c) Diego Santacruz. All Rights Reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.Linq.Expressions;

namespace ApiCreditSimulator.Access.Database;

public interface IDatabaseService
{
    Task<T> Create<T>(T entity)
        where T : class;

    Task<T?> Find<T>(int id)
        where T : class;

    Task<T> Update<T>(T entity)
        where T : class;

    Task Delete<T>(T entity)
        where T : class;

    Task<List<T>> GetAll<T>()
        where T : class;

    Task<List<T>> GetWhere<T>(Expression<Func<T, bool>> predicate)
        where T : class;

    Task<bool> Exists<T>(int id)
        where T : class;
}
