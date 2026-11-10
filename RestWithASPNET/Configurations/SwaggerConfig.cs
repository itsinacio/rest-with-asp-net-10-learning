using Microsoft.OpenApi;

namespace RestWithASPNET.Configurations;

public static class SwaggerConfig
{
    private static readonly string AppName = "Domine ASP .NET 10 Swagger Docker Kubernetes REST Web API RESTful JWT xUnit Testcontainers React JS do 0 à Azure, GCP e+";
    private static readonly string AppDescription = $"RESTFULL API developed in course: {AppName}";

    public static IServiceCollection AddSwaggerConfig(this IServiceCollection services)
    {
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1",new OpenApiInfo
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
            options.CustomSchemaIds(type => type.FullName);
        });
        return services;
    }

    public static IApplicationBuilder UseSwaggerSpecification(this IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json","v1");
            options.RoutePrefix = "swagger-ui";
            options.DocumentTitle = AppName;
        });
        return app;
    }
}
