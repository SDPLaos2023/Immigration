using Immigration.Models;
using Immigration.Services;
using Microsoft.AspNetCore.Mvc;

namespace Immigration.Controllers
{
    public class TemporaryBorderPassController : Controller
    {
        private TemporaryService oTemporaryService = new TemporaryService();
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult TemporaryBorderPass(long ID)
        {
            var _temporaryBorderPass = new TemporaryBorderModel();
            //Select Passport Register
            var _dataTable = oTemporaryService.TemporaryBorderPassSelect(ID);

            return View(_temporaryBorderPass);
        }

        [HttpPost]
        public IActionResult TemporaryBorderPass(TemporaryBorderModel _temporaryBorderPass)
        {
            //Insert PassportRegister
            oTemporaryService.TemporaryBorderPassWithMode(_temporaryBorderPass, "INSERT");
            return View("Index");
        }
    }
}
