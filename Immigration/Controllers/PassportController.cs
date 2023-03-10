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
            return View();
        }

        [HttpGet]
        public IActionResult PassportRegister(long ID)
        {
            var _passportRegister = new PassportRegisterModel();
            //Select Passport Register
            var _dataTable = oPassportService.PassportRegisterSelect(ID);

            return View();
        }

        [HttpPost]
        public IActionResult PassportRegister(PassportRegisterModel _passportModel)
        {
            //Insert PassportRegister
            oPassportService.PassportRegisterWithMode(_passportModel, "INSERT");
            return View("Index");
        }
    }
}
