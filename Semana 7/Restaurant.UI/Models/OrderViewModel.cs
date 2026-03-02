namespace Restaurant.UI.Models
{
    public class OrderViewModel
    {
        public int ID { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string Dish { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public DateTime CreateAt { get; set; }
    }
}
