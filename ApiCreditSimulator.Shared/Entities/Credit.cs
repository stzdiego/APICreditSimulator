// <copyright file="Credit.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ApiCreditSimulator.Shared.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using ApiCreditSimulator.Shared.Bases;

/// <summary>
/// Defines the <see cref="Credit" />.
/// </summary>
public class Credit : BaseEntity
{
    /// <summary>
    /// Gets or sets the Description.
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the Amount.
    /// </summary>
    public decimal Amount { get; set; }

    /// <summary>
    /// Gets or sets the Term.
    /// </summary>
    public int Term { get; set; }

    /// <summary>
    /// Gets or sets the Rate.
    /// </summary>
    public decimal Rate { get; set; }

    /// <summary>
    /// Gets or sets the MonthlyFee.
    /// </summary>
    public decimal MonthlyFee { get; set; }

    /// <summary>
    /// Gets or sets the Total.
    /// </summary>
    public decimal Total { get; set; }

    /// <summary>
    /// Gets or sets the UserId.
    /// </summary>
    [ForeignKey(nameof(User))]
    public int UserId { get; set; }

    /// <summary>
    /// Gets or sets the User.
    /// </summary>
    public User User { get; set; } = null!;
}
