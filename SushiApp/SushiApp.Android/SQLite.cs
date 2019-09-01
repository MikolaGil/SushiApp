using System.IO;
using Android.Content;
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
                string path = Path.Combine(documentsPath, sqliteFilename);

                if (!File.Exists(path))
                {
                    Context context = Android.App.Application.Context;
                    var dbAssetStream = context.Assets.Open(sqliteFilename);

                    var dbFileStream = new FileStream(path, FileMode.OpenOrCreate);
                    var buffer = new byte[1024];

                    int b = buffer.Length;
                    int length;

                    while ((length = dbAssetStream.Read(buffer, 0, b)) > 0)
                    {
                        dbFileStream.Write(buffer, 0, length);
                    }

                    dbFileStream.Flush();
                    dbFileStream.Close();
                    dbAssetStream.Close();
                }

                return path;
            }
        }
    }
}