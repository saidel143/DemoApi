using System.ComponentModel.DataAnnotations;

namespace Portales.Models
{
    public class ClientModel
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
        [DataType(DataType.EmailAddress)]
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

        [Required]
        public string Resume { get; set; }

        public string AvatarMsg { get; set; }

        public string AvatarBase64 { get; set; }


        public ClientModel()
        {
            AvatarMsg = "Select your Avatar";
            AvatarBase64 = "/Images/descarga.png";
        }

    }
}