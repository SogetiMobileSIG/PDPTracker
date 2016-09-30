using SQLite;

namespace PDPTracker.Models
{
    public class SqlBaseModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
    }
}
