using Assessment_RaceTrack.Core.Repository;
using Assessment_RaceTrack.Models;
using System;
using System.Collections.Generic;

namespace Assessment_RaceTrack.Services
{
    public class TrackService : ITrackService
    {
        private readonly IVehicleRepository _vehicleRepository;

        public TrackService(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }
        public IEnumerable<Vehicle> GetVehiclesOnTrack()
        {
            return _vehicleRepository.Get();
        }

        public int AddVehiclesOnTrack(Vehicle vehicle )
        {
            throw new NotImplementedException();
        }
    }
}