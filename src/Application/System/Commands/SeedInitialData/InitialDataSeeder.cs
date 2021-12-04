using System.Threading;
using System.Threading.Tasks;

namespace Application.System.Commands.SeedInitialData
{
    public class InitialDataSeeder
    {
        public InitialDataSeeder()
        {

        }

        public Task SeedAllAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
