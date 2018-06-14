using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Escuela.Models
{
    public class Producto
    {
        [Display(Prompt = "Nombre del curso", Description = "Nombre del curso", Name = "ID")]
        [Required(ErrorMessage = "Debe indicar un nombre para el curso")]
        public int id { get; set; }

        [Display(Prompt = "Nombre del curso", Description = "Nombre del curso", Name = "Stock")]
        [Required(ErrorMessage = "Debe indicar un nombre para el curso")]
        public int stock { get; set; }

        [Display(Prompt = "Nombre del curso", Description = "Nombre del curso", Name = "Nombre")]
        [Required(ErrorMessage = "Debe indicar un nombre para el curso")]
        [StringLength(maximumLength: 200, ErrorMessage = "El nombre no puede tener más de 200 caracteres")]
        public string Nombre { get; set; }

        [Display(Prompt = "Nombre del curso", Description = "Nombre del curso", Name = "Descripcion")]
        [Required(ErrorMessage = "Debe indicar un nombre para el curso")]
        [StringLength(maximumLength: 200, ErrorMessage = "El nombre no puede tener más de 200 caracteres")]
        public string Descripcion { get; set; }

        [Display(Prompt = "Precio del curso", Description = "Precio del curso", Name = "Precio de compra")]
        [Required(ErrorMessage = "Debe indicar un precio para el curso")]
        public Double Precio_compra { get; set; }

        [Display(Prompt = "Precio del curso", Description = "Precio del curso", Name = "Precio de alquiler")]
        [Required(ErrorMessage = "Debe indicar un precio para el curso")]
        public Double Precio_alquiler { get; set; }

        [Display(Prompt = "Imagen del curso", Description = "Imagen del curso", Name = "Imagen")]
        [Required(ErrorMessage = "Debe indicar una imagen para el curso")]
        [StringLength(maximumLength: 200, ErrorMessage = "La imagen debe ser un String")]
        public string Imagen { get; set; }

    }
 }