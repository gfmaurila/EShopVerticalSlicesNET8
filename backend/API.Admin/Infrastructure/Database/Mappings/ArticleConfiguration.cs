using API.Admin.Extensions;
using API.Admin.Infrastructure.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Admin.Infrastructure.Database.Mappings;

public class ArticleConfiguration : IEntityTypeConfiguration<Article>
{
    public void Configure(EntityTypeBuilder<Article> builder)
    {
        builder.ConfigureBaseEntity();

        builder
            .Property(entity => entity.Title)
            .IsRequired() // NOT NULL
            .IsUnicode(false);

        builder
            .Property(entity => entity.Description)
            .IsRequired() // NOT NULL
            .IsUnicode(false);

        builder
            .Property(entity => entity.CreatedOnUtc)
            .IsRequired() // NOT NULL
            .HasColumnType("DATE");

        builder
            .Property(entity => entity.PublishedOnUtc)
            .HasColumnType("DATE");
    }
}
