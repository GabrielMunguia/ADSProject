using ADSProject.Utils;
using System.ComponentModel.DataAnnotations;

namespace ADSProject.Models
{
    public class EstudianteViewModel
    {
        public int idEstudiante { get; set; }
        [Required(ErrorMessage = Constants.REQUIRED_FIELD)]
        [StringLength(50,MinimumLength =5 ,ErrorMessage ="La longitud del campo no debe ser mayor a 50 ni menor a 5 caracteres caracteres")]
        public string nombresEstudiante { get; set; }
        public string apellidosEstudiante { get; set; }
        public string codigoEstudiante { get; set; }
        public string correoEstudiante { get; set; }

    }
}
