using Domain.Common;

namespace Domain.Entites
{
    public class District : AuditableEntity
    {
        public int Id { get; set; }
        public int RegionId { get; set; }
        public int CityId { get; set; }

        public string Name { get; set; }

        public Region Region { get; set; }
        public City City { get; set; }
    }
}
