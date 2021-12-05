using MediatR;

namespace Application.Issues.Commands.VoteProIssue
{
    public class VoteProIssueCommand : IRequest
    {
        public int Id { get; set; }
        public string VisitorId { get; set; }
    }
}
