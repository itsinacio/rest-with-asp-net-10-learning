using Microsoft.OpenApi;

namespace RestWithASPNET.Configurations;

public static class OpenApiConfig
{
    private static readonly string AppName = "Domine ASP .NET 10 Swagger Docker Kubernetes REST Web API RESTful JWT xUnit Testcontainers React JS do 0 à Azure, GCP e+";
    private static readonly string AppDescription = $"RESTFULL API developed in course: {AppName}";

    public static IServiceCollection AddOpenAPIConfig(this IServiceCollection services)
    {
        services.AddSingleton(new OpenApiInfo
        {
            Title = AppName,
            Version = "v1",
            Description = AppDescription,
            Contact = new OpenApiContact
            {
                Name= "Erudio",
                Url = new Uri("https://pub.erudio.com.br/meus-cursos")
            },
            License = new OpenApiLicense
            {
                Name = "MIT",
                Url = new Uri("https://pub.erudio.com.br/meus-cursos")
            }
        });
        return services;
    }
}
