using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Escuela.Models
{
    public class Curso
    {
        [Display(Prompt = "Nombre del curso", Description = "Nombre del curso", Name = "Nombre")]
        [Required(ErrorMessage = "Debe indicar un nombre para el curso")]
        [StringLength(maximumLength: 200, ErrorMessage = "El nombre no puede tener más de 200 caracteres")]
        public string Nombre { get; set; }

        [Display(Prompt = "Precio del curso", Description = "Precio del curso", Name = "Precio")]
        [Required(ErrorMessage = "Debe indicar un precio para el curso")]
        [StringLength(maximumLength: 200, ErrorMessage = "El precio debe ser un Double")]
        public Double Precio { get; set; }

        [Display(Prompt = "Tipo de curso", Description = "Tipo de curso", Name = "Tipo")]
        [Required(ErrorMessage = "Debe indicar un tipo de curso")]
        [StringLength(maximumLength: 200, ErrorMessage = "El tipo no puede tener más de 200 caracteres")]
        public Enum Tipo { get; set; }

        [Display(Prompt = "Duracion del curso", Description = "Duracion del curso", Name = "Duracion")]
        [Required(ErrorMessage = "Debe indicar un nombre para el curso")]
        [StringLength(maximumLength: 200, ErrorMessage = "El precio debe ser un Integer")]
        public int Duracion { get; set; }

        [Display(Prompt = "Imagen del curso", Description = "Imagen del curso", Name = "Imagen")]
        [Required(ErrorMessage = "Debe indicar una imagen para el curso")]
        [StringLength(maximumLength: 200, ErrorMessage = "La imagen debe ser un String")]
        public String Imagen { get; set; }

        [Display(Prompt = "Id del curso", Description = "Id del curso", Name = "Id")]
        [Required(ErrorMessage = "Debe indicar una imagen para el curso")]
        [StringLength(maximumLength: 200, ErrorMessage = "La imagen debe ser un String")]
        public int Id { get; set; }
    }
}