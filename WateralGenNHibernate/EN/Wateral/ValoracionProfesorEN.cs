
using System;
// Definición clase ValoracionProfesorEN
namespace WateralGenNHibernate.EN.Wateral
{
public partial class ValoracionProfesorEN                                                                   : WateralGenNHibernate.EN.Wateral.ValoracionEN


{
/**
 *	Atributo alumno_0
 */
private WateralGenNHibernate.EN.Wateral.AlumnoEN alumno_0;



/**
 *	Atributo profesor
 */
private WateralGenNHibernate.EN.Wateral.ProfesorEN profesor;






public virtual WateralGenNHibernate.EN.Wateral.AlumnoEN Alumno_0 {
        get { return alumno_0; } set { alumno_0 = value;  }
}



public virtual WateralGenNHibernate.EN.Wateral.ProfesorEN Profesor {
        get { return profesor; } set { profesor = value;  }
}





public ValoracionProfesorEN() : base ()
{
}



public ValoracionProfesorEN(int id_valoracion, WateralGenNHibernate.EN.Wateral.AlumnoEN alumno_0, WateralGenNHibernate.EN.Wateral.ProfesorEN profesor
                            , int nota, string comentario
                            )
{
        this.init (Id_valoracion, alumno_0, profesor, nota, comentario);
}


public ValoracionProfesorEN(ValoracionProfesorEN valoracionProfesor)
{
        this.init (Id_valoracion, valoracionProfesor.Alumno_0, valoracionProfesor.Profesor, valoracionProfesor.Nota, valoracionProfesor.Comentario);
}

private void init (int id_valoracion
                   , WateralGenNHibernate.EN.Wateral.AlumnoEN alumno_0, WateralGenNHibernate.EN.Wateral.ProfesorEN profesor, int nota, string comentario)
{
        this.Id_valoracion = id_valoracion;


        this.Alumno_0 = alumno_0;

        this.Profesor = profesor;

        this.Nota = nota;

        this.Comentario = comentario;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        ValoracionProfesorEN t = obj as ValoracionProfesorEN;
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
