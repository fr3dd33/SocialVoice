using MediatR;

namespace Application.Organizations.Queries.OrganizationDetail
{
    public class OrganizationDetailQuery : IRequest<OrganizationDetailDto>
    {
        public int Id { get; set; }
    }
}
