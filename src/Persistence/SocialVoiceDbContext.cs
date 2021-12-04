using Application.Common.Interfaces;
using Common;
using Domain.Common;
using Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Threading;
using System.Threading.Tasks;

namespace Persistence
{
    public class SocialVoiceDbContext : DbContext, ISocialVoiceDbContext
    {
        private readonly IDateTime _dateTime;

        public SocialVoiceDbContext(
            DbContextOptions<SocialVoiceDbContext> options,
            IDateTime dateTime
        ) : base(options)
        {
            _dateTime = dateTime;
        }

        public DbSet<City> Cities { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Issue> Issues { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Solution> Solutions { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.Created = _dateTime.UtcNow;
                        entry.Entity.LastModified = _dateTime.UtcNow;
                        entry.Entity.Status = "A";
                        break;
                    case EntityState.Deleted:
                        entry.Entity.LastModified = _dateTime.UtcNow;
                        entry.Entity.Status = "D";
                        entry.State = EntityState.Modified;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModified = _dateTime.UtcNow;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SocialVoiceDbContext).Assembly);
        }
    }
}
