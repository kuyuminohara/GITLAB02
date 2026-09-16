using System.ComponentModel.DataAnnotations;

namespace LghLesson08.Models
{
    public class LghMember
    {
        [Required(ErrorMessage = "Vui lòng nhập mã thành viên.")]
        public string LghMemberId { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập tên tài khoản.")]
        public string LghUserName { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập mật khẩu.")]
        public string LghPassword { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập họ và tên.")]
        [Display(Name = "Full Name")]
        public string LghFullName { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập email.")]
        [EmailAddress(ErrorMessage = "Email không đúng định dạng.")]
        public string LghEmail { get; set; }

    }
}
