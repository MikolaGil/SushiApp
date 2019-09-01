using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using SQLite;
using Xamarin.Forms;
using SushiApp.interfaces;
using SushiApp.db;

namespace SushiApp.API
{
    public class SushiRepository
    {
        SQLiteConnection database;
        public SushiRepository(string filename)
        {
            string databasePath = DependencyService.Get<ISQLite>().GetDatabasePath(filename);
            database = new SQLiteConnection(databasePath);
            database.CreateTable<Sushi>();
        }
        public IEnumerable<Sushi> GetItems()
        {
            return (from i in database.Table<Sushi>() select i).ToList();

        }
        public Sushi GetItem(int id)
        {
            return database.Get<Sushi>(id);
        }
        public int DeleteItem(int id)
        {
            return database.Delete<Sushi>(id);
        }
        public int SaveItem(Sushi item)
        {
            if (item.Id != 0)
            {
                database.Update(item);
                return item.Id;
            }
            else
            {
                return database.Insert(item);
            }
        }
    }
}
