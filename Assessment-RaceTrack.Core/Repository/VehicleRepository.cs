using Assessment_RaceTrack.Core.Repository.Common;
using Assessment_RaceTrack.Data;
using Assessment_RaceTrack.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Assessment_RaceTrack.Core.Repository
{
    public class VehicleRepository : BaseRepository<Vehicle>, IVehicleRepository
    {
        public IUnitOfWork unitOfWork { get; }

        public VehicleRepository(IUnitOfWork _unitOfWork) : base(_unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }

        public  IEnumerable<Vehicle> GetVehiclesOnTrack()
        {
            List<Vehicle> vehiles = new List<Vehicle>();
            try
            {
                return Get().Where(x => x.OnTrack);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
