using Microsoft.Extensions.Configuration;

namespace API.Webhooks.Tests.Integration.Utilities;

public static class Config
{
    public static string ConnectionString()
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.Development.json")
            .Build();

        return configuration.GetConnectionString("SqlConnection");
    }
}
