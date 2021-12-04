﻿using Domain.Common;
using System.Collections.Generic;

namespace Domain.Entites
{
    public class Issue : AuditableEntity
    {
        public int Id { get; set; }
        public string IssueUid { get; set; }
        public int OrganizationId { get; set; }


        public string Title { get; set; }
        public string Content { get; set; }
        public IssueState State { get; set; }

        public Organization Organization { get; set; }
        public List<Feedback> Feedbacks { get; set; }
        public List<Solution> Solutions { get; set; }
    }
}
