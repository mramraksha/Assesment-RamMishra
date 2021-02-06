using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Assessment_RaceTrack.Models
{
    public class VehicleDto
    {
        public VehicleType Type { get; set; }
        public string Name { get; set; }
        public bool HandBreak { get; set; }
        public bool TowStrap { get; set; }

        [Range(0, 5)]
        public int Lift { get; set; }
        public string Image { get; set; }
        public int? TireWear { get; set; }

        public bool AddOnTrack { get; set; }
    }
}