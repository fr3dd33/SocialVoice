using Application.Common.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.System.Commands.SeedInitialData
{
    public class SeedInitialDataCommand : IRequest
    {
    }

    public class SeedInitialDataCommandHandler : IRequestHandler<SeedInitialDataCommand>
    {
        private readonly ISocialVoiceDbContext _context;

        public SeedInitialDataCommandHandler(ISocialVoiceDbContext context)
        {
            _context = context;
        }

        public Task<Unit> Handle(SeedInitialDataCommand request, CancellationToken cancellationToken)
        {
            return Unit.Task;
        }
    }
}
