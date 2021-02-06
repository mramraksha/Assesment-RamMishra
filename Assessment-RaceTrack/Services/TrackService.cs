﻿using Assessment_RaceTrack.Core.Repository;
using Assessment_RaceTrack.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace Assessment_RaceTrack.Services
{
    public enum Response
        {None, Inserted, Deleted, Overloaded}
    public class TrackService : ITrackService
    {
        private readonly IVehicleRepository _vehicleRepository;

        public TrackService(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }
        public IEnumerable<Vehicle> GetVehiclesOnTrack()
        {
            return _vehicleRepository.GetVehiclesOnTrack();
        }

        public Response AddVehiclesOnTrack(VehicleDto vehicleDto)
        {
            try
            {
                int totalAllowedVehicleOnTrack = Convert.ToInt32(ConfigurationManager.AppSettings["TotalAllowedVehicleOnTrack"]);
                bool checkTrackOverload = _vehicleRepository.Get().Count()> totalAllowedVehicleOnTrack ? true:false;
                //Process for saving in database
                var vehicleDetails = new Vehicle()
                {
                    Id = Guid.NewGuid(),
                    Name = vehicleDto.Name,
                    Type = vehicleDto.Type,
                    HandBreak = vehicleDto.HandBreak,
                    TireWear = vehicleDto.TireWear,
                    Lift = vehicleDto.Lift,
                    IsActive = true,
                    Image = vehicleDto.Image,
                    CreatedDate = DateTime.Now,
                    OnTrack = true
                };
                //in case of track overloaded
                if (checkTrackOverload)
                    return Response.Overloaded;
                var result = _vehicleRepository.Insert(vehicleDetails);
                return (result != null) ? Response.Inserted : Response.None;
            }
            catch (Exception ex)
            {

                throw ex;
            }
           

        }

        public Response RemoveVehiclesFromTrack(Guid vehicleId)
        {
            _vehicleRepository.Delete(vehicleId).ConfigureAwait(false);
          return  Response.Deleted;
        }
    }
}