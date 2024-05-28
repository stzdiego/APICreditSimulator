
using System.Linq.Expressions;
using ApiCreditSimulator.Access.Database;
using ApiCreditSimulator.Api.Controllers;
using ApiCreditSimulator.Shared.Dto;
using ApiCreditSimulator.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Moq;

namespace ApiCreditSimulator.Tests.ApiCreditSimulator.Api.Controllers;

public class CreditsControllerTest
{
    private readonly IServiceProvider serviceProvider;
    private Mock<IDatabaseService> moqDatabaseService;

    public CreditsControllerTest()
    {
        var service = new ServiceCollection();
        var mockLogger = new Mock<ILogger<CreditsController>>();
        this.moqDatabaseService = new Mock<IDatabaseService>();

        service.AddSingleton<ILogger<CreditsController>>(mockLogger.Object);
        service.AddSingleton<IDatabaseService>(this.moqDatabaseService.Object);

        this.serviceProvider = service.BuildServiceProvider();
    }

    [Fact]
    public async Task PostSimulate_Should_Create_User()
    {
        // Arrange
        var controller = new CreditsController(this.serviceProvider.GetService<ILogger<CreditsController>>(), this.serviceProvider.GetService<IDatabaseService>());
        var simulateDto = new SimulateDto
        {
            Nickname = "nickname",
            FullName = "fullname",
            Email = "email",
        };

        this.moqDatabaseService.Setup(x => x.GetWhere<User>(It.IsAny<Expression<Func<User, bool>>>())).ReturnsAsync(new List<User>());

        // Act
        var result = await controller.PostSimulate(simulateDto);

        // Assert
        Assert.IsType<OkObjectResult>(result);
        this.moqDatabaseService.Verify(x => x.Create<User>(It.IsAny<User>()), Times.Once);
    }

    [Fact]
    public async Task PostSimulate_Should_Not_Create_User()
    {
        // Arrange
        var controller = new CreditsController(this.serviceProvider.GetService<ILogger<CreditsController>>(), this.serviceProvider.GetService<IDatabaseService>());
        var simulateDto = new SimulateDto
        {
            Nickname = "nickname",
            FullName = "fullname",
            Email = "email",
        };

        this.moqDatabaseService.Setup(x => x.GetWhere<User>(It.IsAny<Expression<Func<User, bool>>>())).ReturnsAsync(new List<User> { new User() });

        // Act
        var result = await controller.PostSimulate(simulateDto);

        // Assert
        Assert.IsType<OkObjectResult>(result);
        this.moqDatabaseService.Verify(x => x.Create<User>(It.IsAny<User>()), Times.Never);
    }

    [Fact]
    public async Task PostSimulate_Should_Return_BadRequest()
    {
        // Arrange
        var controller = new CreditsController(this.serviceProvider.GetService<ILogger<CreditsController>>(), this.serviceProvider.GetService<IDatabaseService>());
        var simulateDto = new SimulateDto
        {
            Nickname = "nickname",
            FullName = "fullname",
            Email = "email",
        };

        this.moqDatabaseService.Setup(x => x.GetWhere<User>(It.IsAny<Expression<Func<User, bool>>>())).Throws(new Exception());

        // Act
        var result = await controller.PostSimulate(simulateDto);

        // Assert
        Assert.Equal(500, (result as StatusCodeResult)?.StatusCode);
    }
}
