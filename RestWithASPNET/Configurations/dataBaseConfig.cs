using Microsoft.EntityFrameworkCore;
using RestWithASPNET.Model.Context;
namespace RestWithASPNET.Configurations;

public static class dataBaseConfig
{
    public static IServiceCollection addDataBaseConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        var conectionString = configuration["MSSQLServerSQLConnection:MSSQLServerSQLConnectionString"];
        if(string.IsNullOrEmpty(conectionString)) throw new ArgumentNullException("Connection string 'MSSQLServerSQLConnectionString' not found"); 
        services.AddDbContext<MSSQLContext>(options => options.UseSqlServer(conectionString));
        return services;
    }
}
