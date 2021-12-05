using Domain.Common;
using System.Collections.Generic;

namespace Domain.Entites
{
    public class City : AuditableEntity
    {
        public City()
        {
            Districts = new List<District>();
        }

        public int Id { get; set; }
        public int RegionId { get; set; }

        public string Name { get; set; }

        public Region Region { get; set; }
        public List<District> Districts { get; set; }
    }
}
