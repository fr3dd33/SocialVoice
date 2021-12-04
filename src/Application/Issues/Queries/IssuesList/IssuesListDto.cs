using Application.Common.Mappings;
using AutoMapper;
using Domain.Entites;
using System;

namespace Application.Issues.Queries.IssuesList
{
    public class IssuesListDto : IMapFrom<Issue>
    {
        public int Id { get; set; }
        public string IssueUid { get; set; }

        public string Title { get; set; }
        public string Content { get; set; }
        public string OrganizationName { get; set; }
        public string RegionName { get; set; }
        public int Pros { get; set; }
        public int Cons { get; set; }
        public DateTime Created { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Issue, IssuesListDto>()
                .ForMember(x => x.OrganizationName, opt => opt.MapFrom(dst => dst.Organization.Name))
                .ForMember(x => x.RegionName, opt => opt.MapFrom(dst => dst.Organization.Region.Name));
        }
    }
}
