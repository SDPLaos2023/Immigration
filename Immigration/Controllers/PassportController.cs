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

            return View(_passportRegister);
        }

        [HttpPost]
        public IActionResult PassportRegister()
        {
            var _passportRegister = new PassportRegisterModel();
            _passportRegister.Surname = "Ratchanon Thuknuek";
            _passportRegister.GivenName = "Ratchanon Thuknuek";
            _passportRegister.BirthOfDate = DateTime.Now.ToString("dd/MM/yyyy");
            _passportRegister.Sex = "M";
            _passportRegister.Country = "Thailand";
            _passportRegister.BirthCountry = "Thailand";
            _passportRegister.DocumentNo = 1;

            //Insert PassportRegister
            oPassportService.PassportRegisterInsert(_passportRegister);

            return View();
        }
    }
}
