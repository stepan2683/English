using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.ComponentModel.DataAnnotations;

namespace First
{
    [Table("Word")]
    public class Word
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [Column("WordCZ")]
        [Required]
        [StringLength(200)]
        public string WordCZ { get; set; }
        [Column("WordEN")]
        [Required]
        [StringLength(200)]
        public string WordEN { get; set; }
        [Column("IsFraze")]
        [Required]
        public bool IsFraze { get; set; }
        [Column("Weight")]
        [Required]
        public int Weight { get; set; }
    }
}
