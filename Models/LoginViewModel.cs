using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
#pragma warning disable CS8618

namespace pobreTITO_Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Oops, debes ingresar el email.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Oops, debes ingresar la contraseña.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public List<string>? Messages {get; set;} = new();
    }
}