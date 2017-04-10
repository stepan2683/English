using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace First
{
    public class Word
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string WordCZ;
        public string WordEN;
        public int IsFraze;
        public int Weight;
    }
}
