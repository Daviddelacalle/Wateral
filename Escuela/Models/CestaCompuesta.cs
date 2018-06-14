﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace Escuela.Models
{
    public class CestaCompuesta
    {
        [Display(Prompt = "Nombre del producto", Description = "Nombre del producto", Name = "Imagen")]
        [Required(ErrorMessage = "Debe indicar un nombre para el curso")]
        [StringLength(maximumLength: 200, ErrorMessage = "El nombre no puede tener más de 200 caracteres")]
        public string Imagen { get; set; }


        [Display(Prompt = "Nombre del producto", Description = "Nombre del producto", Name = "Nombre")]
        [Required(ErrorMessage = "Debe indicar un nombre para el curso")]
        public int Id { get; set; }

        [Display(Prompt = "Nombre del producto", Description = "Nombre del producto", Name = "Nombre")]
        [Required(ErrorMessage = "Debe indicar un nombre para el curso")]
        public int IdMain { get; set; }

        [Display(Prompt = "Nombre del producto", Description = "Nombre del producto", Name = "Nombre")]
        [Required(ErrorMessage = "Debe indicar un nombre para el curso")]
        [StringLength(maximumLength: 200, ErrorMessage = "El nombre no puede tener más de 200 caracteres")]
        public string Nombre { get; set; }

        [Display(Prompt = "Cantidad de producto", Description = "Cantidad de productos", Name = "Cantidad")]
        [Required(ErrorMessage = "La cantidad debe ser superior a 0")]
        public int Cantidad { get; set; }

        [Display(Prompt = "Precio del producto", Description = "Precio del producto", Name = "Precio")]
        [Required(ErrorMessage = "Debe indicar un precio para el curso")]
        public Double Precio { get; set; }

        [Display(Prompt = "Duracion del curso", Description = "Duracion del curso", Name = "Duración")]
        [Required(ErrorMessage = "Debe indicar un nombre para el curso")]
        public int Dias { get; set; }
    }
}