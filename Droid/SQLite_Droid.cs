using System.IO;
using PDPTracker.Data;
using PDPTracker.Droid;
using SQLite;
using Xamarin.Forms;

[assembly: Dependency (typeof (SQLite_Droid))]
namespace PDPTracker.Droid
{
    public class SQLite_Droid : ISQLite
    {
        public SQLiteConnection GetConnection ()
        {
            var sqliteFilename = "PDPTracker.db3";
            string documentsPath = System.Environment.GetFolderPath (System.Environment.SpecialFolder.Personal); // Documents folder
            var path = Path.Combine (documentsPath, sqliteFilename);
            // Create the connection
            var conn = new SQLiteConnection (path);
            // Return the database connection
            return conn;
        }
    }
}
