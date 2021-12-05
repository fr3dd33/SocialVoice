using Domain.Common;
using System.Collections.Generic;

namespace Domain.Entites
{
    public class Issue : AuditableEntity
    {
        public Issue()
        {
            Feedbacks = new List<Feedback>();
            Solutions = new List<Solution>();
            Voters = new List<Voter>();
        }

        public int Id { get; set; }
        public string IssueUid { get; set; }
        public int OrganizationId { get; set; }

        public string Title { get; set; }
        public string Content { get; set; }
        public IssueState State { get; set; }
        public int Pros { get; set; }
        public int Cons { get; set; }

        public Organization Organization { get; set; }
        public List<Feedback> Feedbacks { get; set; }
        public List<Solution> Solutions { get; set; }
        public List<Voter> Voters { get; set; }
    }
}
