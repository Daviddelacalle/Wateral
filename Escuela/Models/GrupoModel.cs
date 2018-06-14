using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Escuela.Models
{
    public class GrupoModel
    {
        public int id { get; set; }

        public string curso { get; set; }

        public string nivel { get; set; }

        public string profesor { get; set; }

        public string horario { get; set; }

        public IList<string> alumnos { get; set; }

    }
}