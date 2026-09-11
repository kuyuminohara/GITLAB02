using Microsoft.AspNetCore.Mvc;
using Lgh_Lesson06.Models;

namespace Lgh_Lesson06.ViewComponents
{
    public class CategoryViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(int? n)
        {
            List<Category> categories = new List<Category>
            {
                new Category { CategoryId = 1, CategoryName = "Electronics", IsActive = true },
                new Category { CategoryId = 2, CategoryName = "Books", IsActive = true },
                new Category { CategoryId = 3, CategoryName = "Clothing", IsActive = false }
            };
            n = n ?? 0;
            var search = categories.Where(c => c.CategoryId>n).ToList();
            return View(categories  );
        }
    }
}
