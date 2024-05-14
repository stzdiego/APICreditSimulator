// Copyright (c) Diego Santacruz. All Rights Reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ApiCreditSimulator.Shared.Bases;

using System.ComponentModel.DataAnnotations;

/// <summary>
/// Defines the <see cref="BaseEntity" />.
/// </summary>
public class BaseEntity
{
    /// <summary>
    /// Gets or sets the Id.
    /// </summary>
    [Key]
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the CreatedAt.
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Gets or sets the UpdatedAt.
    /// </summary>
    public DateTime UpdatedAt { get; set; }

    /// <summary>
    /// Gets or sets the DeletedAt.
    /// </summary>
    public DateTime? DeletedAt { get; set; }
}
