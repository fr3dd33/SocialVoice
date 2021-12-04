using Application.Common.Mappings;
using AutoMapper;
using Domain.Entites;

namespace Application.Organizations.Queries.OrganizationsList
{
    public class OrganizationsListDto : IMapFrom<Organization>
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Brand { get; set; }
        public int INN { get; set; }
        public string Street { get; set; }
        public string Phone { get; set; }
        public string Location { get; set; }
        public string RegionName { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Organization, OrganizationsListDto>();
        }
    }
}
