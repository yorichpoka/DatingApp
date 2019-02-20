using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatingApp.API.Models.Entity
{
    public abstract class ClassBase
    {
        [Column("Id")]
        [Key]
        public int Id { get; set; }
    }
}