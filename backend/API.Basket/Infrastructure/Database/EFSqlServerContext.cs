﻿using API.Basket.Domain.User;
using API.Basket.Infrastructure.Database.Mappings;
using Microsoft.EntityFrameworkCore;

namespace API.Basket.Infrastructure.Database;

public class EFSqlServerContext : DbContext
{
    public EFSqlServerContext()
    { }

    public EFSqlServerContext(DbContextOptions<EFSqlServerContext> options) : base(options)
    { }

    public virtual DbSet<UserEntity> User { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLoggerFactory(_loggerFactory);
        base.OnConfiguring(optionsBuilder);
    }

    public static readonly LoggerFactory _loggerFactory = new LoggerFactory(new[] {
        new Microsoft.Extensions.Logging.Debug.DebugLoggerProvider()
    });
}
