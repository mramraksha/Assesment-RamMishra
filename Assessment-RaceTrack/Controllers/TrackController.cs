using Assessment_RaceTrack.Services;
using System.Web.Mvc;

namespace Assessment_RaceTrack.Controllers
{
    public class TrackController : Controller
    {
        private readonly ITrackService _trackService;
        public TrackController(ITrackService trackService)
        {
            _trackService = trackService;
        }

        // GET: Track
        public ActionResult Index()
        {
            return View(_trackService.GetVehiclesOnTrack());
        }
    }
}