namespace Butler.Models
{
    public class Ingredient
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public string Amount { get; set; }
    }
}