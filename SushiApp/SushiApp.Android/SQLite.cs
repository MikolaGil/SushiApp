﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SushiApp.interfaces;
using Xamarin.Forms;

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