namespace ShopApplication.Infrastructure.Models
{
    public class SaleItem
    {
        
        public int No { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }

        public SaleItem() { }
        public SaleItem(int no, Product product, int quantity)
        {
            No = no;
            Product = product;
            Quantity = quantity;
        }
        

    }
}
