using Application.Common.Interfaces;
using Domain.Entites;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Application.System.Commands.SeedInitialData
{
    public class InitialDataSeeder
    {
        private readonly ISocialVoiceDbContext _context;
        private readonly IXslsReader<(ICollection<Organization>, ICollection<Region>)> _xlsxReader;
        private readonly string _fileName = "organizations.xsls";

        public InitialDataSeeder(
            ISocialVoiceDbContext context,
            IXslsReader<(ICollection<Organization>, ICollection<Region>)> xlsxReader
        )
        {
            _context = context;
            _xlsxReader = xlsxReader;
        }

        public async Task SeedAllAsync(CancellationToken cancellationToken)
        {
            await SeedOpenDataAsync(cancellationToken);
        }

        public async Task SeedOpenDataAsync(CancellationToken cancellationToken)
        {
            if (_context.Organizations.Any())
            {
                return;
            }

            using (var client = new WebClient())
            {
                client.DownloadFile("https://stat.uz/ru/?option=com_dropfiles&format=&task=frontfile.download&catid=103&id=1432&Itemid=1000000000000", _fileName);
            }

            var data = await _xlsxReader.ReadAsync(_fileName);

            await _context.Regions.AddRangeAsync(data.Item2);
            await _context.SaveChangesAsync(cancellationToken);

            await _context.Organizations.AddRangeAsync(data.Item1);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
