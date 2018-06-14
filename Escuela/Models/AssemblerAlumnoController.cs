using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WateralGenNHibernate.EN.Wateral;

namespace Escuela.Models
{
    public class AssemblerAlumnoController
    {
        public Alumno ConvertENToModelUI(AlumnoEN en)
        {
            Alumno alumno = new Alumno();
            alumno.Id = en.Idalumno;
            alumno.Disponibilidad = en.Disponibilidad;
            alumno.DNI = en.DNI;
            alumno.NumPie = en.NumPie;
            alumno.Peso = en.Peso;
            alumno.Salud = en.Salud;
            alumno.Talla = en.Talla.ToString();
            alumno.grupo = en.Grupos;

            return alumno;
        }
        public IList<Alumno> ConvertListENToModel(IList<AlumnoEN> ens)
        {
            IList<Alumno> alumnos = new List<Alumno>();
            foreach (AlumnoEN en in ens)
            {
                alumnos.Add(ConvertENToModelUI(en));
            }
            return alumnos;
        }
    }
}