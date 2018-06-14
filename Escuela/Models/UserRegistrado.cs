using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Escuela.Models
{
    public class UserRegistrado
    {

        [Display(Prompt = "Email del usuario", Description = "Nombre del artículo", Name = "Email ")]
        [Required(ErrorMessage = "Debe indicar un nombre para el artículo")]
        [StringLength(maximumLength: 200, ErrorMessage = "El nombre no puede tener más de 200 caracteres")]
        public string Email { get; set; }

        [Display(Prompt = "Nombre del usuario", Description = "Nombre del usuario", Name = "Nombre ")]
        [Required(ErrorMessage = "Debe indicar un nombre para el artículo")]
        [StringLength(maximumLength: 200, ErrorMessage = "El nombre no puede tener más de 200 caracteres")]
        public string Nombre { get; set; }

        [Display(Prompt = "Email del usuario", Description = "Nombre del artículo", Name = "Email ")]
        [Required(ErrorMessage = "Debe indicar un nombre para el artículo")]
        [StringLength(maximumLength: 200, ErrorMessage = "El nombre no puede tener más de 200 caracteres")]
        public string Rol { get; set; }

        [Display(Prompt = "Email del usuario", Description = "Nombre del artículo", Name = "Email ")]
        [Required(ErrorMessage = "Debe indicar un nombre para el artículo")]
        [StringLength(maximumLength: 200, ErrorMessage = "El nombre no puede tener más de 200 caracteres")]
        public string Fotoperfil { get; set; }

    }
}