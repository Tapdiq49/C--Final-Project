using ShopApplication.Infrastructure.Enums;

namespace ShopApplication.Infrastructure.Models
{
    public class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public Category ProductCategory { get; set; }
        public int Quantity { get; set; }
        public string Code { get; set; }
    }
}