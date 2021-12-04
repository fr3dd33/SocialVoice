using Application.Common.Exceptions;
using Application.Common.Extensions;
using Application.Common.Interfaces;
using Domain.Common;
using Domain.Entites;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Issues.Commands.CreateIssue
{
    public class CreateIssueCommandHandler : IRequestHandler<CreateIssueCommand>
    {
        private readonly ISocialVoiceDbContext _context;

        public CreateIssueCommandHandler(ISocialVoiceDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(CreateIssueCommand request, CancellationToken cancellationToken)
        {
            var organization = await _context.Organizations.FindAsync(request.OrganizationId);

            if (organization == null)
            {
                throw new BadRequestException("Organization not found");
            }

            var issue = new Issue
            {
                Content = request.Content,
                IssueUid = "".RandomString(),
                Organization = organization,
                State = IssueState.NotSolved,
                Title = request.Title
            };

            await _context.Issues.AddAsync(issue);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
