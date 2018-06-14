
using System;
// Definición clase Solicitud_cambioEN
namespace WateralGenNHibernate.EN.Wateral
{
public partial class Solicitud_cambioEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo validado
 */
private bool validado;



/**
 *	Atributo alumno
 */
private WateralGenNHibernate.EN.Wateral.AlumnoEN alumno;



/**
 *	Atributo grupo
 */
private WateralGenNHibernate.EN.Wateral.GrupoEN grupo;



/**
 *	Atributo grupo_0
 */
private WateralGenNHibernate.EN.Wateral.GrupoEN grupo_0;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual bool Validado {
        get { return validado; } set { validado = value;  }
}



public virtual WateralGenNHibernate.EN.Wateral.AlumnoEN Alumno {
        get { return alumno; } set { alumno = value;  }
}



public virtual WateralGenNHibernate.EN.Wateral.GrupoEN Grupo {
        get { return grupo; } set { grupo = value;  }
}



public virtual WateralGenNHibernate.EN.Wateral.GrupoEN Grupo_0 {
        get { return grupo_0; } set { grupo_0 = value;  }
}





public Solicitud_cambioEN()
{
}



public Solicitud_cambioEN(int id, bool validado, WateralGenNHibernate.EN.Wateral.AlumnoEN alumno, WateralGenNHibernate.EN.Wateral.GrupoEN grupo, WateralGenNHibernate.EN.Wateral.GrupoEN grupo_0
                          )
{
        this.init (Id, validado, alumno, grupo, grupo_0);
}


public Solicitud_cambioEN(Solicitud_cambioEN solicitud_cambio)
{
        this.init (Id, solicitud_cambio.Validado, solicitud_cambio.Alumno, solicitud_cambio.Grupo, solicitud_cambio.Grupo_0);
}

private void init (int id
                   , bool validado, WateralGenNHibernate.EN.Wateral.AlumnoEN alumno, WateralGenNHibernate.EN.Wateral.GrupoEN grupo, WateralGenNHibernate.EN.Wateral.GrupoEN grupo_0)
{
        this.Id = id;


        this.Validado = validado;

        this.Alumno = alumno;

        this.Grupo = grupo;

        this.Grupo_0 = grupo_0;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        Solicitud_cambioEN t = obj as Solicitud_cambioEN;
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
