using Assessment_RaceTrack.Core.Repository.Common;
using Assessment_RaceTrack.Models;

namespace Assessment_RaceTrack.Core.Repository
{
    public interface IVehicleRepository : IRepository<Vehicle>
    {
        IUnitOfWork unitOfWork { get; }
    }

}
