using Domain.Entites;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface ISocialVoiceDbContext
    {
        DbSet<City> Cities { get; set; }
        DbSet<District> Districts { get; set; }
        DbSet<Feedback> Feedbacks { get; set; }
        DbSet<Issue> Issues { get; set; }
        DbSet<Organization> Organizations { get; set; }
        DbSet<Region> Regions { get; set; }
        DbSet<Solution> Solutions { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
