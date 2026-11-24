using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Identity.Client;
using RestWithASPNET.Tests.IntegrationTests.Tools;

namespace RestWithASPNET.Tests.IntegrationTests;

public class SwaggerIntegrationTests : 
        IClassFixture<SqlServerFixture>
{
    private readonly HttpClient _client;
    public SwaggerIntegrationTests(SqlServerFixture fixture)
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
    public async Task SwaggerJson_ShouldReturnSwaggerJson()
    {
        // Arrange & Act
        var response = await _client.GetAsync("/swagger/v1/swagger.json");

        // Assert
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();
        content.Should().NotBeNull();
        content.Should().Contain("/api/person/v1");
    }

    [Fact]
    public async Task SwaggerUi_ShouldReturnSwaggerUi()
    {
        // Arrange & Act
        var response = await _client.GetAsync("/swagger-ui/index.html");
        // Assert
        response.EnsureSuccessStatusCode();
        
        var content = await response.Content.ReadAsStringAsync();
        content.Should().NotBeNull();
        content.Should().Contain("""<div id="swagger-ui">""");
    }
}
