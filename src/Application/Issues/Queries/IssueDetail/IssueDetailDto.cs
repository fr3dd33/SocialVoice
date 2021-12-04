using Application.Common.Mappings;
using AutoMapper;
using Domain.Common;
using Domain.Entites;
using System;
using System.Collections.Generic;

namespace Application.Issues.Queries.IssueDetail
{
    public class IssueDetailDto : IMapFrom<Issue>
    {
        public int Id { get; set; }
        public string IssueUid { get; set; }

        public string Title { get; set; }
        public string Content { get; set; }
        public IssueState State { get; set; }

        public Organization Organization { get; set; }
        public List<FeedbackDetailDto> Feedbacks { get; set; }
        public DateTime Created { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Issue, IssueDetailDto>();
        }
    }
}
