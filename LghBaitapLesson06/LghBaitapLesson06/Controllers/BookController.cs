using Microsoft.AspNetCore.Mvc;
using LghBaitapLesson06.Models;

namespace LghBaitapLesson06.Controllers
{
    public class BookController : Controller
    {
        protected Book book = new Book();
        public IActionResult Index()
        {
            ViewBag.Authors = book.Authors;
            ViewBag.Genres = book.Genres;
            var books = book.GetBookList();
            return View(books);
        }
    }
}
