using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.IO;

namespace First
{
    public static class DB
    {
        public const string GET_ALL = @"SELECT Id, WordCZ, WordEN, IsFraze, Weight FROM Words";

        private static SQLiteConnection DBConnect()
        {
            var filename = "ItemsSQLite.db3";
            string folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(folder, filename);

            var connection = new SQLiteConnection(path);
            connection.Trace = true;

            if (connection == null)
                throw new Exception("Nelze vytvořit připojení k dazabázi.");

            return connection;
        }

        public static void PrepareDB()
        {
            using (var conn = DBConnect())
            {
                StringBuilder sql_script = new StringBuilder();

                sql_script.AppendFormat(@"SELECT Count(*) AS P FROM sqlite_master WHERE type='table' AND name='Words'");

                var r = conn.ExecuteScalar<int>(sql_script.ToString());
                if (r != 1)
                {
                    sql_script = new StringBuilder();
                    sql_script.AppendFormat(@"CREATE TABLE `Words` ( `Id` INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, `WordCZ` TEXT NOT NULL, `WordEN` TEXT NOT NULL, `IsFraze` INTEGER NOT NULL, `Weight` INTEGER NOT NULL );");
                    sql_script.AppendFormat(@"INSERT INTO Words (WordCZ, WordEN, IsFraze, Weight) VALUES (""test1"", ""test1 en"", ""0"", ""4"");");
                    sql_script.AppendFormat(@"INSERT INTO Words (WordCZ, WordEN, IsFraze, Weight) VALUES (""test2"", ""test2 en"", ""0"", ""1"");");

                    var commandSql = conn.CreateCommand(sql_script.ToString());
                    var r2 = commandSql.ExecuteQuery<string>();
                }
            }
        }

        public static List<Word> GetAll()
        {

            var a = new List<Word>();

            using (var conn = DBConnect())
            {
                var command = conn.CreateCommand(GET_ALL);
                var r = command.ExecuteQuery<List<Word>>();
            }

            return a;
        }

    }
}
