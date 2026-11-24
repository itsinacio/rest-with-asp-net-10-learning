using RestWithASPNET.Configurations;
using Testcontainers.MsSql;

namespace RestWithASPNET.Tests.IntegrationTests.Tools;

public class SqlServerFixture : IAsyncLifetime
{
    public MsSqlContainer container {get;}

    public string ConectionString => container.GetConnectionString();

    public SqlServerFixture()
    {
        container = new MsSqlBuilder()
                    .WithPassword("Inacio12314")
                    .Build();
    }
    public async Task InitializeAsync()
    {
        await container.StartAsync();
        EvolveConfig.ExecuteMigrations(ConectionString);
    }
    public async Task DisposeAsync()
    {
        await container.DisposeAsync();
    }


}
