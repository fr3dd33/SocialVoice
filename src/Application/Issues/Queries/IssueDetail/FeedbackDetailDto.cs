using Application.Common.Mappings;
using AutoMapper;
using Domain.Entites;
using System;

namespace Application.Issues.Queries.IssueDetail
{
    public class FeedbackDetailDto : IMapFrom<Feedback>
    {
        public int Id { get; set; }

        public string Content { get; set; }
        public int Pros { get; set; }
        public int Cons { get; set; }
        public DateTime Created { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Feedback, FeedbackDetailDto>();
        }
    }
}
