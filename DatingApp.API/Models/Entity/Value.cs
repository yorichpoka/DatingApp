using System.ComponentModel.DataAnnotations.Schema;

namespace DatingApp.API.Models.Entity
{
    [Table("Values")]
    public class Value : ClassBase
    {
        [Column("Name")]
        public string Name { get; set; }
    }
}