using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;

namespace DatingApp.API.Models.Entity
{
    [Table("Users")]
    public class User : ClassBase
    {
        [Column("Username")]
        public string Username { get; set; }
        [Column("PasswordHash")]
        public byte[] PasswordHash { get; set; }
        [Column("PasswordSalt")]
        public byte[] PasswordSalt { get; set; }
        [Column("Gender")]
        public string Gender { get; set; }
        [Column("DateOfBirth")]
        public DateTime DateOfBirth { get; set; }
        [Column("KnownAs")]
        public string KnownAs { get; set; }
        [Column("Created")]
        public DateTime Created { get; set; }
        [Column("LastActive")]
        public DateTime LastActive { get; set; }
        [Column("Introduction")]
        public string Introduction { get; set; }
        [Column("Interests")]
        public string Interests { get; set; }
        [Column("City")]
        public string City { get; set; }
        [Column("Country")]
        public string Country { get; set; }
        [Column("LookingFor")]
        public string LookingFor { get; set; }
        
        public ICollection<Photo> Photos { get; set; }
    }
}