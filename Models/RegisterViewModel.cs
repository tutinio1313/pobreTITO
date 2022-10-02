using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
#pragma warning disable CS8618
namespace pobreTITO_Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Oops, debes ingresar el DNI.")]
        [DataType(DataType.Text)]
        [RegularExpression("^[0-9]+$")]
        public string id { get; set; }

        [Required(ErrorMessage = "Oops, debes ingresar el email.")]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }
        
        [Required(ErrorMessage = "Oops, debes ingresar el nombre.")]
        [DataType(DataType.Text)]
        public string name { get; set; }

        [Required(ErrorMessage = "Oops, debes ingresar el apellido.")]
        [DataType(DataType.Text)]
        public string lastname { get; set; }

        [Required(ErrorMessage = "Oops, debes ingresar la contraseña.")]
        [DataType(DataType.Password)]
        public string password { get; set; }

        public List<string>? messages {get; set;} = new();
    }
}