using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using WateralGenNHibernate.EN.Wateral;

namespace Escuela.Models
{
    public class Alumno
    {
        public int Id { get; set; }

        [Display(Prompt = "Disponibilidad del alumno", Description = "Disponibilidad del alumno", Name = "Disponibilidad")]
        [Required(ErrorMessage = "Debe indicar la disponibilidad del alumno")]
        [StringLength(maximumLength: 600, ErrorMessage = "La disponibilidad no puede tener más de 600 caracteres")]
        public string Disponibilidad { get; set; }

        [Display(Prompt = "Estado de salud del alumno", Description = "Estado de salud del alumno", Name = "Salud")]
        [Required(ErrorMessage = "Debe indicar en qué estado de saludo se encuentra el alumno (alergias)")]
        [StringLength(maximumLength: 800, ErrorMessage = "El nombre no puede tener más de 800 caracteres")]
        public string Salud { get; set; }

        [Display(Prompt = "Peso del alumno", Description = "Peso del alumno", Name = "Peso")]
        [Required(ErrorMessage = "Debe indicar un peso para el alumno")]
        public int Peso { get; set; }

        [Display(Prompt = "Número de pie del alumno", Description = "Número de pie del alumno", Name = "Número pie")]
        [Required(ErrorMessage = "Debe indicar un número del pie del alumno")]
        public int NumPie { get; set; }

        [Display(Prompt = "DNI del alumno", Description = "DNI del alumno", Name = "DNI")]
        [Required(ErrorMessage = "Debe indicar una talla del pie para el alumno")]
        [StringLength(maximumLength: 10, ErrorMessage = "El DNI no puede tener más de 10 caracteres")]
        public string DNI { get; set; }

        [Display(Prompt = "Talla del alumno", Description = "Talla del alumno", Name = "Talla")]
        [Required(ErrorMessage = "Debe indicar una opción")]
        public string Talla { get; set; }

        [Required(ErrorMessage = "Debe indicar una opción")]
        public IList<GrupoEN> grupo { get; set; }
    }
}