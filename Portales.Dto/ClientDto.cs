using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portales.Dto
{
    public class ClientDto
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Cédula")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Ingrese una cédula válida")]
        public string DNI { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Apellidos")]
        public string Last_Name { get; set; }

        [Required]
        [Display(Name = "Correo")]
        [EmailAddress(ErrorMessage = "Dirección de correo inválida")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Dirección")]
        public string Address { get; set; }

        [Required]
        [Display(Name = "Teléfono")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\d*$", ErrorMessage = "El campo Teléfono debe ser numérico")]
        public string Phone { get; set; }

        public string Resume { get; set; }

        public string Avatar { get; set; }
    }
}
