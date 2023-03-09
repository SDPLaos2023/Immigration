using Microsoft.AspNetCore.Mvc;

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
    }
}


