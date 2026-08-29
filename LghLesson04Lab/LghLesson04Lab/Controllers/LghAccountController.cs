using Microsoft.AspNetCore.Mvc;
using LghLesson04Lab.Models;
using System.Linq;

namespace LghLesson04Lab.Controllers
{
    public class LghAccountController : Controller
    {
        public IActionResult LghIndex()
        {
            List<LghAccount> accounts = new List<LghAccount>
            {
                new LghAccount
                {
                    Id = 1,
                    Name = "Nguyễn Văn Nam",
                    Email = "nam@gmail.com",
                    Phone = "0987654321",
                    Avatar = "images/1.png",
                    Address = "Hà Nội",
                    Bip = "images/1.png",
                    Gender = 1,
                    BirthDate = new DateTime(2000, 5, 10)
                },

                new LghAccount
                {
                    Id = 2,
                    Name = "Trần Thị Lan",
                    Email = "lan@gmail.com",
                    Phone = "0912345678",
                    Avatar = "images/2.png",
                    Address = "Hải Phòng",
                    Bip = "images/2.png",
                    Gender = 0,
                    BirthDate = new DateTime(2001, 8, 15)
                },

                new LghAccount
                {
                    Id = 3,
                    Name = "Lê Văn Hùng",
                    Email = "hung@gmail.com",
                    Phone = "0909123456",
                    Avatar = "images/2.png",
                    Address = "Đà Nẵng",
                    Bip = "images/3.png",
                    Gender = 1,
                    BirthDate = new DateTime(1999, 12, 20)
                },

                new LghAccount
                {
                    Id = 4,
                    Name = "Phạm Thị Mai",
                    Email = "mai@gmail.com",
                    Phone = "0966333444",
                    Avatar = "images/3.png",
                    Address = "TP. Hồ Chí Minh",
                    Bip = "images/4.png",
                    Gender = 0,
                    BirthDate = new DateTime(2002, 3, 8)
                },

                new LghAccount
                {
                    Id = 5,
                    Name = "Hoàng Văn Minh",
                    Email = "minh@gmail.com",
                    Phone = "0977888999",
                    Avatar = "images/2.png",
                    Address = "Bắc Ninh",
                    Bip = "images/5.png",
                    Gender = 1,
                    BirthDate = new DateTime(2000, 10, 25)
                }
            };

            return View(accounts);
        }
        [Route("ho-so-cua-toi", Name = "LghProfile")]
        public IActionResult LghProfile(int? id)
        {
            LghAccount lghAccount = new LghAccount
            {
                Id = 5,
                Name = "Hoàng Văn Minh",
                Email = "minh@gmail.com",
                Phone = "0977888999",
                Avatar = "images/2.png",
                Address = "Bắc Ninh",
                Bip = "images/5.png",
                Gender = 1,
                BirthDate = new DateTime(2000, 10, 25)
            };

            var accounts = new List<LghAccount>
            {
                new LghAccount
                {
                    Id = 1,
                    Name = "Nguyễn Văn Nam",
                    Email = "nam@gmail.com",
                    Phone = "0987654321",
                    Avatar = "images/1.png",
                    Address = "Hà Nội",
                    Bip = "images/1.png",
                    Gender = 1,
                    BirthDate = new DateTime(2000, 5, 10)
                },
                new LghAccount
                {
                    Id = 2,
                    Name = "Trần Thị Lan",
                    Email = "lan@gmail.com",
                    Phone = "0912345678",
                    Avatar = "images/2.png",
                    Address = "Hải Phòng",
                    Bip = "images/2.png",
                    Gender = 0,
                    BirthDate = new DateTime(2001, 8, 15)
                },
                new LghAccount
                {
                    Id = 3,
                    Name = "Lê Văn Hùng",
                    Email = "hung@gmail.com",
                    Phone = "0909123456",
                    Avatar = "images/2.png",
                    Address = "Đà Nẵng",
                    Bip = "images/3.png",
                    Gender = 1,
                    BirthDate = new DateTime(1999, 12, 20)
                },
                new LghAccount
                {
                    Id = 4,
                    Name = "Phạm Thị Mai",
                    Email = "mai@gmail.com",
                    Phone = "0966333444",
                    Avatar = "images/3.png",
                    Address = "TP. Hồ Chí Minh",
                    Bip = "images/4.png",
                    Gender = 0,
                    BirthDate = new DateTime(2002, 3, 8)
                },
                new LghAccount
                {
                    Id = 5,
                    Name = "Hoàng Văn Minh",
                    Email = "minh@gmail.com",
                    Phone = "0977888999",
                    Avatar = "images/2.png",
                    Address = "Bắc Ninh",
                    Bip = "images/5.png",
                    Gender = 1,
                    BirthDate = new DateTime(2000, 10, 25)
                }
            };

            if (id.HasValue)
                lghAccount = accounts.FirstOrDefault(x => x.Id == id.Value) ?? lghAccount;

            ViewBag.LghAccount = lghAccount;

            return View();
        }
    }
}
