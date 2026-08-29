namespace Lgh_Baitaptulam01.Models
{
    public class LghProduct
    {   
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Image { get; set; }
        public decimal Price { get; set; } = 0;
        public decimal SalePrice { get; set; }
        public int CategoryId { get; set; }
        public required string Description { get; set; }
        public required string Status { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
    