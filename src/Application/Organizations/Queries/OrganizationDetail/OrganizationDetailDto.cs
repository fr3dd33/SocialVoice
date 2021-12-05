using Application.Common.Mappings;
using AutoMapper;
using Domain.Entites;
using System.Collections.Generic;

namespace Application.Organizations.Queries.OrganizationDetail
{
    public class OrganizationDetailDto : IMapFrom<Organization>
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        public string Brand { get; set; }
        public int INN { get; set; }
        public string Street { get; set; }
        public string Phone { get; set; }
        public string Location { get; set; }
        public int Pros { get; set; }
        public int Cons { get; set; }

        public string RegionName { get; set; }
        public string DistrictName { get; set; }
        public List<OrganizationIssueDetailDto> Issues { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Organization, OrganizationDetailDto>();
        }
    }
}
