using System;

namespace DatingApp.API.Models.Dtos
{
    public class PhotosForDetaildDto
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public DateTime DateAdded { get; set; }
        public string IsMain { get; set; }
    }
}