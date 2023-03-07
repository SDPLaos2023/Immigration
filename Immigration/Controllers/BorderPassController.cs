using Immigration.Models;
using Immigration.Services;
using Microsoft.AspNetCore.Mvc;

namespace Immigration.Controllers
{
    public class BorderPassController : Controller
    {
        private BorderPassService oBorderPassService = new BorderPassService();
        public BorderPassController()
        {
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult BorderPass(long ID)
        {
            var _BorderPass = new BorderPassModel();
            //Select Passport Register
            var _dataTable = oBorderPassService.BorderPassSelect(ID);

            return View(_BorderPass);
        }

        [HttpPost]
        public IActionResult BorderPass()
        {
            var _BorderPass = new BorderPassModel();
            _BorderPass.Surname = "Ratchanon Thuknuek";
            _BorderPass.GivenName = "Ratchanon Thuknuek";
            _BorderPass.BirthOfDate = DateTime.Now.ToString("dd/MM/yyyy");
            _BorderPass.Sex = "M";
            _BorderPass.Country = "Thailand";
            _BorderPass.Village = "Village";
            _BorderPass.District = "District";
            _BorderPass.Province = "Province";
            _BorderPass.DocumentNo = 1;
            _BorderPass.Occupation = "Occupation";

            //Insert PassportRegister
            oBorderPassService.BorderPassRegisterInsert(_BorderPass);
            return View();
        }
    }
}
