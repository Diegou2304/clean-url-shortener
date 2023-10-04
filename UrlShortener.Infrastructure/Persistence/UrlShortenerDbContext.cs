
using UrlShortener.Domain.Common;
using UrlShortener.Infrastructure.Persistence.Configuration;
using Microsoft.EntityFrameworkCore;
using UrlShortener.Domain;

namespace UrlShortener.Infrastructure.Persistence
{
    public class UrlShortenerDbContext : DbContext
    {


        public UrlShortenerDbContext(DbContextOptions<UrlShortenerDbContext> options) : base(options)
        {


        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<AuditModel>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreationDate = DateTime.Now;
                        entry.Entity.CreatedBy = "system";
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        entry.Entity.LastModifiedBy = "system";
                        break;
                }

            }

            return base.SaveChangesAsync(cancellationToken);


        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            new UrlEntityTypeConfiguration()
                .Configure(modelBuilder.Entity<Url>());



        }

        public DbSet<Requests> requests { get; set; }
        public DbSet<Requester> requester { get; set; }
    
    }
}