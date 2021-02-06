using Assessment_RaceTrack.Models;
using System;
using System.Collections.Generic;

namespace Assessment_RaceTrack.Data
{
    public class DBInitializer : System.Data.Entity.DropCreateDatabaseAlways<RaceTrackContext>
    {
        protected override void Seed(RaceTrackContext context)
        {
            var vehicles = new List<Vehicle>()
            {
                //Prepaire vehicle data for migration
                new Vehicle()
                {
                    Id = Guid.NewGuid(),
                    Name = "This is 1St vehicle on race track",
                    HandBreak = true,
                    TowStrap = true,
                    Lift = 5,
                    Image= "v1.PNG",
                    IsActive=true,
                    CreatedDate=DateTime.Now
                },
                 new Vehicle()
                {
                    Id = Guid.NewGuid(),
                    Name = "This is 2nd vehicle on race track",
                    HandBreak = true,
                    TowStrap = true,
                    Lift = 5,
                    Image= "v1.PNG",
                    IsActive=true,
                    CreatedDate=DateTime.Now
                },
                  new Vehicle()
                {
                    Id = Guid.NewGuid(),
                    Name = "This is 3rd vehicle on race track",
                    HandBreak = true,
                    TowStrap = true,
                    Lift = 5,
                    Image= "v1.PNG",
                    IsActive=true,
                    CreatedDate=DateTime.Now
                },
                   new Vehicle()
                {
                    Id = Guid.NewGuid(),
                    Name = "This is 4th vehicle on race track",
                    HandBreak = true,
                    TowStrap = true,
                    Lift = 5,
                    Image= "v1.PNG",
                    IsActive=true,
                    CreatedDate=DateTime.Now
                },
                    new Vehicle()
                {
                    Id = Guid.NewGuid(),
                    Name = "This is 5th vehicle on race track",
                    HandBreak = true,
                    TowStrap = true,
                    Lift = 5,
                    Image= "v1.PNG",
                    IsActive=true,
                    CreatedDate=DateTime.Now
                },
            };
            int vehicleCount = 0;
            vehicles.ForEach(vehicle => AddVehilceDetails(vehicle));
            //Add vehicle and track details
            void AddVehilceDetails(Vehicle vehicle)
            {
                vehicleCount++;
                context.Vehicles.Add(vehicle);
                context.Tracks.Add(new Track()
                {
                    Id = Guid.NewGuid(),
                    VehileId = vehicle.Id,
                    Name = "TrackA",
                    DateTimestamp = DateTime.Now,
                    //if vehicleCount>5 vehicle will not allow on track
                    OnTrack = (vehicleCount==5)?true:false
                }) ;
            };
            base.Seed(context);
           // context.SaveChanges();
        }
    }
}
