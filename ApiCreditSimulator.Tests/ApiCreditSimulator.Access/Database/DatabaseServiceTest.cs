using System.IO.Compression;
using System.Linq.Expressions;
using ApiCreditSimulator.Access.Context;
using ApiCreditSimulator.Access.Database;
using ApiCreditSimulator.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Moq;

namespace ApiCreditSimulator.Tests.ApiCreditSimulator.Access.Database;

public class DatabaseServiceTest
{
    private readonly IServiceProvider serviceProvider;
    private Mock<IApiCreditSimulatorContext> mockIApiCreditSimulatorContext;

    public DatabaseServiceTest()
    {
        var services = new ServiceCollection();

        this.mockIApiCreditSimulatorContext = new Mock<IApiCreditSimulatorContext>();
        var mockLogger = new Mock<ILogger<DatabaseService>>();

        services.AddSingleton(this.mockIApiCreditSimulatorContext.Object);
        services.AddSingleton(mockLogger.Object);

        this.serviceProvider = services.BuildServiceProvider();
    }

    [Fact]
    public async Task Create_Should_Return_Entity()
    {
        // Arrange
        this.mockIApiCreditSimulatorContext.Setup(x => x.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);
        this.mockIApiCreditSimulatorContext.Setup(x => x.Set<User>()).Returns(Mock.Of<DbSet<User>>());
        var databaseService = new DatabaseService(this.serviceProvider.GetService<IApiCreditSimulatorContext>()!, this.serviceProvider.GetService<ILogger<DatabaseService>>()!);
        var entity = new User
        {
            Id = 1,
            Nickname = "nickname",
            FullName = "fullname",
            Email = "email",
        };

        // Act
        var result = await databaseService.Create<User>(entity);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(entity, result);
    }

    [Fact]
    public async Task Create_Should_Throw_Exception()
    {
        // Arrange
        this.mockIApiCreditSimulatorContext.Setup(x => x.SaveChangesAsync(It.IsAny<CancellationToken>())).ThrowsAsync(new Exception());
        this.mockIApiCreditSimulatorContext.Setup(x => x.Set<User>()).Returns(Mock.Of<DbSet<User>>());
        var databaseService = new DatabaseService(this.serviceProvider.GetService<IApiCreditSimulatorContext>()!, this.serviceProvider.GetService<ILogger<DatabaseService>>()!);
        var entity = new User
        {
            Id = 1,
            Nickname = "nickname",
            FullName = "fullname",
            Email = "email",
        };

        // Act
        async Task Act() => await databaseService.Create<User>(entity);

        // Assert
        await Assert.ThrowsAsync<Exception>(Act);
    }

    [Fact]
    public async Task Find_Should_Return_Entity()
    {
        // Arrange
        this.mockIApiCreditSimulatorContext.Setup(x => x.Set<User>()).Returns(Mock.Of<DbSet<User>>());
        this.mockIApiCreditSimulatorContext.Setup(x => x.Set<User>().FindAsync(1)).ReturnsAsync(new User
        {
            Id = 1,
            Nickname = "nickname",
            FullName = "fullname",
            Email = "email",
        });
        var databaseService = new DatabaseService(this.serviceProvider.GetService<IApiCreditSimulatorContext>()!, this.serviceProvider.GetService<ILogger<DatabaseService>>()!);
        var entity = new User
        {
            Id = 1,
            Nickname = "nickname",
            FullName = "fullname",
            Email = "email",
        };

        // Act
        var result = await databaseService.Find<User>(1);

        // Assert
        Assert.NotNull(result);
    }

    [Fact]
    public async Task Find_Should_Throw_Exception()
    {
        // Arrange
        this.mockIApiCreditSimulatorContext.Setup(x => x.Set<User>()).Returns(Mock.Of<DbSet<User>>());
        this.mockIApiCreditSimulatorContext.Setup(x => x.Set<User>().FindAsync(1)).ThrowsAsync(new Exception());
        var databaseService = new DatabaseService(this.serviceProvider.GetService<IApiCreditSimulatorContext>()!, this.serviceProvider.GetService<ILogger<DatabaseService>>()!);

        // Act
        async Task Act() => await databaseService.Find<User>(1);

        // Assert
        await Assert.ThrowsAsync<Exception>(Act);
    }

    [Fact]
    public async Task Update_Should_Return_Entity()
    {
        // Arrange
        this.mockIApiCreditSimulatorContext.Setup(x => x.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);
        this.mockIApiCreditSimulatorContext.Setup(x => x.Set<User>()).Returns(Mock.Of<DbSet<User>>());
        var databaseService = new DatabaseService(this.serviceProvider.GetService<IApiCreditSimulatorContext>()!, this.serviceProvider.GetService<ILogger<DatabaseService>>()!);
        var entity = new User
        {
            Id = 1,
            Nickname = "nickname",
            FullName = "fullname",
            Email = "email",
        };

        // Act
        var result = await databaseService.Update<User>(entity);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(entity, result);
    }

