using Application.Common.Interfaces;
using Domain.Entites;
using MediatR;
using System.Collections.Generic;
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
        private readonly IXslsReader<(ICollection<Organization>, ICollection<Region>)> _xlsxReader;

        public SeedInitialDataCommandHandler(
            ISocialVoiceDbContext context,
            IXslsReader<(ICollection<Organization>, ICollection<Region>)> organizationReader
        )
        {
            _context = context;
            _xlsxReader = organizationReader;
        }

        public async Task<Unit> Handle(SeedInitialDataCommand request, CancellationToken cancellationToken)
        {
            InitialDataSeeder seeder = new InitialDataSeeder(_context, _xlsxReader);
            
            await seeder.SeedAllAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
