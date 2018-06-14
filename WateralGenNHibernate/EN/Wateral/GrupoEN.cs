
using System;
// Definición clase GrupoEN
namespace WateralGenNHibernate.EN.Wateral
{
public partial class GrupoEN
{
/**
 *	Atributo curso
 */
private WateralGenNHibernate.EN.Wateral.CursoEN curso;



/**
 *	Atributo profesor
 */
private WateralGenNHibernate.EN.Wateral.ProfesorEN profesor;



/**
 *	Atributo clases
 */
private System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.ClaseEN> clases;



/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo maxalumnos
 */
private int maxalumnos;



/**
 *	Atributo horario
 */
private string horario;



/**
 *	Atributo alumnos
 */
private System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.AlumnoEN> alumnos;



/**
 *	Atributo solicitudes_cambio
 */
private System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.Solicitud_cambioEN> solicitudes_cambio;



/**
 *	Atributo solicitudes_cambio_0
 */
private System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.Solicitud_cambioEN> solicitudes_cambio_0;






public virtual WateralGenNHibernate.EN.Wateral.CursoEN Curso {
        get { return curso; } set { curso = value;  }
}



public virtual WateralGenNHibernate.EN.Wateral.ProfesorEN Profesor {
        get { return profesor; } set { profesor = value;  }
}



public virtual System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.ClaseEN> Clases {
        get { return clases; } set { clases = value;  }
}



public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual int Maxalumnos {
        get { return maxalumnos; } set { maxalumnos = value;  }
}



public virtual string Horario {
        get { return horario; } set { horario = value;  }
}



public virtual System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.AlumnoEN> Alumnos {
        get { return alumnos; } set { alumnos = value;  }
}



public virtual System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.Solicitud_cambioEN> Solicitudes_cambio {
        get { return solicitudes_cambio; } set { solicitudes_cambio = value;  }
}



public virtual System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.Solicitud_cambioEN> Solicitudes_cambio_0 {
        get { return solicitudes_cambio_0; } set { solicitudes_cambio_0 = value;  }
}





public GrupoEN()
{
        clases = new System.Collections.Generic.List<WateralGenNHibernate.EN.Wateral.ClaseEN>();
        alumnos = new System.Collections.Generic.List<WateralGenNHibernate.EN.Wateral.AlumnoEN>();
        solicitudes_cambio = new System.Collections.Generic.List<WateralGenNHibernate.EN.Wateral.Solicitud_cambioEN>();
        solicitudes_cambio_0 = new System.Collections.Generic.List<WateralGenNHibernate.EN.Wateral.Solicitud_cambioEN>();
}



public GrupoEN(int id, WateralGenNHibernate.EN.Wateral.CursoEN curso, WateralGenNHibernate.EN.Wateral.ProfesorEN profesor, System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.ClaseEN> clases, int maxalumnos, string horario, System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.AlumnoEN> alumnos, System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.Solicitud_cambioEN> solicitudes_cambio, System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.Solicitud_cambioEN> solicitudes_cambio_0
               )
{
        this.init (Id, curso, profesor, clases, maxalumnos, horario, alumnos, solicitudes_cambio, solicitudes_cambio_0);
}


public GrupoEN(GrupoEN grupo)
{
        this.init (Id, grupo.Curso, grupo.Profesor, grupo.Clases, grupo.Maxalumnos, grupo.Horario, grupo.Alumnos, grupo.Solicitudes_cambio, grupo.Solicitudes_cambio_0);
}

private void init (int id
                   , WateralGenNHibernate.EN.Wateral.CursoEN curso, WateralGenNHibernate.EN.Wateral.ProfesorEN profesor, System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.ClaseEN> clases, int maxalumnos, string horario, System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.AlumnoEN> alumnos, System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.Solicitud_cambioEN> solicitudes_cambio, System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.Solicitud_cambioEN> solicitudes_cambio_0)
{
        this.Id = id;


        this.Curso = curso;

        this.Profesor = profesor;

        this.Clases = clases;

        this.Maxalumnos = maxalumnos;

        this.Horario = horario;

        this.Alumnos = alumnos;

        this.Solicitudes_cambio = solicitudes_cambio;

        this.Solicitudes_cambio_0 = solicitudes_cambio_0;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        GrupoEN t = obj as GrupoEN;
        if (t == null)
                return false;
        if (Id.Equals (t.Id))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.Id.GetHashCode ();
        return hash;
}
}
}
