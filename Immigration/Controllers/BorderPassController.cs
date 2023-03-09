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
        public IActionResult BorderPass(BorderPassModel _BorderPass)
        {
            //Insert PassportRegister
            oBorderPassService.BorderPassRegisterWithMode(_BorderPass, "INSERT");
            return View("Index");
        }
    }
}
