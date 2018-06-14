using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Escuela.Models
{
    public class DatosAlumno
    {
        public string nombre { get; set; }
        public int grupo { get; set; }

        public string curso { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime clase { get; set; }

        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Time)]
        public DateTime hinicio { get; set; }        

        public string profesor { get; set; }

        public string nivel { get; set; }
    }
}