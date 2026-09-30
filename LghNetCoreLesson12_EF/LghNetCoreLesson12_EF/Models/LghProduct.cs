using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LghNetCoreLesson12_EF.Models
{
    [Table("Products")]
    public class LghProduct
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên sản phẩm không được để trống")]
        [StringLength(150, ErrorMessage = "Tên sản phẩm giới hạn 150 ký tự")]
        [Column(TypeName = "nvarchar(150)")]
        public string LghName { get; set; }

        [Column(TypeName = "image")]
        public byte[]? LghImage { get; set; }

        [Required(ErrorMessage = "Giá sản phẩm không được để trống")]
        public float LghPrice { get; set; }

        public float LghSalePrice { get; set; }

        public byte LghStatus { get; set; }

        [StringLength(1000, ErrorMessage = "Nội dung mô tả giới hạn 1000 ký tự")]
        [Column(TypeName = "ntext")]
        public string LghDescription { get; set; }

        [Required(ErrorMessage = "Danh mục sản phẩm không được để trống")]
        public int LghCategoryId { get; set; }

        public DateTime LghCreatedDate { get; set; }

        [ForeignKey(nameof(LghCategoryId))]
        public LghCategory LghCategory { get; set; }
    }
}
