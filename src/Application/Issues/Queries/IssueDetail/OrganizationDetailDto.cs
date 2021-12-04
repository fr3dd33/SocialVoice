using Application.Common.Mappings;
using AutoMapper;
using Domain.Entites;

namespace Application.Issues.Queries.IssueDetail
{
    public class OrganizationDetailDto : IMapFrom<Organization>
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Brand { get; set; }
        
        public string RegionName { get; set; }
        public string DistrictName { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Organization, OrganizationDetailDto>();
        }
    }
}
