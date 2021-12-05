using Application.Common.Mappings;
using AutoMapper;
using Domain.Entites;
using System;

namespace Application.Organizations.Queries.OrganizationDetail
{
    public class OrganizationIssueDetailDto : IMapFrom<Issue>
    {
        public int Id { get; set; }
        public string IssueUid { get; set; }

        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Created { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Issue, OrganizationIssueDetailDto>();
        }
    }
}
