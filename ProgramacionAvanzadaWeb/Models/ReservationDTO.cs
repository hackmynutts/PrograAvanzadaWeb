using Microsoft.AspNetCore.Mvc.ModelBinding;
using ProgramacionAvanzadaWeb.Validations;
using System.ComponentModel.DataAnnotations;

namespace ProgramacionAvanzadaWeb.Models
{
    public class ReservationDTO

    {
        [BindNever]
        public int Id { get; set; }

        [Required]
        public required string NombreCliente { get; set; }

        [Required]
        [ValidateDate]
        public DateTime FechaInicio { get; set; }

        [Required]
        public DateTime FechaFin { get; set; }

        [Range(1, 10)]
        public int CantidadPersonas { get; set; }

        [BindNever]
        public int DiasReserva { get; set; }

        [BindNever]
        public decimal CostoTotal { get; set; }

    }
}
