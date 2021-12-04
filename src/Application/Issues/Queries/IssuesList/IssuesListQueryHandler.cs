using Application.Common.Interfaces;
using Application.Common.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Issues.Queries.IssuesList
{
    public class IssuesListQueryHandler : IRequestHandler<IssuesListQuery, BaseView<IssuesListDto>>
    {
        private readonly ISocialVoiceDbContext _context;
        private readonly IMapper _mapper;

        public IssuesListQueryHandler(
            ISocialVoiceDbContext context,
            IMapper mapper
        )
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<BaseView<IssuesListDto>> Handle(IssuesListQuery request, CancellationToken cancellationToken)
        {
            return new BaseView<IssuesListDto>
            {
                Data = await _context.Issues.Include(x => x.Organization)
                    .ThenInclude(x => x.Region)
                    .OrderByDescending(x => x.Pros)
                    .Skip(request.Offset)
                    .Take(request.Limit)
                    .ProjectTo<IssuesListDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(),
                Total = await _context.Issues.CountAsync()
            };
        }
    }
}
