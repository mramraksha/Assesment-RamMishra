using Assessment_RaceTrack.Core.Repository;
using System.Web.Mvc;

namespace Assessment_RaceTrack.Controllers
{
    public class VehicleController : Controller
    {
        private readonly IVehicleRepository vehicleRepository;

        public VehicleController(IVehicleRepository _vehicleRepository)
        {
            vehicleRepository = _vehicleRepository;
        }

        public ActionResult Create()
        {
            var result = vehicleRepository.Get();


            return View();
        }
        public ActionResult List()
        {
            var result = vehicleRepository.Get();


            return View();
        }
    }
}