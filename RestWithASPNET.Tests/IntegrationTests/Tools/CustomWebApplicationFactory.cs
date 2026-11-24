using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;

namespace RestWithASPNET.Tests.IntegrationTests.Tools;

public class CustomWebApplicationFactory<TProgram> : 
    WebApplicationFactory<TProgram> where TProgram : class
{
    private readonly string _conectionString;

    public CustomWebApplicationFactory(string conectionString)
    {
        _conectionString = conectionString;
    }

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureAppConfiguration((context,config) =>
        {
            var dict = new Dictionary<string,string>
            {
                {
                    "MSSQLServerSQLConnection:MSSQLServerSQLConnectionString",
                    _conectionString
                }
            };
            config.AddInMemoryCollection(dict!);
        });
    }
}

