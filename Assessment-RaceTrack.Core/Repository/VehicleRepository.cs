using Assessment_RaceTrack.Core.Repository.Common;
using Assessment_RaceTrack.Models;

namespace Assessment_RaceTrack.Core.Repository
{
    public class VehicleRepository : BaseRepository<Vehicle>, IVehicleRepository
    {
        public IUnitOfWork unitOfWork { get; }

        public VehicleRepository(IUnitOfWork _unitOfWork) : base(_unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }
        public void Save()
        {
            unitOfWork.Commit();
        }

    }
}
