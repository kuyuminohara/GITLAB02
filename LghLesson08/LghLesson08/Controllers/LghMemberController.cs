using LghLesson08.Models;
using Microsoft.AspNetCore.Mvc;

namespace LghLesson08.Controllers
{
    public class LghMemberController : Controller
    {
        public static List<LghMember> _members = new List<LghMember>()
        {
            new LghMember
            {
                LghMemberId = Guid.NewGuid().ToString(),
                LghUserName = "HungVY",
                LghPassword = "Password123!",
                LghFullName = "LE GIA HUNG",
                LghEmail = "chunghing@gmail.com"
            },

            new LghMember
            {
                LghMemberId = Guid.NewGuid().ToString(),
                LghUserName = "tranthib",
                LghPassword = "SecurePass456#",
                LghFullName = "Trần Thị Bích",
                LghEmail = "tranthib@outlook.com"
            },

            new LghMember
            {
                LghMemberId = Guid.NewGuid().ToString(),
                LghUserName = "levanc",
                LghPassword = "MyPassw0rd789",
                LghFullName = "Lê Văn Cường",
                LghEmail = "levanc@company.com"
            }
        };
        public IActionResult Index()
        {
            return View(_members);
        }
        [HttpGet]
        public IActionResult LghCreate()
        {
            var member = new LghMember();
            return View("Create", member);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult LghCreate(LghMember lghmember)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", lghmember);
            }

            if (_members.Any(x => x.LghMemberId == lghmember.LghMemberId))
            {
                ModelState.AddModelError(nameof(lghmember.LghMemberId), "Mã thành viên đã tồn tại.");
                return View("Create", lghmember);
            }

            _members.Add(lghmember);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult LghEdit(string id)
        {
            var member = _members.FirstOrDefault(x => x.LghMemberId == id);
            if (member is null)
            {
                return NotFound();
            }

            return View("Edit", member);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult LghEdit(string id, LghMember lghmember)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit", lghmember);
            }

            var member = _members.FirstOrDefault(x => x.LghMemberId == id);
            if (member is null)
            {
                return NotFound();
            }

            member.LghUserName = lghmember.LghUserName;
            member.LghPassword = lghmember.LghPassword;
            member.LghFullName = lghmember.LghFullName;
            member.LghEmail = lghmember.LghEmail;

            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult LghDetails(string id)
        {
            var member = _members.FirstOrDefault(x => x.LghMemberId == id);
            if (member is null)
            {
                return NotFound();
            }

            return View("Details", member);
        }
        [HttpGet]
        public IActionResult LghDelete(string id)
        {
            var member = _members.FirstOrDefault(x => x.LghMemberId == id);
            if (member is null)
            {
                return NotFound();
            }

            return View("Delete", member);
        }
        [HttpPost]
        public IActionResult LghDeleted(string id)
        {
            var member = _members.FirstOrDefault(x => x.LghMemberId == id);
            if (member is null)
            {
                return NotFound();
            }

            _members.Remove(member);
            return RedirectToAction(nameof(Index));
        }
    }
}
