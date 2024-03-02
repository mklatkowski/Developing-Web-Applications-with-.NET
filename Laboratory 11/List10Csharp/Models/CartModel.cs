namespace List10Csharp.Models
{
    public class CartItem
    {
        public int ArticleId { get; set; }
        public int Quantity { get; set; }
        public string ArticleName { get; set; }
        public decimal ArticlePrice { get; set; }
        public string? ImagePath { get; set; }
    }

    public class CartModel
    {
        public List<CartItem> Items { get; set; } = new List<CartItem>();

        public double TotalCost => Items.Sum(item => (double) item.ArticlePrice * item.Quantity);
    }
}
