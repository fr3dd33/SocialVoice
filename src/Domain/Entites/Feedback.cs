using Domain.Common;

namespace Domain.Entites
{
    public class Feedback : AuditableEntity
    {
        public int Id { get; set; }

        public string Content { get; set; }
        public int Pros { get; set; }
        public int Cons { get; set; }
    }
}
