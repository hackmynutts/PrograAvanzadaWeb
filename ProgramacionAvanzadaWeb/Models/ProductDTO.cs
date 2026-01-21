using Microsoft.AspNetCore.Mvc.ModelBinding;
using ProgramacionAvanzadaWeb.Validations;
using System.ComponentModel.DataAnnotations;

namespace ProgramacionAvanzadaWeb.Models
{
    public class ProductDTO
    {
        [BindNever]
        [Display(Name = "Identificador del producto")]
        public int ID { get; set; }
        [Required(ErrorMessage = "El nombre es requerido")]
        [Display(Name = "Nombre del producto")]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = "Debe de ingresar el monto.")]
        [Display(Name = "Precio del producto")]
        [ValidatePrice]
        public decimal Price { get; set; }
        [Display(Name = "Precio con iva")]
        public decimal PriceTotal { get; set; }
    }
}
