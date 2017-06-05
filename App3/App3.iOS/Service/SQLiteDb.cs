using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using SQLite;
using Xamarin.Forms;
using System.IO;
using SQLite.Net;

[assembly: Dependency(typeof(App3.iOS.SQLiteDb))]

namespace App3.iOS
{
    public class SQLiteDb : ISQLiteDb
    {
        public SQLiteAsyncConnection GetConnection()
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(documentsPath, "PKUniverse1.db3");

            return new SQLiteAsyncConnection(path);
        }
    }
}