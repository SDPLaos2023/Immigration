using Microsoft.AspNetCore.Mvc;

namespace Immigration.Controllers
{
    public class PassportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult PassportRegister()
        {
            return View();
        }
    }
}
