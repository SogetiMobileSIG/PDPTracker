using System;
using System.IO;
using PDPTracker.Data;
using PDPTracker.iOS;
using SQLite;
using Xamarin.Forms;

[assembly: Dependency (typeof(SQLite_Ios))]
namespace PDPTracker.iOS
{
    public class SQLite_Ios : ISQLite
    {
        public SQLiteConnection GetConnection ()
        {
            var sqliteFilename = "PDPTracker.db3";
            string documentsPath = Environment.GetFolderPath (Environment.SpecialFolder.Personal); // Documents folder
            string libraryPath = Path.Combine (documentsPath, "..", "Library"); // Library folder
            var path = Path.Combine (libraryPath, sqliteFilename);

            // Create the connection
            var conn = new SQLiteConnection (path);

            // Return the database connection
            return conn;
        }
    }
}
