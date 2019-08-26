using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using SQLite;
using Xamarin.Forms;
using SushiApp.interfaces;
using SushiApp.Model;

namespace SushiApp.API
{
    class SushiRepository
    {
        SQLiteConnection database;
        public SushiRepository(string filename)
        {
            string databasePath = DependencyService.Get<ISQLite>().GetDatabasePath(filename);
            database = new SQLiteConnection(databasePath);
            database.CreateTable<ListElement>();
        }
        public IEnumerable<ListElement> GetItems()
        {
            return (from i in database.Table<ListElement>() select i).ToList();

        }
        public ListElement GetItem(int id)
        {
            return database.Get<ListElement>(id);
        }
        public int DeleteItem(int id)
        {
            return database.Delete<ListElement>(id);
        }
        public int SaveItem(ListElement item)
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
