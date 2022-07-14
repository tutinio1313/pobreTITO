using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
 #pragma warning disable CS8618

namespace pobreTITO_models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Oops, debes ingresar el email.")]
        [DataType(DataType.EmailAddress)]
        public string email {get; set;}

        [Required(ErrorMessage = "Oops, debes ingresar la contraseña.")]
        [DataType(DataType.Password)]
        public string password {get; set;}
    }    
}