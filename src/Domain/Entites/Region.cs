using Domain.Common;
using System.Collections.Generic;

namespace Domain.Entites
{
    public class Region : AuditableEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<City> Cities { get; set; }
        public List<District> Districts { get; set; }
    }
}
