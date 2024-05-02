using System.Linq.Expressions;
using ApiCreditSimulator.Access.Database;
using ApiCreditSimulator.Shared.Dto;
using ApiCreditSimulator.Shared.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ApiCreditSimulator.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly ILogger<UsersController> _logger;
    private readonly IDatabaseService _databaseService;

    public UsersController(ILogger<UsersController> logger, IDatabaseService databaseService)
    {
        _logger = logger;
        _databaseService = databaseService;
    }

    [HttpGet]
    public IActionResult Get(GetDto dto)
    {
        try
        {
            var user = _databaseService.Find<User>(dto.Id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting users");
            return StatusCode(500);
        }
    }

    [HttpPost]
    public async Task<IActionResult> Post(PostDto<User> dto)
    {
        try
        {
            var createdUser = await _databaseService.Create(dto.Entity!);

            return CreatedAtAction(nameof(Get), new { id = createdUser.Id }, createdUser);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error creating user");
            return StatusCode(500);
        }
    }

    [HttpPut]
    public async Task<IActionResult> Put(PutDto<User> dto)
    {
        try
        {
            if (dto.Entity == null)
            {
                return BadRequest();
            }
            else if (dto.Id != dto.Entity.Id)
            {
                return BadRequest();
            }

            var updatedUser = await _databaseService.Update(dto.Entity!);

            return Ok(updatedUser);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating user");
            return StatusCode(500);
        }
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(DeleteDto<User> dto)
    {
        try
        {
            var user = await _databaseService.Find<User>(dto.Entity!.Id);

            if (user == null)
            {
                return NotFound();
            }

            await _databaseService.Delete(user);

            return NoContent();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error deleting user");
            return StatusCode(500);
        }
    }

    [HttpGet("all")]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var users = await _databaseService.GetAll<User>();

            return Ok(users);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting all users");
            return StatusCode(500);
        }
    }

    [HttpGet("where")]
    public async Task<IActionResult> GetWhere(GetWhereDto<User> dto)
    {
        try
        {
            var users = await _databaseService.GetWhere(dto.Predicate!);

            return Ok(users);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting users");
            return StatusCode(500);
        }
    }
}
