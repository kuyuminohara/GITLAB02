using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace LghNetCoreLesson12_EF.Models
{
    [Table("Categories")]
    public class LghCategory
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên danh mục không được để trống")]
        [StringLength(150)]
        [Column(TypeName = "nvarchar(150)")]
        public string LghName { get; set; }
        public byte LghStatus { get; set; }
        public DateTime LghCreatedDate { get; set; }
        public ICollection<LghProduct> LghProducts { get; set; } = new List<LghProduct>();
    }
}
