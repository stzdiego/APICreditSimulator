using ApiCreditSimulator.Access.Context;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ApiCreditSimulator.Tests.Integrations;
public class DatabaseTest
{
    private readonly IServiceProvider serviceProvider;

    public DatabaseTest()
    {
        var services = new ServiceCollection();
        var config = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string?>
            {
                    { "ConnectionStrings:DefaultConnection", "Data Source=:memory:"},
            })
            .Build();
        services.AddSingleton<IConfiguration>(config);
        serviceProvider = services.BuildServiceProvider();
    }

    [Fact]
    public void SaveChanges_Should_Save()
    {
        // Arrange
        SQLiteContext context = new SQLiteContext(this.serviceProvider.GetService<IConfiguration>()!);

        // Act
        var result = context.SaveChanges();

        // Assert
        Assert.Equal(0, result);
    }
}
