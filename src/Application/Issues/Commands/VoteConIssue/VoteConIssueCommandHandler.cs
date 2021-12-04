using Application.Common.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Issues.Commands.VoteConIssue
{
    public class VoteConIssueCommandHandler : IRequestHandler<VoteConIssueCommand>
    {
        private readonly ISocialVoiceDbContext _context;

        public VoteConIssueCommandHandler(ISocialVoiceDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(VoteConIssueCommand request, CancellationToken cancellationToken)
        {
            var issue = await _context.Issues.FindAsync(request.Id);

            issue.Cons += 1;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
