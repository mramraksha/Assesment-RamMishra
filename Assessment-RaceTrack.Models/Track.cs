using System;
using System.ComponentModel.DataAnnotations;

namespace Assessment_RaceTrack.Models
{
    public class Track
    {

        [Required]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid VehileId { get; set; }
        public bool OnTrack { get; set; }
        public DateTime DateTimestamp { get; set; }
    }
}