    [Fact]
    public async Task Update_Should_Throw_Exception()
    {
        // Arrange
        this.mockIApiCreditSimulatorContext.Setup(x => x.SaveChangesAsync(It.IsAny<CancellationToken>())).ThrowsAsync(new Exception());
        this.mockIApiCreditSimulatorContext.Setup(x => x.Set<User>()).Returns(Mock.Of<DbSet<User>>());
        var databaseService = new DatabaseService(this.serviceProvider.GetService<IApiCreditSimulatorContext>()!, this.serviceProvider.GetService<ILogger<DatabaseService>>()!);
        var entity = new User
        {
            Id = 1,
            Nickname = "nickname",
            FullName = "fullname",
            Email = "email",
        };

        // Act
        async Task Act() => await databaseService.Update<User>(entity);

        // Assert
        await Assert.ThrowsAsync<Exception>(Act);
    }

    [Fact]
    public async Task Delete_Should_Not_Throw_Exception()
    {
        // Arrange
        this.mockIApiCreditSimulatorContext.Setup(x => x.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);
        this.mockIApiCreditSimulatorContext.Setup(x => x.Set<User>()).Returns(Mock.Of<DbSet<User>>());
        var databaseService = new DatabaseService(this.serviceProvider.GetService<IApiCreditSimulatorContext>()!, this.serviceProvider.GetService<ILogger<DatabaseService>>()!);
        var entity = new User
        {
            Id = 1,
            Nickname = "nickname",
            FullName = "fullname",
            Email = "email",
        };

        // Act
        await databaseService.Delete<User>(entity);

        // Assert
        Assert.True(true);
    }

    [Fact]
    public async Task Delete_Should_Throw_Exception()
    {
        // Arrange
        this.mockIApiCreditSimulatorContext.Setup(x => x.SaveChangesAsync(It.IsAny<CancellationToken>())).ThrowsAsync(new Exception());
        this.mockIApiCreditSimulatorContext.Setup(x => x.Set<User>()).Returns(Mock.Of<DbSet<User>>());
        var databaseService = new DatabaseService(this.serviceProvider.GetService<IApiCreditSimulatorContext>()!, this.serviceProvider.GetService<ILogger<DatabaseService>>()!);
        var entity = new User
        {
            Id = 1,
            Nickname = "nickname",
            FullName = "fullname",
            Email = "email",
        };

        // Act
        async Task Act() => await databaseService.Delete<User>(entity);

        // Assert
        await Assert.ThrowsAsync<Exception>(Act);
    }

    [Fact]
    public async Task GetWhere_Should_Throw_Exception()
    {
        // Arrange
        this.mockIApiCreditSimulatorContext.Setup(x => x.Set<User>()).Returns(Mock.Of<DbSet<User>>());
        this.mockIApiCreditSimulatorContext.Setup(x => x.Set<User>())
            .Throws(new Exception());
        var databaseService = new DatabaseService(this.serviceProvider.GetService<IApiCreditSimulatorContext>()!, this.serviceProvider.GetService<ILogger<DatabaseService>>()!);

        // Act
        async Task Act() => await databaseService.GetWhere<User>(x => x.Id == 1);

        // Assert
        await Assert.ThrowsAsync<Exception>(Act);
    }

    [Fact]
    public async Task Exists_Should_Return_True()
    {
        // Arrange
        this.mockIApiCreditSimulatorContext.Setup(x => x.Set<User>()).Returns(Mock.Of<DbSet<User>>());
        this.mockIApiCreditSimulatorContext.Setup(x => x.Set<User>().FindAsync(1)).ReturnsAsync(new User
        {
            Id = 1,
            Nickname = "nickname",
            FullName = "fullname",
            Email = "email",
        });
        var databaseService = new DatabaseService(this.serviceProvider.GetService<IApiCreditSimulatorContext>()!, this.serviceProvider.GetService<ILogger<DatabaseService>>()!);

        // Act
        var result = await databaseService.Exists<User>(1);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public async Task Exists_Should_Return_False()
    {
        // Arrange
        this.mockIApiCreditSimulatorContext.Setup(x => x.Set<User>()).Returns(Mock.Of<DbSet<User>>());
        var databaseService = new DatabaseService(this.serviceProvider.GetService<IApiCreditSimulatorContext>()!, this.serviceProvider.GetService<ILogger<DatabaseService>>()!);

        // Act
        var result = await databaseService.Exists<User>(0);

        // Assert
        Assert.False(result);
    }
}
