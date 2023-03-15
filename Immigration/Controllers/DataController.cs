using Immigration.Services;
using Microsoft.AspNetCore.Mvc;

namespace Immigration.Controllers
{
    public class DataController : Controller
    {
        private PassportService oPassportService = new PassportService();
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult PassportData()
        {
            var _dataTable = oPassportService.PassportRegisterSelect(Convert.ToInt64("0"), "All");
            var _model = oPassportService.PassportSetListModel(_dataTable);
            return View(_model);
        }
    }
}
