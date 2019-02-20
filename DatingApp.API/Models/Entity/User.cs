using System.ComponentModel.DataAnnotations.Schema;

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
    }
}