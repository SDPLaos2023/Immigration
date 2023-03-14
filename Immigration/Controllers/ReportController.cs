using Immigration.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Immigration.Controllers
{
    public class ReportController : Controller
    {
        private readonly ILogger<ReportController> _logger;

        public ReportController(ILogger<ReportController> logger)
        {
            _logger = logger;
        }
        public IActionResult Mdata()
        {
            return View();
        }
        
        public IActionResult Personinout()
        {
            return View();
        }
        public IActionResult Psgborderpassbook()
        {
            return View();
        }
        public IActionResult Psgborderpasspaper() { 
        return View();
        }

        public IActionResult Psgborderpasspassport()
        {
            return View();
        }

        public IActionResult Psgborderpass()
        {
            return View();
        }

        public IActionResult Psgtemborder()
        {
            return View();
        }

        public IActionResult Vehicle()
        {
            return View();
        }

        public IActionResult Paslist()
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


