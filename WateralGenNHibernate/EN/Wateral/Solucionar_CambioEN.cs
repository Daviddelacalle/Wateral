
using System;
// Definición clase Solucionar_CambioEN
namespace WateralGenNHibernate.EN.Wateral
{
public partial class Solucionar_CambioEN
{
/**
 *	Atributo alumnos
 */
private System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.AlumnoEN> alumnos;



/**
 *	Atributo grupo
 */
private WateralGenNHibernate.EN.Wateral.GrupoEN grupo;



/**
 *	Atributo grupo_0
 */
private System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.GrupoEN> grupo_0;



/**
 *	Atributo id
 */
private int id;






public virtual System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.AlumnoEN> Alumnos {
        get { return alumnos; } set { alumnos = value;  }
}



public virtual WateralGenNHibernate.EN.Wateral.GrupoEN Grupo {
        get { return grupo; } set { grupo = value;  }
}



public virtual System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.GrupoEN> Grupo_0 {
        get { return grupo_0; } set { grupo_0 = value;  }
}



public virtual int Id {
        get { return id; } set { id = value;  }
}





public Solucionar_CambioEN()
{
        alumnos = new System.Collections.Generic.List<WateralGenNHibernate.EN.Wateral.AlumnoEN>();
        grupo_0 = new System.Collections.Generic.List<WateralGenNHibernate.EN.Wateral.GrupoEN>();
}



public Solucionar_CambioEN(int id, System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.AlumnoEN> alumnos, WateralGenNHibernate.EN.Wateral.GrupoEN grupo, System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.GrupoEN> grupo_0
                           )
{
        this.init (Id, alumnos, grupo, grupo_0);
}


public Solucionar_CambioEN(Solucionar_CambioEN solucionar_Cambio)
{
        this.init (Id, solucionar_Cambio.Alumnos, solucionar_Cambio.Grupo, solucionar_Cambio.Grupo_0);
}

private void init (int id
                   , System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.AlumnoEN> alumnos, WateralGenNHibernate.EN.Wateral.GrupoEN grupo, System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.GrupoEN> grupo_0)
{
        this.Id = id;


        this.Alumnos = alumnos;

        this.Grupo = grupo;

        this.Grupo_0 = grupo_0;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        Solucionar_CambioEN t = obj as Solucionar_CambioEN;
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
