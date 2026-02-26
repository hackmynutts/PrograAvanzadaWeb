namespace Restaurant.API.Models
{

    public enum OrderStatus
    {
        Pending,
        InProgress,
        Completed,
        Cancelled
    }
    public class Order
    {
        public int ID{ get; set; }
        public string CustomerName { get; set; }
        public string Dish { get; set; }
        public OrderStatus status { get; set; }
        public DateTime CreateAt{ get; set; }
    }
}
