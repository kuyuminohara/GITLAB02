using LghLesson09.Models.DataModels;
using LghLesson09.Models.DataModels.DataViewModel;
using Microsoft.AspNetCore.Mvc;

namespace LghLesson09.Controllers
{
    public class LghMemberController : Controller
    {
        private static List<LghMembers> _lghMember= new List<LghMembers>();
        public IActionResult Index()
        {
            return View(_lghMember);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LghMemberRegister lghMember)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(_lghMember);    
                }
                LghMembers member = new LghMembers
                {
                    LghMemberId = Guid.NewGuid(),
                    LghMemberName = lghMember.LghMemberName,
                    LghPassword = lghMember.LghPassword,
                    LghEmail = lghMember.LghEmail,
                    LghPhoneNumber = lghMember.LghPhoneNumber,
                    LghFullName = lghMember.FullName,
                    LghbirthDate = lghMember.birthDate
                };
                _lghMember.Add(member);
                return RedirectToAction("Index");
            }
            catch {
                return View();
            }
        }
    }
}
