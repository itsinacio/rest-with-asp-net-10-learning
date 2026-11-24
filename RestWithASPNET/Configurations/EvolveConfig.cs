using EvolveDb;
using Microsoft.Data.SqlClient;
using Serilog;

namespace RestWithASPNET.Configurations;

public static class EvolveConfig
{
    public static IServiceCollection AddEvolveConfiguration(
        this IServiceCollection services,
        IConfiguration configuration,
        IWebHostEnvironment environment)
    {
        if (environment.IsDevelopment())
        {
            var conectionString = configuration["MSSQLServerSQLConnection:MSSQLServerSQLConnectionString"];
            if (string.IsNullOrEmpty(conectionString)) throw new ArgumentNullException("Connection string 'MSSQLServerSQLConnectionString' not found");
            try
            {
                ExecuteMigrations(conectionString);
            }
            catch(Exception ex)
            {
                Log.Error(ex, "An error occurred while migrating the database.");
                throw;            
            }
        }
        return services;
    }
    public static void ExecuteMigrations(string ConectionString)
    {
        using var evolveConnection = new SqlConnection(ConectionString);
        var evolve = new Evolve(
            evolveConnection,
            msg => Log.Information(msg)){
            Locations = new List<string> {"db/migrations","db/dataset"},
            IsEraseDisabled = true
            };
        evolve.Migrate();
    }
}
