using Domain.Common;
using System.Collections.Generic;

namespace Domain.Entites
{
    public class Organization : AuditableEntity
    {
        public int Id { get; set; }
        public int RegionId { get; set; }
        public int DistrictId { get; set; }

        public string Name { get; set; }
        public string Brand { get; set; }
        public int INN { get; set; }
        public string Street { get; set; }
        public string Phone { get; set; }
        public string Location { get; set; }
        public int Pros { get; set; }
        public int Cons { get; set; }

        public Region Region { get; set; }
        public District District { get; set; }
        public List<Issue> Issues { get; set; }
    }
}
