using Domain.Common;

namespace Domain.Entites
{
    public class Voter : AuditableEntity
    {
        public int Id { get; set; }
        public string VisitorId { get; set; }

        public bool Incognito { get; set; }
        public string IPAddress { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string BrowserName { get; set; }
        public string BrowserMajorVersion { get; set; }
        public string BrowserFullVersion { get; set; }
        public string Os { get; set; }
        public string OsVersion { get; set; }
        public string UserAgent { get; set; }
    }
}
