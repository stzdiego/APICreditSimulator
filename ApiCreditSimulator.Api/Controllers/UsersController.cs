// <copyright file="UsersController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ApiCreditSimulator.Api.Controllers;

using System.Linq.Expressions;
using ApiCreditSimulator.Access.Database;
using ApiCreditSimulator.Shared.Dto;
using ApiCreditSimulator.Shared.Entities;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly ILogger<UsersController> logger;
    private readonly IDatabaseService databaseService;

    /// <summary>
    /// Initializes a new instance of the <see cref="UsersController"/> class.
    /// </summary>
    /// <param name="logger">Logger.</param>
    /// <param name="databaseService">DatabaseService.</param>
    public UsersController(ILogger<UsersController> logger, IDatabaseService databaseService)
    {
        this.logger = logger;
        this.databaseService = databaseService;
    }

    /// <summary>
    /// The Get.
    /// </summary>
    /// <param name="dto">The dto<see cref="GetDto"/>.</param>
    /// <returns>The <see cref="IActionResult"/>.</returns>
    [HttpGet]
    public IActionResult Get(GetDto dto)
    {
        try
        {
            var user = this.databaseService.Find<User>(dto.Id);

            if (user == null)
            {
                return this.NotFound();
            }

            return this.Ok(user);
        }
        catch (Exception ex)
        {
            this.logger.LogError(ex, "Error getting users");
            return this.StatusCode(500);
        }
    }

    /// <summary>
    /// The Post.
    /// </summary>
    /// <param name="dto">The dto<see cref="PostDto{User}"/>.</param>
    /// <returns>The <see cref="Task{IActionResult}"/>.</returns>
    [HttpPost]
    public async Task<IActionResult> Post(PostDto<User> dto)
    {
        try
        {
            var createdUser = await this.databaseService.Create(dto.Entity!);

            return this.CreatedAtAction(nameof(this.Get), new { id = createdUser.Id }, createdUser);
        }
        catch (Exception ex)
        {
            this.logger.LogError(ex, "Error creating user");
            return this.StatusCode(500);
        }
    }

    /// <summary>
    /// The Put.
    /// </summary>
    /// <param name="dto">The dto<see cref="PutDto{User}"/>.</param>
    /// <returns>The <see cref="Task{IActionResult}"/>.</returns>
    [HttpPut]
    public async Task<IActionResult> Put(PutDto<User> dto)
    {
        try
        {
            if (dto.Entity == null)
            {
                return this.BadRequest();
            }
            else if (dto.Id != dto.Entity.Id)
            {
                return this.BadRequest();
            }

            var updatedUser = await this.databaseService.Update(dto.Entity!);

            return this.Ok(updatedUser);
        }
        catch (Exception ex)
        {
            this.logger.LogError(ex, "Error updating user");
            return this.StatusCode(500);
        }
    }

    /// <summary>
    /// The Delete.
    /// </summary>
    /// <param name="dto">The dto<see cref="DeleteDto{User}"/>.</param>
    /// <returns>The <see cref="Task{IActionResult}"/>.</returns>
    [HttpDelete]
    public async Task<IActionResult> Delete(DeleteDto<User> dto)
    {
        try
        {
            var user = await this.databaseService.Find<User>(dto.Entity!.Id);

            if (user == null)
            {
                return this.NotFound();
            }

            await this.databaseService.Delete(user);

            return this.NoContent();
        }
        catch (Exception ex)
        {
            this.logger.LogError(ex, "Error deleting user");
            return this.StatusCode(500);
        }
    }

    /// <summary>
    /// The GetAll.
    /// </summary>
    /// <returns>The <see cref="Task{IActionResult}"/>.</returns>
    [HttpGet("all")]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var users = await this.databaseService.GetAll<User>();

            return this.Ok(users);
        }
        catch (Exception ex)
        {
            this.logger.LogError(ex, "Error getting all users");
            return this.StatusCode(500);
        }
    }

    /// <summary>
    /// The GetWhere.
    /// </summary>
    /// <param name="dto">The dto<see cref="GetWhereDto{User}"/>.</param>
    /// <returns>The <see cref="Task{IActionResult}"/>.</returns>
    [HttpGet("where")]
    public async Task<IActionResult> GetWhere(GetWhereDto<User> dto)
    {
        try
        {
            var users = await this.databaseService.GetWhere(dto.Predicate!);

            return this.Ok(users);
        }
        catch (Exception ex)
        {
            this.logger.LogError(ex, "Error getting users");
            return this.StatusCode(500);
        }
    }
}
