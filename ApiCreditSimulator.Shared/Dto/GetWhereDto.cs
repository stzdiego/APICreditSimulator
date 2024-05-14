// Copyright (c) Diego Santacruz. All Rights Reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

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
