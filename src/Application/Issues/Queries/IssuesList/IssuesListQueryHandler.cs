using Application.Common.Interfaces;
using Application.Common.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entites;
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
            IQueryable<Issue> issues = _context.Issues.Include(x => x.Organization)
                    .ThenInclude(x => x.Region)
                    .OrderByDescending(x => x.Pros);

            if (!string.IsNullOrEmpty(request.Search))
            {
                issues = issues.Where(x => 
                    x.Title.ToLower().Contains(request.Search.ToLower()) || 
                    x.Organization.Name.ToLower().Contains(request.Search)
                );
            }

            return new BaseView<IssuesListDto>
            {
                Data = await issues.Skip(request.Offset)
                    .Take(request.Limit)
                    .ProjectTo<IssuesListDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(),
                Total = await _context.Issues.CountAsync()
            };
        }
    }
}
