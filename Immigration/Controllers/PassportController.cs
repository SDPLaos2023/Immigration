using Immigration.Models;
using Immigration.Services;
using Microsoft.AspNetCore.Mvc;

namespace Immigration.Controllers
{
    public class PassportController : Controller
    {
        private PassportService oPassportService = new PassportService();
        public PassportController()
        {

        }
        public IActionResult Index()
        {
            ViewBag.Mode = "INSERT";
            return View();
        }

        [HttpGet]
        public IActionResult PassportRegister(long ID)
        {
            //Select Passport Register
            var _dataTable = oPassportService.PassportRegisterSelect(ID, "Id");
            var _model = oPassportService.PassportSetModel(_dataTable);
            ViewBag.Mode = "EDIT";
            return View("Index", _model);
        }

        [HttpPost]
        public JsonResult PassportRegister(PassportRegisterModel _passportModel, string Mode)
        {
            //Insert PassportRegister
            oPassportService.PassportRegisterWithMode(_passportModel, Mode);
            return Json(new { message = "Success" });
        }
    }
}
