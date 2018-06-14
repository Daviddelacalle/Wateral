using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WateralGenNHibernate.EN.Wateral;

namespace Escuela.Models
{
    public class AssemblerGrupo
    {
        public GrupoModel ConvertENToModelUI(GrupoEN en)
        {
            GrupoModel grupo = new GrupoModel();
            grupo.id = en.Id;
            grupo.curso = en.Curso.Tipo.ToString();
            grupo.nivel = en.Curso.Nombre;
            grupo.profesor = en.Profesor.UserRegistrado.Email;
            grupo.horario = en.Horario;
            grupo.alumnos = new List<string>();
            if (en.Alumnos != null)
            {
                foreach (AlumnoEN a in en.Alumnos)
                {
                    grupo.alumnos.Add(a.UserRegistrado.Email);
                }
            }
            else
            {
                grupo.alumnos.Add("No hay alumnos en este grupo");
            }
            return grupo;
        }
        public IList<GrupoModel> ConvertListENToModel(IList<GrupoEN> ens)
        {
            IList<GrupoModel> grupos = new List<GrupoModel>();
            foreach (GrupoEN en in ens)
            {
                grupos.Add(ConvertENToModelUI(en));
            }
            return grupos;
        }
    }
}