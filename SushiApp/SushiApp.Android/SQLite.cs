using System.IO;
using SushiApp.interfaces;
using Xamarin.Forms;
using static SushiApp.Droid.SQLite;

[assembly: Dependency(typeof(SQLite_Android))]
namespace SushiApp.Droid
{
    class SQLite
    {

        public class SQLite_Android : ISQLite
        {
            public SQLite_Android() { }
            public string GetDatabasePath(string sqliteFilename)
            {
                string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                var path = Path.Combine(documentsPath, sqliteFilename);
                return path;
            }
        }
    }
}