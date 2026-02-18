using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Http.HttpResults;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Principal;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ReservationWeb.UI.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public string Paciente { get; set; }
        public string Medico { get; set; }
        public string Especialidad { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
