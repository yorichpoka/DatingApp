using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace DatingApp.API.Models.Entity
{
    [Table("Photos")]
    public class Photo : ClassBase
    {
        [Column("Url")]
        public string Url { get; set; }
        [Column("Description")]
        public string Description { get; set; }
        [Column("DateAdded")]
        public DateTime DateAdded { get; set; }
        [Column("IsMain")]
        public string IsMain { get; set; }
        [Column("UserId")]
        [ForeignKey("FK_Photo_User")]
        public int UserId { get; set; }
        
        public User User { get; set; }
    }
}