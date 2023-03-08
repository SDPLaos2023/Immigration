using Immigration.Models;
using Immigration.Services;
using Microsoft.AspNetCore.Mvc;

namespace Immigration.Controllers
{
    public class TruckMasterController : Controller
    {
        private TruckMasterService oTruckMasterService = new TruckMasterService();
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult TruckMaster()
        {
            var _TruckMaster = new TruckMasterModel();
            _TruckMaster.Truck_No = "พล.80-5512";
            _TruckMaster.Truck_Type = "6 ล้อ";
            _TruckMaster.Truck_Name = "AA";


            //Insert PassportRegister
            oTruckMasterService.TruckMasterInsert(_TruckMaster);
            return View();
        }
    }
}
