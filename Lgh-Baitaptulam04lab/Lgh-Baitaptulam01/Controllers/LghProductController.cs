using Microsoft.AspNetCore.Mvc;
using Lgh_Baitaptulam01.Models;

namespace Lgh_Baitaptulam01.Controllers
{
    public class LghProductController : Controller
    {
        public IActionResult Index(int? categoryId)
        {
            List<LghCategory> categories = new List<LghCategory>
            {
                new LghCategory { Id = 1, Name = "Quần áo" },
                new LghCategory { Id = 2, Name = "Túi xách" },
                new LghCategory { Id = 3, Name = "Đồng hồ" },
                new LghCategory { Id = 4, Name = "Tivi" },
                new LghCategory { Id = 5, Name = "Tủ lạnh" }
            };

            List<LghProduct> products = GetProducts();

            if (categoryId.HasValue)
            {
                products = products.Where(p => p.CategoryId == categoryId.Value).ToList();
            }

            ViewBag.Categories = categories;
            ViewBag.Products = products;

            return View("~/Views/LghShop/LghIndex.cshtml");
        }

        public IActionResult Details(int id)
        {
            LghProduct? product = GetProducts().FirstOrDefault(p => p.Id == id);

            if (product is null)
            {
                return NotFound();
            }

            return View("~/Views/LghShop/LghDetail.cshtml", product);
        }

        private static List<LghProduct> GetProducts()
        {
            return new List<LghProduct>
            {
                new LghProduct { Id = 1, Name = "Bộ đồ bơi trẻ em nam", Image = "/images/1.png", Price = 400000, SalePrice = 350000, CategoryId = 1, Description = "Bộ đồ bơi cho trẻ em nam", Status = "Còn hàng", CreatedAt = DateTime.Now },
                new LghProduct { Id = 2, Name = "Bộ đồ bơi trẻ em nữ", Image = "/images/2.png", Price = 400000, SalePrice = 350000, CategoryId = 1, Description = "Bộ đồ bơi cho trẻ em nữ", Status = "Còn hàng", CreatedAt = DateTime.Now },
                new LghProduct { Id = 3, Name = "Túi thời trang", Image = "/images/3.png", Price = 700000, SalePrice = 550000, CategoryId = 2, Description = "Túi thời trang mới", Status = "Còn hàng", CreatedAt = DateTime.Now },
                new LghProduct { Id = 4, Name = "Đồng hồ thời trang", Image = "/images/4.png", Price = 1500000, SalePrice = 1200000, CategoryId = 3, Description = "Đồng hồ thời trang cao cấp", Status = "Còn hàng", CreatedAt = DateTime.Now },
                new LghProduct { Id = 5, Name = "Tivi Samsung", Image = "/images/5.png", Price = 15000000, SalePrice = 12500000, CategoryId = 4, Description = "Tivi thông minh Samsung", Status = "Còn hàng", CreatedAt = DateTime.Now }
            };
        }
    }
}