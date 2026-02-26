using System.ComponentModel.DataAnnotations;

namespace Restaurant.API.DTO
{
    public class OrderDTO
    {
        public int ID { get; set; }
        [Required]
        public string CustomerName { get; set; }
        [Required]
        public string Dish { get; set; }
        [Required]
        public string status { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.Now;
    }
}
