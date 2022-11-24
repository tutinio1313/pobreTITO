using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
#pragma warning disable CS8618
namespace pobreTITO_Models
{
    public class ReportViewModel
    {
        [Required(ErrorMessage = "Oops, parece que hubo un problema con la identificación del usuario.")]
        public string User { get; set; }

        [Required(ErrorMessage = "Oops, debes ingresar la dirección.")]
        [DataType(DataType.Text)]
        public string Address { get; set; }

        [Required(ErrorMessage = "Oops, debes ingresar el apellido.")]
        [DataType(DataType.Text)]
        [RegularExpression("^[0-5]+$")]
        public int ReportType { get; set; }

        [Required(ErrorMessage = "Oops, debes ingresar la contraseña.")]
        [DataType(DataType.Text)]
        public string Comment { get; set; }

        [Required(ErrorMessage = "Oops, debes ingresar la contraseña.")]
        [DataType(DataType.Text)]
        public string ImageURL { get; set; }

        public List<string>? Messages { get; set; } = new();
    }
}