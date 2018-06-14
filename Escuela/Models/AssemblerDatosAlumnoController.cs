using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WateralGenNHibernate.EN.Wateral;

namespace Escuela.Models
{
    public class AssemblerDatosAlumnoController
    {
        public DatosAlumno ConvertDatatoModel(GrupoEN grupaso, string nombre)
        {
            DatosAlumno data = new DatosAlumno();
            DateTime siguienteclase = grupaso.Clases[0].Fecha.Value;
            DateTime siguientehora = grupaso.Clases[0].HInicio.Value;
            data.grupo = grupaso.Id;
            data.curso = grupaso.Curso.Tipo.ToString();
            data.clase = siguienteclase;
            data.hinicio = siguientehora;
            if (grupaso.Profesor != null)
            {
                data.profesor = grupaso.Profesor.UserRegistrado.Nombre;
            }
            data.nivel = grupaso.Curso.Nombre;
            data.nombre = nombre;

            return data;
        }
    }

}