using MediatR;

namespace Application.Issues.Commands.CreateIssue
{
    public class CreateIssueCommand : IRequest
    {
        public int OrganizationId { get; set; }

        public string Title { get; set; }
        public string Content { get; set; }
    }
}
