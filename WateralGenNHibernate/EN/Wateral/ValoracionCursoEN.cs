
using System;
// Definición clase ValoracionCursoEN
namespace WateralGenNHibernate.EN.Wateral
{
public partial class ValoracionCursoEN                                                                      : WateralGenNHibernate.EN.Wateral.ValoracionEN


{
/**
 *	Atributo alumno
 */
private WateralGenNHibernate.EN.Wateral.AlumnoEN alumno;



/**
 *	Atributo curso
 */
private WateralGenNHibernate.EN.Wateral.CursoEN curso;






public virtual WateralGenNHibernate.EN.Wateral.AlumnoEN Alumno {
        get { return alumno; } set { alumno = value;  }
}



public virtual WateralGenNHibernate.EN.Wateral.CursoEN Curso {
        get { return curso; } set { curso = value;  }
}





public ValoracionCursoEN() : base ()
{
}



public ValoracionCursoEN(int id_valoracion, WateralGenNHibernate.EN.Wateral.AlumnoEN alumno, WateralGenNHibernate.EN.Wateral.CursoEN curso
                         , int nota, string comentario
                         )
{
        this.init (Id_valoracion, alumno, curso, nota, comentario);
}


public ValoracionCursoEN(ValoracionCursoEN valoracionCurso)
{
        this.init (Id_valoracion, valoracionCurso.Alumno, valoracionCurso.Curso, valoracionCurso.Nota, valoracionCurso.Comentario);
}

private void init (int id_valoracion
                   , WateralGenNHibernate.EN.Wateral.AlumnoEN alumno, WateralGenNHibernate.EN.Wateral.CursoEN curso, int nota, string comentario)
{
        this.Id_valoracion = id_valoracion;


        this.Alumno = alumno;

        this.Curso = curso;

        this.Nota = nota;

        this.Comentario = comentario;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        ValoracionCursoEN t = obj as ValoracionCursoEN;
        if (t == null)
                return false;
        if (Id_valoracion.Equals (t.Id_valoracion))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.Id_valoracion.GetHashCode ();
        return hash;
}
}
}
