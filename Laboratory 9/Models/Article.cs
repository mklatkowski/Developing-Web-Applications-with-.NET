namespace Lab_09_MVC.Models
{
    public enum Category
    {
        Electronics,
        Clothing,
        Books,
        Health,
        Pets
    }
    public class Article
    {
        public int Id { get; set; }
        public string name {  get; set; }
        public float price { get; set; }
        public DateTime expirationDate { get; set; }    
        public Category category { get; set; }

        public Article()
        {
        }

        public Article(string name, float price, DateTime expirationDate, Category category)
        {
            this.name = name;
            this.price = price;
            this.expirationDate = expirationDate;
            this.category = category;
        }
        public Article(int id, string name, float price, DateTime expirationDate, Category category)
        {
            this.Id = id;
            this.name = name;
            this.price = price;
            this.expirationDate = expirationDate;
            this.category = category;
        }
    }
}
