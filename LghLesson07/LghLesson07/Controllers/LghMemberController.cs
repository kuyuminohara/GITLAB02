using LghLesson07.Models.DataModels;
using Microsoft.AspNetCore.Mvc;

namespace LghLesson07.Controllers
{
    public class LghMemberController : Controller
    {
        protected List<LghMember> _members = new List<LghMember>() {

                new LghMember
                {
                    LghMemberId = Guid.NewGuid().ToString(),
                    LghUserId = "NEW",
                    LghPassword = "123456",
                    LghFullName = "LE GIA HUNG",
                    LghEmail = "an@gmail.com"
                },
                new LghMember
                {
                    LghMemberId = Guid.NewGuid().ToString(),
                    LghUserId = "user02",
                    LghPassword = "123456",
                    LghFullName = "Trần Văn Bình",
                    LghEmail = "binh@gmail.com"
                },
                new LghMember
                {
                    LghMemberId = Guid.NewGuid().ToString(),
                    LghUserId = "user03",
                    LghPassword = "123456",
                    LghFullName = "Lê Thị Hoa",
                    LghEmail = "hoa@gmail.com"
                },
                new LghMember
                {
                    LghMemberId = Guid.NewGuid().ToString(),
                    LghUserId = "user04",
                    LghPassword = "123456",
                    LghFullName = "Phạm Văn Nam",
                    LghEmail = "nam@gmail.com"
                },
                new LghMember
                {
                    LghMemberId = Guid.NewGuid().ToString(),
                    LghUserId = "user05",
                    LghPassword = "123456",
                    LghFullName = "Đỗ Thị Lan",
                    LghEmail = "lan@gmail.com"
                }
            };
        public IActionResult Index()
        {
            return View(_members);
        }
        public IActionResult GetMembers()
        {
            ViewBag.Members = _members;
            return View();
        }
        [HttpGet]
        public IActionResult create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult create(LghMember member)
        {
            if (ModelState.IsValid)
            {
                member.LghMemberId = Guid.NewGuid().ToString();
                _members.Add(member);
                return RedirectToAction("Index");
            }
            return View(member);
        }
        public IActionResult GetMember()
        {
            var member = new LghMember
            {
                LghMemberId = Guid.NewGuid().ToString(),
                LghUserId = "NEW",
                LghPassword = "123456",
                LghFullName = "LE GIA HUNG",
                LghEmail = "an@gmail.com"
            };
            ViewBag.Member = member;
            return View();
        }
    }
}
