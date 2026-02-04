using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace ProgramacionAvanzadaWeb.Models
{
    public class CinemaRoomDTO
    {
        [BindNever]
        public int id{ get; set; }
        [Required]
        public string nombre { get; set; }
        [Required]
        public string type{ get; set; }
        [Required]
        public int capacity{ get; set; }
        public int cantSold{ get; set; }
    }
}
