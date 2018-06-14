using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Escuela.Models
{
    public class Mensaje
    {
        [Display(Prompt = "Id del mensaje", Description = "Id del mensaje", Name = "ID")]
        [Required(ErrorMessage = "Id required")]
        public int id { get; set; }

        [Display(Prompt = "TExto del mensaje", Description = "Texto del mensaje", Name = "Texto")]
        [Required(ErrorMessage = "El mensaje no puede estar vacío")]
        [StringLength(maximumLength: 200, ErrorMessage = "El mensaje no puede tener más de 280 caracteres")]
        public String Texto { get; set; }

        [Display(Prompt = "Fecha del mensaje", Description = "Fecha del mensaje", Name = "Fecha")]
        [Required(ErrorMessage = "Fecha")]
        public Nullable<DateTime> Fecha { get; set; }

        [Display(Prompt = "Usuario que envia el mensaje", Description = "Usuario que envia el mensaje", Name = "Emisor")]
        [Required(ErrorMessage = "Falta un emisor")]
        [StringLength(maximumLength: 200, ErrorMessage = "El nombre no puede tener más de 200 caracteres")]
        public string Emisor { get; set; }

        [Display(Prompt = "Usuario que recibe el mensaje", Description = "Usuario que recibe el mensaje", Name = "Recepetor")]
        [Required(ErrorMessage = "Falta un receptor")]
        [StringLength(maximumLength: 200, ErrorMessage = "El nombre no puede tener más de 200 caracteres")]
        public string Receptor { get; set; }

    }
}