using Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Organizations.Queries.OrganizationDetail
{
    public class OrganizationDetailQueryHandler : IRequestHandler<OrganizationDetailQuery, OrganizationDetailDto>
    {
        private readonly ISocialVoiceDbContext _context;
        private readonly IMapper _mapper;

        public OrganizationDetailQueryHandler(
            ISocialVoiceDbContext context,
            IMapper mapper
        )
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<OrganizationDetailDto> Handle(OrganizationDetailQuery request, CancellationToken cancellationToken)
        {
            return await _context.Organizations.Include(x => x.Region)
                .Include(x => x.District)
                .Where(x => x.Id == request.Id)
                .ProjectTo<OrganizationDetailDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
        }
    }
}
