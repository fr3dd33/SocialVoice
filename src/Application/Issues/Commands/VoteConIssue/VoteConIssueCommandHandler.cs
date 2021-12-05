using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entites;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Issues.Commands.VoteConIssue
{
    public class VoteConIssueCommandHandler : IRequestHandler<VoteConIssueCommand>
    {
        private readonly ISocialVoiceDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public VoteConIssueCommandHandler(
            ISocialVoiceDbContext context,
            IHttpContextAccessor httpContextAccessor
        )
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<Unit> Handle(VoteConIssueCommand request, CancellationToken cancellationToken)
        {
            var issue = await _context.Issues.Include(x => x.Voters).FirstOrDefaultAsync(x => x.Id == request.Id);

            if (issue == null)
            {
                throw new BadRequestException("Issue not found");
            }

            _httpContextAccessor.HttpContext.Request.Headers.TryGetValue("User-Agent", out var userAgent);
            if (issue.Voters.Any(x => 
                x.IPAddress == _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString() &&
                x.VisitorId == request.VisitorId
            ))
            {
                throw new BadRequestException("You can not vote more than once");
            }

            issue.Cons += 1;

            issue.Voters.Add(new Voter
            {
                UserAgent = userAgent,
                IPAddress = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString()
            });

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
