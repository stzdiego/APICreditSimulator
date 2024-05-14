// Copyright (c) Diego Santacruz. All Rights Reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ApiCreditSimulator.Api.Controllers;

using ApiCreditSimulator.Access.Database;
using ApiCreditSimulator.Shared.Dto;
using ApiCreditSimulator.Shared.Entities;
using Microsoft.AspNetCore.Mvc;

/// <summary>
/// Controller for credits.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class CreditsController : ControllerBase
{
    private readonly ILogger<CreditsController> logger;
    private readonly IDatabaseService databaseService;

    /// <summary>
    /// Initializes a new instance of the <see cref="CreditsController"/> class.
    /// </summary>
    /// <param name="logger">Logger.</param>
    /// <param name="databaseService">DatabaseService.</param>
    public CreditsController(ILogger<CreditsController> logger, IDatabaseService databaseService)
    {
        this.logger = logger;
        this.databaseService = databaseService;
    }

    /// <summary>
    /// The GetSimulate.
    /// </summary>
    /// <param name="dto">The dto<see cref="SimulateDto"/>.</param>
    /// <returns>The <see cref="Task{IActionResult}"/>.</returns>
    [HttpPost]
    public async Task<IActionResult> PostSimulate(SimulateDto dto)
    {
        User user;
        SimulateResponseDto responseDto;

        try
        {
            var users = await this.databaseService.GetWhere<User>(x => x.Email == dto.Email);

            if (users == null || !users.Any())
            {
                user = new User
                {
                    Nickname = dto.Nickname,
                    FullName = dto.FullName,
                    Email = dto.Email,
                };

                await this.databaseService.Create<User>(user);
            }
            else
            {
                user = users.First();
            }

            var amount = dto.Amount;
            var months = dto.Months;
            var rate = dto.Rate;
            var frequency = dto.Frequency;

            var monthlyFee = amount * (rate / 100) / (1 - Math.Pow(1 + (rate / 100), -months));
            var totalInterest = (monthlyFee * months) - amount;
            var annualNominalRate = rate;
            var annualEffectiveRate = Math.Pow(1 + ((rate / 100) / frequency), frequency) - 1;
            var totalPayment = amount + totalInterest;

            responseDto = new SimulateResponseDto
            {
                MonthlyFee = monthlyFee,
                Amount = amount,
                TotalInterest = totalInterest,
                AnnualNominalRate = annualNominalRate,
                AnnualEffectiveRate = annualEffectiveRate,
                TotalPayment = totalPayment,
            };

            return this.Ok(responseDto);
        }
        catch (Exception ex)
        {
            this.logger.LogError(ex, "Error getting simulate");
            return this.StatusCode(500);
        }
    }
}
