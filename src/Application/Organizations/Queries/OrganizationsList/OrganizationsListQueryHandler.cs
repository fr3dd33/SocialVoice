using Application.Common.Interfaces;
using Application.Common.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Organizations.Queries.OrganizationsList
{
    public class OrganizationsListQueryHandler : IRequestHandler<OrganizationsListQuery, BaseView<OrganizationsListDto>>
    {
        private readonly ISocialVoiceDbContext _context;
        private readonly IMapper _mapper;

        public OrganizationsListQueryHandler(
            ISocialVoiceDbContext context,
            IMapper mapper
        )
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<BaseView<OrganizationsListDto>> Handle(OrganizationsListQuery request, CancellationToken cancellationToken)
        {
            return new BaseView<OrganizationsListDto>
            {
                Data = await _context.Organizations.Include(x => x.Region)
                    .Skip(request.Offset)
                    .Take(request.Limit)
                    .ProjectTo<OrganizationsListDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(),
                Total = await _context.Organizations.CountAsync()
            };
        }
    }
}
