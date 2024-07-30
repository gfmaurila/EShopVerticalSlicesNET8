﻿using API.Ordering.Infrastructure.Database.Mappings;
using API.Ordering.Infrastructure.Domain;
using Microsoft.EntityFrameworkCore;

namespace API.Ordering.Infrastructure.Database;

public class EFSqlServerContext : DbContext
{
    public EFSqlServerContext()
    { }

    public EFSqlServerContext(DbContextOptions<EFSqlServerContext> options) : base(options)
    { }

    public virtual DbSet<Article> Article { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ArticleConfiguration());
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLoggerFactory(_loggerFactory);
        base.OnConfiguring(optionsBuilder);
    }

    public static readonly Microsoft.Extensions.Logging.LoggerFactory _loggerFactory = new LoggerFactory(new[] {
        new Microsoft.Extensions.Logging.Debug.DebugLoggerProvider()
    });
}
