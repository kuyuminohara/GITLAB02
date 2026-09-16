using LghLesson08.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LghLesson08.Controllers
{
    public class LghHomeController : Controller
    {
        private readonly ILogger<LghHomeController> _logger;

        public LghHomeController(ILogger<LghHomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult LghIndex()
        {
            return View();
        }

        public IActionResult LghAbout()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult LghError()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
