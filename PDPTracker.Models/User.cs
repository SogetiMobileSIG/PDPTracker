namespace PDPTracker.Models
{
    public class User : SqlBaseModel
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string Practice { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }
        public string FacebookUsername { get; set; }
        public string TwitterHandle { get; set; }
        public string LinkedInUsername { get; set; }
    }
}

