using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Escuela.Models
{
    public class ProductoNewForm
    {

        [Display(Prompt = "Nombre del producto", Description = "Nombre del curso", Name = "Nombre")]
        [Required(ErrorMessage = "Debe indicar un nombre para el curso")]
        [StringLength(maximumLength: 200, ErrorMessage = "El nombre no puede tener más de 200 caracteres")]
        public string Nombre { get; set; }

        [Display(Prompt = "Stock del producto", Description = "Nombre del curso", Name = "Stock")]
        [Required(ErrorMessage = "Debe indicar un nombre para el curso")]
        public int stock { get; set; }

        [Display(Prompt = "Descripcion del producto", Description = "Descripcion del producto", Name = "Descripcion")]
        [Required(ErrorMessage = "Debe indicar un nombre para el curso")]
        [StringLength(maximumLength: 200, ErrorMessage = "El nombre no puede tener más de 200 caracteres")]
        public string Descripcion { get; set; }

        [Display(Prompt = "Precio del producto", Description = "Precio del producto", Name = "Precio de venta")]
        [Required(ErrorMessage = "Debe indicar un precio para el curso")]
        public Double Precio_compra { get; set; }

        [Display(Prompt = "Precio de alquiler", Description = "Precio de alquiler", Name = "Precio de alquiler")]
        [Required(ErrorMessage = "Debe indicar un precio para el curso")]
        public Double Precio_alquiler { get; set; }

    }
}