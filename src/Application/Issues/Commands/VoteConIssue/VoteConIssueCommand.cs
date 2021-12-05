using MediatR;

namespace Application.Issues.Commands.VoteConIssue
{
    public class VoteConIssueCommand : IRequest
    {
        public int Id { get; set; }
        public string VisitorId { get; set; }
    }
}
