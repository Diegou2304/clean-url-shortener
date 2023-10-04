using UrlShortener.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UrlShortener.Domain;

namespace UrlShortener.Infrastructure.Persistence.Configuration
{
    public class UrlEntityTypeConfiguration : IEntityTypeConfiguration<Url>
    {
        public void Configure(EntityTypeBuilder<Url> builder)
        {
            builder
                .HasMany(r => r.Requesters)
                .WithMany(u => u.Urls)
                .UsingEntity<Requests>();

        }
    }
}
