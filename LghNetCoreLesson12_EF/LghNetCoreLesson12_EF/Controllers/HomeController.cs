using LghNetCoreLesson12_EF.Models;
using LghNetCoreLesson12_EF.LghAppDb;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace LghNetCoreLesson12_EF.Controllers
{
    public class HomeController : Controller
    {
        private readonly LghAppDbContext _context;

        public HomeController(LghAppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.LghProducts
                .AsNoTracking()
                .OrderByDescending(product => product.LghCreatedDate)
                .ToListAsync());
        }

        public IActionResult Privacy()
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
