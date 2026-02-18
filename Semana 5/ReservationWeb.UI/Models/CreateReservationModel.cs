using System.ComponentModel.DataAnnotations;

namespace ReservationWeb.UI.Models
{
    public class CreateReservationModel
    {
        [Required]
        public string Paciente { get; set; }
        [Required]
        public string Medico { get; set; }
        [Required]
        public string Especialidad { get; set; }
        [Required]
        public DateTime Fecha { get; set; }
    }
}
