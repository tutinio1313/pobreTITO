using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
#pragma warning disable CS8618
namespace pobreTITO_Models
{
    public class ReportViewModel
    {
        [Required(ErrorMessage = "Oops, debes ingresar el DNI.")]
        [DataType(DataType.Text)]
        [RegularExpression("^[0-9]+$")]
        public string id { get; set; }

        [Required(ErrorMessage = "Oops, parece que hubo un problema con la identificación del usuario.")]
        [DataType(DataType.Text)]
        public string idUser { get; set; }

        [Required(ErrorMessage = "Oops, debes ingresar la dirección.")]
        [DataType(DataType.Text)]
        public string address { get; set; }

        [Required(ErrorMessage = "Oops, debes ingresar el apellido.")]
        [DataType(DataType.Text)]
        [RegularExpression("^[0-5]+$")]
        public string reportType { get; set; }

        [Required(ErrorMessage = "Oops, debes ingresar la contraseña.")]
        [DataType(DataType.Text)]
        public string comment { get; set; }

        [Required(ErrorMessage = "Oops, debes ingresar la contraseña.")]
        [DataType(DataType.Text)]
        public string imageURL { get; set; }

        public List<string>? messages { get; set; } = new();
    }
}