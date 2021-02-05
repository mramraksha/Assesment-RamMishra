﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Assessment_RaceTrack.Models
{

    public enum Type
    {
        Truck, Car
    }

    public class Vehicle
    {
        
        [Required]
        public Guid Id { get; set; }
        public Type Type { get; set; }
        public string Description { get; set; }      
        public bool HandBreak { get; set; }
        public bool TowStrap { get; set; }

        [Range(0,5)]
        public int Lift { get; set; }
        public string Image{ get; set; }
        public int? TireWear { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}