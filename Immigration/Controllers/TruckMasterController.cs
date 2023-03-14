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
            // var User = oAccountService.SystemUserSelect(accountModel);
            //if (_dataTable.Rows.Count > 0)
            //    foreach (DataRow item in _dataTable.Rows)
            //    {
            //        _TruckMaster.Truck_No = item["TRUCK_LICENCE_PLATE_NO"].ToString();
            //        _TruckMaster.Truck_Type = item["TRUCK_TYPE"].ToString();
            //        _TruckMaster.Truck_Name = item["COMPANY_NAME"].ToString();
            //    }

            ViewBag.dateTruck = _dataTable;
               return View(_TruckMaster);
        }

        [HttpPost]
        public IActionResult TruckMaster(TruckMasterModel truckMasterModel)
        {
            oTruckMasterService.TruckMasterInsert(truckMasterModel, "INSERT");
            return View();
        }
    }
}
