using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Write.Api.Data.Configurations;

public class NewsConfiguration : IEntityTypeConfiguration<Entities.News>
{
    public void Configure(EntityTypeBuilder<Entities.News> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .IsRequired()
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Title)
                    .IsRequired();
        
        builder.Property(x => x.ShortDesc)
            .IsRequired();
        
        builder.Property(x => x.LongDesc)
            .IsRequired();
        
        builder.Property(x => x.Published)
            .IsRequired();
        
        builder.Property(x => x.CreatedOnUtc)
            .IsRequired()
            .HasDefaultValue(DateTimeOffset.UtcNow);
    }
}
