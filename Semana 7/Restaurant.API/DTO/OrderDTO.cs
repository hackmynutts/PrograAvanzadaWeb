namespace Restaurant.API.DTO
{
    public class OrderDTO
    {
        public int ID { get; set; }
        public string CustomerName { get; set; }
        public string Dish { get; set; }
        public string status { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
