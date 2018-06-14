using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Collections.Generic;

namespace Escuela.Models
{
    public class PedidoCompleto
    {

        [Display(Prompt = "Nombre del producto", Description = "Nombre del producto", Name = "Id")]
        [Required(ErrorMessage = "Debe indicar un nombre para el curso")]
        public int Id { get; set; }

        [Display(Prompt = "Nombre del producto", Description = "Nombre del producto", Name = "Fecha")]
        [Required(ErrorMessage = "Debe indicar un nombre para el curso")]
        public DateTime Fecha { get; set; }


        

        [Display(Prompt = "Precio del pedido", Description = "Precio del pedido", Name = "Precio")]
        [Required(ErrorMessage = "Debe indicar un precio para el curso")]
        public Double Precio { get; set; }

        

    }
}