using System;
using SQLite;

namespace PDPTracker.Data
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection ();
    }
}
