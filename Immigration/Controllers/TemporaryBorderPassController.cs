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
        public IActionResult TemporaryBorderPass()
        {
            var _temporaryBorderPass = new TemporaryBorderModel();
            _temporaryBorderPass.Surname = "Ratchanon Thuknuek";
            _temporaryBorderPass.GivenName = "Ratchanon Thuknuek";
            _temporaryBorderPass.BirthOfDate = DateTime.Now.ToString("dd/MM/yyyy");
            _temporaryBorderPass.Sex = "M";
            _temporaryBorderPass.Country = "Thailand";
            _temporaryBorderPass.BirthCountry = "Thailand";
            _temporaryBorderPass.DocumentNo = 1;

            //Insert PassportRegister
            oTemporaryService.TemporaryBorderPassInsert(_temporaryBorderPass);

            return View();
        }
    }
}
