using System.ComponentModel.DataAnnotations;

namespace LghLesson09.Models.DataModels.DataViewModel
{
    public class LghMemberRegister
    {
        public Guid LghMemberId { get; set; }
        [Display(Name = "Ten dang nhap")]
        [Required(ErrorMessage = "Ten dang nhap khong duoc de trong")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Ten dang nhap phai tu 3 den 20 ky tu")]
        public string LghMemberName { get; set; }
        [Display(Name = "Mat khau")]
        [Required(ErrorMessage = "Mat khau khong duoc de trong")]
        [DataType(DataType.Password)]
        public string LghPassword { get; set; }
        [Display(Name = "Email")]
        public string LghEmail { get; set; }
        public string LghPhoneNumber { get; set; }
        public string FullName { get; set; }
        public string birthDate { get; set; }
    }
}
