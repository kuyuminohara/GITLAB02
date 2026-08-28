using LGH_LAB03.Models;
using Microsoft.AspNetCore.Mvc;

namespace LGH_LAB03.Controllers
{
    public class LghProductController : Controller
    {
        private readonly List<LghProduct>_product = new()
{
    new LghProduct
    {
        LghProductId = "LGH001",
        LghProductName = "Laptop Dell XPS 15",
        LghYearRelease = "2023",
        LghProductNumber = 25000000
    },
    new LghProduct
    {
        LghProductId = "LGH002",
        LghProductName = "iPhone 15 Pro",
        LghYearRelease = "2023",
        LghProductNumber = 5000000
    },
    new LghProduct
    {
        LghProductId = "LGH003",
        LghProductName = "Samsung Galaxy S24 Ultra",
        LghYearRelease = "2024",
        LghProductNumber = 3000000
    },
    new LghProduct
    {
        LghProductId = "LGH004",
        LghProductName = "MacBook Air M3",
        LghYearRelease = "2024",
        LghProductNumber = 20000000
    },
    new LghProduct
    {
        LghProductId = "LGH005",
        LghProductName = "iPad Pro M4",
        LghYearRelease = "2024",
        LghProductNumber = 15000000
    },
    new LghProduct
    {
        LghProductId = "LGH006",
        LghProductName = "Sony PlayStation 5",
        LghYearRelease = "2020",
        LghProductNumber = 40000000
    },
    new LghProduct
    {
        LghProductId = "LGH007",
        LghProductName = "Nintendo Switch OLED",
        LghYearRelease = "2021",
        LghProductNumber = 35000000
    },
    new LghProduct
    {
        LghProductId = "LGH008",
        LghProductName = "Apple Watch Series 9",
        LghYearRelease = "2023",
        LghProductNumber = 60000000
    },
    new LghProduct
    {
        LghProductId = "LGH009",
        LghProductName = "Samsung Galaxy Tab S9",
        LghYearRelease = "2023",
        LghProductNumber = 18000000
    },
    new LghProduct
    {
        LghProductId = "LGH010",
        LghProductName = "ASUS ROG Strix G16",
        LghYearRelease = "2024",
        LghProductNumber = 1200000000
    }
};
        public IActionResult Index()
        {
            return Json(_product);
        }
        public IActionResult LghGetAllProduct()
        {
            ViewData["products"] = _product;
            return View();
        }
        public IActionResult LghGetListProduct()
        {
            return View(_product);
        }
    }
}
