// <copyright file="User.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ApiCreditSimulator.Shared.Entities;
using ApiCreditSimulator.Shared.Bases;
using Microsoft.EntityFrameworkCore;

/// <summary>
/// Defines the <see cref="User" />.
/// </summary>
[Index(nameof(Nickname), IsUnique = true)]
public class User : BaseEntity
{
    /// <summary>
    /// Gets or sets the Nickname.
    /// </summary>
    public string Nickname { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the FullName.
    /// </summary>
    public string FullName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the Email.
    /// </summary>
    public string Email { get; set; } = string.Empty;
}
