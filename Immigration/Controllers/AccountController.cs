using Microsoft.AspNetCore.Mvc;

namespace Immigration.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;

        public AccountController(ILogger<AccountController> logger)
        {
            _logger = logger;
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Forgotpassword()
        {
            return View();
        }

    }
}
