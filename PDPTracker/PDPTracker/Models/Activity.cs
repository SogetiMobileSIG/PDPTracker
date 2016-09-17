using System;
namespace PDPTracker.Models
{
    public class Activity
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UserId { get; set; }
        public DateTime? CompletedDate { get; set; }

    }
}
