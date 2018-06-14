using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WateralGenNHibernate.EN.Wateral;

namespace Escuela.Models
{
    public class AssemblerCurso
    {
        public Curso ConvertENToModelUI(CursoEN en)
        {
            Curso curso = new Curso();
            curso.Tipo = en.Tipo;
            curso.Nombre = en.Nombre;
            curso.Duracion = en.Duracion;
            curso.Precio = en.Precio;
            curso.Imagen = en.Imagen;
            curso.Id = en.Id;

            return curso;


        }
        public IList<Curso> ConvertListENToModel(IList<CursoEN> ens)
        {
            IList<Curso> cursos = new List<Curso>();
            foreach (CursoEN en in ens)
            {
                cursos.Add(ConvertENToModelUI(en));
            }
            return cursos;
        }

    }
}