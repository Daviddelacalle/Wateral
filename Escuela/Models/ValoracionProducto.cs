using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Escuela.Models
{
    public class ValoracionProducto
    {
        [Display(Prompt = "Producto a valorar", Description = "Nombre del curso", Name = "Producto")]
        [Required(ErrorMessage = "Debe indicar un nombre para el curso")]
        public int producto { get; set; }

        [Display(Prompt = "Producto a valorar", Description = "Nombre del curso", Name = "Producto")]
        [Required(ErrorMessage = "Debe indicar un nombre para el curso")]
        public int id { get; set; }


        [Display(Prompt = "Usuario que valora", Description = "Nombre del curso", Name = "Usuario")]
        [Required(ErrorMessage = "Debe indicar un nombre para el curso")]
        [StringLength(maximumLength: 200, ErrorMessage = "El nombre no puede tener más de 200 caracteres")]
        public string usuario { get; set; }


        [Display(Prompt = "Nota del producto", Description = "Nombre del curso", Name = "Nota")]
        [Required(ErrorMessage = "Debe indicar un nombre para el curso")]
        public int nota { get; set; }

        [Display(Prompt = "Comentario adicional", Description = "Nombre del curso", Name = "Comentario")]
        [Required(ErrorMessage = "Debe indicar un nombre para el curso")]
        [StringLength(maximumLength: 200, ErrorMessage = "El nombre no puede tener más de 200 caracteres")]
        public string comentario { get; set; }
    }
}