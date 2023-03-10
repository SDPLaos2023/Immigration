using Immigration.Models;
using Immigration.Services;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Immigration.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private AccountService oAccountService = new AccountService();
        public AccountController(ILogger<AccountController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Login()
        {
            string aa = "";
            return View();
        }

        [HttpPost]
        public IActionResult Login(AccountModel accountModel)
        {
            var UserId = "";
            var User = oAccountService.SystemUserSelect(accountModel);
            if (User.Rows.Count > 0)
                foreach (DataRow item in User.Rows)
                    UserId = item["USER_ID"].ToString();

            HttpContext.Session.SetString("USERID", UserId);
            if (!String.IsNullOrEmpty(UserId)) return RedirectToAction("Index", "Home");
            else return View();
        }

    }
}
