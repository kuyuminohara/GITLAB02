using System.ComponentModel.DataAnnotations;

namespace LghLesson09.Models.DataModels
{
    public class LghMembers
    {
        public Guid  LghMemberId { get; set; }
        public string LghMemberName { get; set; }
        public string LghPassword { get; set; }
        public string LghEmail { get; set; }
        public string LghPhoneNumber { get; set; }
        public string LghFullName { get; set; }
        public string LghbirthDate { get; set; }
    }
}
