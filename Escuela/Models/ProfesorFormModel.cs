using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Escuela.Models
{
    public class ProfesorFormModel
    {
        [Display(Prompt = "Nif del profesor", Description = "Nif del profesor", Name = "NIF")]
        [Required(ErrorMessage = "El NIF es obligatorio")]
        [StringLength(maximumLength: 200, ErrorMessage = "Eso no es un NIF")]
        public string NIF { get; set; }

        [Display(Prompt = "Disponibilidad del profesor", Description = "Disponibilidad del profesor", Name = "Disponibilidad")]
        [Required(ErrorMessage = "Debe indicar la disponibilidad del profesor")]
        [StringLength(maximumLength: 200, ErrorMessage = "Error, demasiado largo")]
        public string Disponibilidad { get; set; }

        [Display(Prompt = "Deporte que impartirá", Description = "Deporte que impartirá", Name = "Deporte que impartirá")]
        [Required(ErrorMessage = "Debe indicar un deporte")]
        [StringLength(maximumLength: 200, ErrorMessage = "Error, demasiado largo")]
        public string Deporte { get; set; }
    }
}