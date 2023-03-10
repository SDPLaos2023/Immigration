using Immigration.Models;
using Immigration.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

namespace Immigration.Controllers
{
    public class BlackListController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        private BlackListService oTruckMasterService = new BlackListService();
        [HttpGet]
        public IActionResult BlackList(long _ID)
        {
            var _BkackList = new BlackListModels();
            //Select Passport Register
            var _dataTable = oTruckMasterService.BlackListSelect(_ID);

            return View(_BkackList);
        }
        [HttpPost]
        public IActionResult BlackList(BlackListModels BkackListModels)
        {                      
            oTruckMasterService.BlackListInsert(BkackListModels, "INSERT");
            return View();
        }

    }
}
