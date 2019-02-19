using System.ComponentModel.DataAnnotations.Schema;

namespace DatingApp.API.Models
{
    [Table("Values")]
    public class Value
    {
        [Column("Id")]
        public int Id { get; set; }
        [Column("Name")]
        public string Name { get; set; }
    }
}