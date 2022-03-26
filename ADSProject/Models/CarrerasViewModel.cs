﻿
using ADSProject.Utils;
using System.ComponentModel.DataAnnotations;
namespace ADSProject.Models
{
    public class CarrerasViewModel
    {   [Display(Name = "ID")]
        public int idCarrera { get; set; }

        [Required(ErrorMessage = Constants.REQUIRED_FIELD)]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "La longitud del campo no debe ser mayor a 50 caracteres ni menor de 3 caracteres.")]
        [Display(Name = "Nombre")]
        public string nombreCarrera { get; set; }
        

        [Required(ErrorMessage = Constants.REQUIRED_FIELD)]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "La longitud del campo no debe ser mayor a 50 caracteres ni menor de 3 caracteres.")]
        [Display(Name = "Codigo")]

        public string codigoCarrera { get; set; }
      
    }
}