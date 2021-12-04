using Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Issues.Queries.IssueDetail
{
    public class IssueDetailQueryHandler : IRequestHandler<IssueDetailQuery, IssueDetailDto>
    {
        private readonly ISocialVoiceDbContext _context;
        private readonly IMapper _mapper;

        public IssueDetailQueryHandler(
            ISocialVoiceDbContext context,
            IMapper mapper
        )
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IssueDetailDto> Handle(IssueDetailQuery request, CancellationToken cancellationToken)
        {
            return await _context.Issues.Include(x => x.Feedbacks)
                .Include(x => x.Organization)
                .Where(x => x.Id == request.Id)
                .ProjectTo<IssueDetailDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
        }
    }
}
