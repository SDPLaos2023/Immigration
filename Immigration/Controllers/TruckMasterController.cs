using Microsoft.AspNetCore.Mvc;

namespace Immigration.Controllers
{
    public class TruckMasterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
