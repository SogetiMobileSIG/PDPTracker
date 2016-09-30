using System;
namespace PDPTracker.Models
{
    public class UserLogin : SqlBaseModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public int UserId { get; set; }
        public bool RememberLogin { get; set; }
        public UserStatus Status { get; set; }
    }
}
