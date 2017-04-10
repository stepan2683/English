using System;
using SQLite;

namespace First
{

    public class DB : IDatabase
    {

        public const string GetAll = @"SELECT * FROM Words";

        public SQLiteConnection DBConnect()
        {
            var filename = "ItemsSQLite.db3";
            string folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = path.Combine(folder, filename);
            var connection = new SQLiteConnection(path);
            return connection;
        }
    }
}