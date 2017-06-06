using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.IO;
using SQLite;
using Xamarin.Forms;
using SQLite.Net;

[assembly: Dependency(typeof(App3.Droid.SQLiteDb))]

namespace App3.Droid
{
    public class SQLiteDb : ISQLiteDb
    {
        public SQLiteAsyncConnection GetConnection()
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(documentsPath, "PKUniverse2.db3");

            return new SQLiteAsyncConnection(path);
        }
    }


}