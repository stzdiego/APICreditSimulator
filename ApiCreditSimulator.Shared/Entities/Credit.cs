// Copyright (c) Diego Santacruz. All Rights Reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

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
    public double Amount { get; set; }

    /// <summary>
    /// Gets or sets the MonthlyFee.
    /// </summary>
    public double TotalInterest { get; set; }

    /// <summary>
    /// Gets or sets the AnnualNominalRate.
    /// </summary>
    public double AnnualNominalRate { get; set; }

    /// <summary>
    /// Gets or sets the AnnualEffectiveRate.
    /// </summary>
    public double AnnualEffectiveRate { get; set; }

    /// <summary>
    /// Gets or sets the TotalPayment.
    /// </summary>
    public double TotalPayment { get; set; }

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
