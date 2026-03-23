using System;

namespace Models
{
    public class BaseProject
    {
        public int Id { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime? ClosedDate { get; set; }
    }
}
