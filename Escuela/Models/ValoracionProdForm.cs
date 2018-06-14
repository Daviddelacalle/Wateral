using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Escuela.Models
{
    public class ValoracionProdForm
    {
        [Display(Prompt = "Nota del producto", Description = "Nombre del curso", Name = "Nota")]
        [Required(ErrorMessage = "Debe indicar un nombre para el curso")]
        [Range(1, 10, ErrorMessage = "Nota debe estar entre 1 y 10.")]
        public int nota { get; set; }

        [Display(Prompt = "Comentario adicional", Description = "Nombre del curso", Name = "Comentario")]
        [Required(ErrorMessage = "Debe indicar un nombre para el curso")]
        [StringLength(maximumLength: 200, ErrorMessage = "El nombre no puede tener más de 200 caracteres")]
        public string comentario { get; set; }
    }
}