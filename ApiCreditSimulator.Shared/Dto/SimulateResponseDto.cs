// Copyright (c) Diego Santacruz. All Rights Reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ApiCreditSimulator.Shared.Dto;

/// <summary>
/// Simulate response dto.
/// </summary>
public class SimulateResponseDto
{
    /// <summary>
    /// Gets or sets the MonthlyFee.
    /// </summary>
    public double MonthlyFee { get; set; }

    /// <summary>
    /// Gets or sets the Amount.
    /// </summary>
    public double Amount { get; set; }

    /// <summary>
    /// Gets or sets the TotalInterest.
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
}
