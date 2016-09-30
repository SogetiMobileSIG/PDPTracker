using System;

namespace PDPTracker.Models
{
    public class Activity : SqlBaseModel
    {
        public int UserId { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? CompletedDate { get; set; }
        public int CategoryId { get; set; }
        public int GradeId { get; set; }
    }
}