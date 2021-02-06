using Assessment_RaceTrack.Core.Repository;
using Assessment_RaceTrack.Models;
using Assessment_RaceTrack.Services;
using System;
using System.IO;
using System.Web.Mvc;

namespace Assessment_RaceTrack.Controllers
{
    public class VehicleController : Controller
    {
        private readonly ITrackService _trackService;

        public VehicleController(ITrackService trackService)
        {
            _trackService = trackService;
        }

        [HttpGet]
        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VehicleDto vehicleDto)
        {
            if (ModelState.IsValid)
            {
                //Process image file
                var image = vehicleDto.ImageFile;
                string fileName = string.Empty;
                string folderPath = string.Empty;

                if (image?.ContentLength > 0)
                {
                    //To Get File Extension  
                    string fileExtension = Path.GetExtension(image.FileName);

                    //Add Current Date To Attached File Name  
                     fileName = DateTime.Now.ToString("yyyyMMdd")+ fileExtension;
                     folderPath = Path.Combine(Server.MapPath("~/Content/images/"), fileName);
                    image.SaveAs(folderPath);
                    vehicleDto.Image = fileName;
                    _trackService.AddVehiclesOnTrack(vehicleDto);
                }
            }
           
            return View();
        }
    }
}