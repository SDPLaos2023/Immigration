using Immigration.Models;
using Immigration.Services;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Immigration.Controllers
{
    public class TruckMasterController : Controller
    {
        private TruckMasterService oTruckMasterService = new TruckMasterService();
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult TruckMaster(long ID)
        {
            if (ID == null)
            {
                ViewBag.Mode = "INSERT";
            }

            var _TruckMaster = new TruckMasterModel();
            var _dataTable = oTruckMasterService.TruckMasterSelect(ID);
            ViewBag.dateTruck = _dataTable;
            return View();
          
        }

        [HttpPost]
        public IActionResult TruckMaster(TruckMasterModel truckMasterModel)
        {
            oTruckMasterService.TruckMasterInsert(truckMasterModel, "INSERT");
            return View();
        }
    }
}
