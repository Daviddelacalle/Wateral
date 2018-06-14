
using System;
// Definición clase ClaseEN
namespace WateralGenNHibernate.EN.Wateral
{
public partial class ClaseEN
{
/**
 *	Atributo grupo
 */
private WateralGenNHibernate.EN.Wateral.GrupoEN grupo;



/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo fecha
 */
private Nullable<DateTime> fecha;



/**
 *	Atributo hInicio
 */
private Nullable<DateTime> hInicio;



/**
 *	Atributo hFin
 */
private Nullable<DateTime> hFin;






public virtual WateralGenNHibernate.EN.Wateral.GrupoEN Grupo {
        get { return grupo; } set { grupo = value;  }
}



public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual Nullable<DateTime> Fecha {
        get { return fecha; } set { fecha = value;  }
}



public virtual Nullable<DateTime> HInicio {
        get { return hInicio; } set { hInicio = value;  }
}



public virtual Nullable<DateTime> HFin {
        get { return hFin; } set { hFin = value;  }
}





public ClaseEN()
{
}



public ClaseEN(int id, WateralGenNHibernate.EN.Wateral.GrupoEN grupo, Nullable<DateTime> fecha, Nullable<DateTime> hInicio, Nullable<DateTime> hFin
               )
{
        this.init (Id, grupo, fecha, hInicio, hFin);
}


public ClaseEN(ClaseEN clase)
{
        this.init (Id, clase.Grupo, clase.Fecha, clase.HInicio, clase.HFin);
}

private void init (int id
                   , WateralGenNHibernate.EN.Wateral.GrupoEN grupo, Nullable<DateTime> fecha, Nullable<DateTime> hInicio, Nullable<DateTime> hFin)
{
        this.Id = id;


        this.Grupo = grupo;

        this.Fecha = fecha;

        this.HInicio = hInicio;

        this.HFin = hFin;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        ClaseEN t = obj as ClaseEN;
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
