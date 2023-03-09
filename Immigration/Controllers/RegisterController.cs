using Immigration.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Immigration.Controllers
{
    public class RegisterController : Controller
    {
        private readonly ILogger<RegisterController> _logger;

        public RegisterController(ILogger<RegisterController> logger)
        {
            _logger = logger;
        }
        public IActionResult Passport()
        {
            return View();
        }
        public IActionResult Borderpass()
        {
            return View();
        }

        public IActionResult Temborpass()
        {
            return View();
        }

        public IActionResult Truck()
        {
            return View();
        }

        public IActionResult Blacklist()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}


