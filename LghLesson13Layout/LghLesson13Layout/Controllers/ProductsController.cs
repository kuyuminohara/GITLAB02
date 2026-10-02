using Microsoft.AspNetCore.Mvc;

namespace LghLesson13Layout.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Search(string keyword)
        {
            ViewBag.Keyword = keyword;
            return View();
        }
        public IActionResult Hots()
        {
            return View();
        }
    }
}
