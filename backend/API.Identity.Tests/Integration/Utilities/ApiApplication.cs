﻿using API.Identity.Infrastructure.Database;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;

namespace API.Identity.Tests.Integration.Utilities;

public class ApiApplication : WebApplicationFactory<Program>
{
    protected override IHost CreateHost(IHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            services.RemoveAll(typeof(DbContextOptions<EFSqlServerContext>));
            services.AddDbContext<EFSqlServerContext>(options => options.UseSqlServer(Config.ConnectionString()));
        });
        return base.CreateHost(builder);
    }
}
