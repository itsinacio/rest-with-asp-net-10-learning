using Scalar.AspNetCore;

namespace RestWithASPNET.Configurations;

public static class ScalarConfig
{
        private static readonly string AppName = "Domine ASP .NET 10 Swagger Docker Kubernetes REST Web API RESTful JWT xUnit Testcontainers React JS do 0 à Azure, GCP e+";

        public static WebApplication UseScalarConfiguration(this WebApplication app)
        {
            app.MapScalarApiReference("/scalar",options =>
            {
                options
                .WithTitle(AppName)
                .WithOpenApiRoutePattern("/swagger/v1/swagger.json");
            });
            return app;
        }   
}
