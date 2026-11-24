using RestWithASPNET.Tests.IntegrationTests.Tools;
using Microsoft.AspNetCore.Mvc.Testing;
using FluentAssertions;

namespace RestWithASPNET.Tests.IntegrationTests;

public class ScalarIntegrationTests: 
        IClassFixture<SqlServerFixture>
{
    private readonly HttpClient _client;
    public ScalarIntegrationTests(SqlServerFixture fixture)
    {
        var factory = new CustomWebApplicationFactory<Program>(fixture.ConectionString);
        _client = factory.CreateClient(
            new WebApplicationFactoryClientOptions
            {
                BaseAddress = new Uri("http://localhost")
            }
        );
    }

    [Fact]
    public async Task ScalarUI_ShouldReturnScalarUi()
    {
        // Arrange & Act
        var response = await _client.GetAsync("/scalar/");
        // Assert
        response.EnsureSuccessStatusCode();
        
        var content = await response.Content.ReadAsStringAsync();
        content.Should().Contain("<title>Domine ASP .NET 10 Swagger Docker Kubernetes REST Web API RESTful JWT xUnit Testcontainers React JS do 0 à Azure, GCP e+</title>");
        content.Should().Contain("script src");
    }
}
