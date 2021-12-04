using Application.Common.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Issues.Commands.VoteProIssue
{
    public class VoteProIssueCommandHandler : IRequestHandler<VoteProIssueCommand>
    {
        private readonly ISocialVoiceDbContext _context;

        public VoteProIssueCommandHandler(ISocialVoiceDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(VoteProIssueCommand request, CancellationToken cancellationToken)
        {
            var issue = await _context.Issues.FindAsync(request.Id);

            issue.Pros += 1;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
