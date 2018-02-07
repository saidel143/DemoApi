using System.ComponentModel.DataAnnotations;

namespace Portales.Models
{
    public class ProductModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Descripción")]
        public string Description { get; set; }
        
        [Required]
        [Display(Name = "Precio")]
        [Range(0, 999999999, ErrorMessage = "El precio no esta en el rango (0 - 999999999) ")]
        [RegularExpression(@"^(((0\.){1}(\d{1,2})?)|([1-9][0-9]*(\.\d{1,2})?))$", ErrorMessage = "Valor inválido")]
        public decimal Price { get; set; }

        [Required]
        [Display(Name = "Código")]
        public string Code { get; set; }

        [Required]
        [Display(Name = "Cantidad")]
        [Range(1, 10000, ErrorMessage = "La cantidad no esta en el rango (1-10000)")]
        [RegularExpression(@"^[^0].*$", ErrorMessage = "Valor inválido")]
        public int Stock { get; set; }

        [Required]
        [Display(Name = "Categoría")]
        public int CategoryId { get; set; }

        public string CategoryDescription { get; set; }
    }
}