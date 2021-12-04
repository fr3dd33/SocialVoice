using MediatR;

namespace Application.Issues.Queries.IssueDetail
{
    public class IssueDetailQuery : IRequest<IssueDetailDto>
    {
        public int Id { get; set; }
    }
}
