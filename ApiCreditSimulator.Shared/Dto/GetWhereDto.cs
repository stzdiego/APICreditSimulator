// <copyright file="GetWhereDto.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ApiCreditSimulator.Shared.Dto;
using System.Linq.Expressions;

/// <summary>
/// Defines the <see cref="GetWhereDto{T}" />.
/// </summary>
/// <typeparam name="T">.</typeparam>
public class GetWhereDto<T>
{
    /// <summary>
    /// Gets or sets the Predicate.
    /// </summary>
    public Expression<Func<T, bool>>? Predicate { get; set; }
}
