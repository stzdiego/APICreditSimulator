namespace ApiCreditSimulator.Tests;
using ApiCreditSimulator.Access.Context;
using ApiCreditSimulator.Access.Database;
using ApiCreditSimulator.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;

/// <summary>
/// Defines the <see cref="DatabaseServiceTests" />.
/// </summary>
public class DatabaseServiceTests
{
    private readonly Mock<IApiCreditSimulatorContext> contextMock;
    private readonly Mock<ILogger<DatabaseService>> loggerMock;
    private readonly DatabaseService databaseService;

    /// <summary>
    /// Initializes a new instance of the <see cref="DatabaseServiceTests"/> class.
    /// </summary>
    public DatabaseServiceTests()
    {
        this.contextMock = new Mock<IApiCreditSimulatorContext>();
        this.loggerMock = new Mock<ILogger<DatabaseService>>();
        this.databaseService = new DatabaseService(this.contextMock.Object, this.loggerMock.Object);
    }

    /// <summary>
    /// The Create_WhenCalled_ShouldCreateEntity.
    /// </summary>
    /// <returns>The <see cref="Task"/>.</returns>
    [Fact]
    public async Task Create_WhenCalled_ShouldCreateEntity()
    {
        // Arrange
        var entity = new User();

        this.contextMock.Setup(x => x.Set<User>()).Returns(Mock.Of<DbSet<User>>());

        // Act
        var result = await this.databaseService.Create(entity);

        // Assert
        Assert.NotNull(result);
    }

    /// <summary>
    /// The Delete_WhenCalled_ShouldDeleteEntity.
    /// </summary>
    /// <returns>The <see cref="Task"/>.</returns>
    // [Fact]
    // public async Task Find_WhenCalled_ShouldFindEntity()
    // {
    //     // Arrange
    //     var entity = new User();
    //     var dbSetMock = new Mock<DbSet<User>>();

    //     dbSetMock.Setup(x => x.FindAsync(It.IsAny<int>(), default)).ReturnsAsync(entity);
    //     this.contextMock.Setup(x => x.Set<User>()).Returns(dbSetMock.Object);

    //     // Act
    //     var result = await this.databaseService.Find<User>(1);

    //     // Assert
    //     Assert.NotNull(result);
    // }
}
