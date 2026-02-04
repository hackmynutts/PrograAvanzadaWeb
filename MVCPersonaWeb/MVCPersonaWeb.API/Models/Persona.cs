using System.ComponentModel.DataAnnotations;

namespace MVCPersonaWeb.API.Models
{
    public class Persona { 
        public int Id { get; set; } 
        [Required]
        [StringLength(100)] 
        public string Nombre { get; set; } 
        [StringLength(100)] 
        public string Apellido { get; set; } 
        [EmailAddress] 
        public string Email { get; set; } 
        [Phone] 
        public string Telefono { get; set; } }
}

