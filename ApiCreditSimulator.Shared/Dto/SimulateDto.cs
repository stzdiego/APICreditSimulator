// Copyright (c) Diego Santacruz. All Rights Reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ApiCreditSimulator.Shared.Dto;

/// <summary>
/// |.
/// </summary>
public class SimulateDto
{
    /// <summary>
    /// Gets or sets the Nickname.
    /// </summary>
    public string Nickname { get; set; } = null!;

    /// <summary>
    /// Gets or sets the FullName.
    /// </summary>
    public string FullName { get; set; } = null!;

    /// <summary>
    /// Gets or sets the Email.
    /// </summary>
    public string Email { get; set; } = null!;

    /// <summary>
    /// Gets or sets the Amount.
    /// </summary>
    public double Amount { get; set; }

    /// <summary>
    /// Gets or sets the Months.
    /// </summary>
    public int Months { get; set; }

    /// <summary>
    /// Gets or sets the Rate.
    /// </summary>
    public double Rate { get; set; }

    /// <summary>
    /// Gets or sets the Frequency.
    /// </summary>
    public int Frequency { get; set; }
}
