using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace WheelMap.Models
{
    [Table("Accounts")]
    public class Account
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(25), NotNull]
        public string Name { get; set; }

        [MaxLength(25), NotNull]
        public string Email { get; set; }

        [MaxLength(25), NotNull]
        public string Password { get; set; }
    }
}
