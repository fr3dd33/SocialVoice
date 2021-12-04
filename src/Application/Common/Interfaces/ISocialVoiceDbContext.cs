using System.Threading;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface ISocialVoiceDbContext
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
