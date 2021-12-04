using Domain.Common;

namespace Domain.Entites
{
    public class Solution : AuditableEntity
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public string Content { get; set; }
        public string Contacts { get; set; }
        public string FileName { get; set; }
    }
}
