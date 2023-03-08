using Immigration.Models;
using Immigration.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

namespace Immigration.Controllers
{
    public class BkackListController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        private BkackListService oTruckMasterService = new BkackListService();
        [HttpGet]
        public IActionResult BkackList(long _ID)
        {
            var _BkackList = new BkackListModels();
            //Select Passport Register
            var _dataTable = oTruckMasterService.BkackListSelect(_ID);

            return View(_BkackList);
        }
        public IActionResult BkackList()
        {
            var _BkackList = new BkackListModels();
            _BkackList.Surname = "";
            _BkackList.Given_name = "";
            _BkackList.Birth_of_date = DateTime.Now.ToString("dd/MM/yyyy");
            _BkackList.Sex = "";
            _BkackList.Birth_Country = "";
            _BkackList.Document_No = 1;
            _BkackList.Remarks = "";

            //Insert BkackList
            oTruckMasterService.BkackListInsert(_BkackList, "INSERT");
            return View();
        }

    }
}
