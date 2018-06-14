using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Collections.Generic;


namespace Escuela.Models
{
    public class Noticia
    {
        [Display(Prompt = "Id de la Noticia", Description = "Id de la Noticia", Name = "Id")]
        [Required(ErrorMessage = "Debe indicar un nombre para el curso")]
        public int id { get; set; }

        [Display(Prompt = "Imagen de la noticia", Description = "Imagen de la noticia", Name = "Imagen")]
        [Required(ErrorMessage = "Debe indicar un nombre para el curso")] 
        public string Imagen { get; set; }

        [Display(Prompt = "Fecha de la noticia", Description = "Fecha de la noticia", Name = "Fecha")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Fecha")]
        public Nullable<DateTime> Fecha { get; set; }

        [Display(Prompt = "Titulo de la noticia", Description = "Titulo de la noticia", Name = "Titulo")]
        [Required(ErrorMessage = "Escribe un titulo")]
        public String Titulo { get; set; }

        [Display(Prompt = "Texto de la noticia", Description = "Texto de la noticia", Name = "Noticia")]
        [StringLength(int.MaxValue, ErrorMessage = "Invalid", MinimumLength = 100 )]
        [Required(ErrorMessage = "Escribe la noticia")]
        public String Texto { get; set; }

        [Display(Prompt = "Cantidad de producto", Description = "Cantidad de productos", Name = "Autor")]
        [Required(ErrorMessage = "Autor")]
        public String Autor { get; set; }
    }
}