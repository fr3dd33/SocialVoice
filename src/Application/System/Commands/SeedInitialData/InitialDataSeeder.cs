using Application.Common.Extensions;
using Application.Common.Interfaces;
using Domain.Common;
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
            await SeedIssuesAsync(cancellationToken);
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

        public async Task SeedIssuesAsync(CancellationToken cancellationToken)
        {
            if (_context.Issues.Any())
            {
                return;
            }

            var issues = new[]
            {
                new Issue
                {
                    Cons = 45,
                    Content = "Уважаемые одногруппники! Подскажите пожалуйста как решать проблему с ТЧСЖ по поводу отключения света в под' ездах. Т.е. ТЧСЖ из- за задолженности по квартплате не оплачивает свет в РЭС и тот отключает под' ездное освещение",
                    IssueUid = "".RandomString(),
                    OrganizationId = 1,
                    Pros = 164,
                    State = IssueState.NotSolved,
                    Title = "Проблемы со светом"
                },
                new Issue
                {
                    Cons = 23,
                    Content = "Всем здравствуйте! Хочу написать про автобус 12 так как мы его седня ждали целый час он так и не приехал! Кто за это отвечает? Почему так плохо ездят автобусы?",
                    IssueUid = "".RandomString(),
                    OrganizationId = 2,
                    Pros = 356,
                    State = IssueState.NotSolved,
                    Title = "Задержка общественного транспорта"
                },
                new Issue
                {
                    Cons = 46,
                    Content = @"У нас в Сырдаринском районе по м34 на пешеходных переходах нет ни светафоров,ни видеокамер,да элементарной разметки нет,ни инспекторов гай,не существует общественного транспорта. 
                                Ученики идут в школу 1,в школу 42 по м34 автомагистрали,освещения(фонорей) тоже нет.
                                Но самое интересно,что этот вопрос интересует ,только меня.Кто не сёт ответственность за школьников,если они целенаправленно идут в школу? Родители несут ответственностб за ребёнка,но не администрация школ.При этом админ.школ даже ни 1 буквы не написали,о безопастном пути к школам,учеников.Как я мама,должна со спокойным сердцем отпустить 3 детей в школу,и рисковать их жизнью?
                                27.11.2021г.,мою дочь 2010г.,на м34,на пешеходном переходе, чуть не сбил дамас,гай до сих пор не нашли дамас.",
                    IssueUid = "".RandomString(),
                    OrganizationId = 3,
                    Pros = 856,
                    State = IssueState.NotSolved,
                    Title = "Установка светофора"
                },
                new Issue
                {
                    Cons = 23,
                    Content = "obrashalsya s prosboy rasmotret prava grajdan katoriye jdut obshestvenniy transport na ostanovke Beshkapa okola massiva TTZ-2 (5 otdel militcii po ulitce BIY). holod, sneg, dojd' a sotrudniki magazin ne puskayut vo vnutr passajirov. pisal zayavleniye nachalniku 2 sektora (kstati zdaniye sektora nahoditsya 30 metrov do ostanovki). bez rezultatno. kak ya znayu zayavleniye USTNOYE, PISMENNOYE I ELEKTRONNOYE doljno rasmatrivatsya na zakonnih srokah i imeyut odinakovoyu silu. nadeyemsya na Vas",
                    IssueUid = "".RandomString(),
                    OrganizationId = 4,
                    Pros = 364,
                    State = IssueState.NotSolved,
                    Title = "Общественный транспорт"
                },
                new Issue
                {
                    Cons = 123,
                    Content = "обрашался с просбой расмотрет права граждан каторийе ждут обшественний транспорт на остановке Бешкапа окола массива ТТЗ-2 (5 отдел милитcии по улитcе БИЙ). ҳолод, снег, дождъ а сотрудники магазин не пускают во внутр пассажиров. писал заявленийе началнику 2 сектора (кстати зданийе сектора наҳодиця 30 метров до остановки). без резултатно. как я знаю заявленийе УСТНОЙЕ, ПИСМЕННОЙЕ И ЕЛЕКТРОННОЙЕ должно расматриваця на законниҳ срокаҳ и имеют одинаковою силу. надейемся на Вас",
                    IssueUid = "".RandomString(),
                    OrganizationId = 5,
                    Pros = 43,
                    State = IssueState.NotSolved,
                    Title = "Установка остановки"
                },
                //new Issue
                //{
                //    Cons = 87,
                //    Content = "",
                //    IssueUid = "".RandomString(),
                //    OrganizationId = 6,
                //    Pros = 34,
                //    State = IssueState.NotSolved,
                //    Title = ""
                //},
                //new Issue
                //{
                //    Cons = 456,
                //    Content = "",
                //    IssueUid = "".RandomString(),
                //    OrganizationId = 7,
                //    Pros = 64,
                //    State = IssueState.NotSolved,
                //    Title = ""
                //},
                //new Issue
                //{
                //    Cons = 2,
                //    Content = "",
                //    IssueUid = "".RandomString(),
                //    OrganizationId = 8,
                //    Pros = 164,
                //    State = IssueState.NotSolved,
                //    Title = ""
                //},
                //new Issue
                //{
                //    Cons = 24,
                //    Content = "",
                //    IssueUid = "".RandomString(),
                //    OrganizationId = 9,
                //    Pros = 745,
                //    State = IssueState.NotSolved,
                //    Title = ""
                //},
                //new Issue
                //{
                //    Cons = 9,
                //    Content = "",
                //    IssueUid = "".RandomString(),
                //    OrganizationId = 10,
                //    Pros = 453,
                //    State = IssueState.NotSolved,
                //    Title = ""
                //},
                //new Issue
                //{
                //    Cons = 7,
                //    Content = "",
                //    IssueUid = "".RandomString(),
                //    OrganizationId = 11,
                //    Pros = 846,
                //    State = IssueState.NotSolved,
                //    Title = ""
                //}
            };

            await _context.Issues.AddRangeAsync(issues);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
