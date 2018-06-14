
using System;
// Definición clase SupEN
namespace WateralGenNHibernate.EN.Wateral
{
public partial class SupEN                                                                  : WateralGenNHibernate.EN.Wateral.CursoEN


{
/**
 *	Atributo precio
 */
private int precio;



/**
 *	Atributo duracion
 */
private int duracion;






public virtual int Precio {
        get { return precio; } set { precio = value;  }
}



public virtual int Duracion {
        get { return duracion; } set { duracion = value;  }
}





public SupEN() : base ()
{
}



public SupEN(int id, int precio, int duracion
             , System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.GrupoEN> grupos, System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.ValoracionEN> valoracionesCurso, System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.AlumnoEN> alumnos
             )
{
        this.init (Id, precio, duracion, grupos, valoracionesCurso, alumnos);
}


public SupEN(SupEN sup)
{
        this.init (Id, sup.Precio, sup.Duracion, sup.Grupos, sup.ValoracionesCurso, sup.Alumnos);
}

private void init (int id
                   , int precio, int duracion, System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.GrupoEN> grupos, System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.ValoracionEN> valoracionesCurso, System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.AlumnoEN> alumnos)
{
        this.Id = id;


        this.Precio = precio;

        this.Duracion = duracion;

        this.Grupos = grupos;

        this.ValoracionesCurso = valoracionesCurso;

        this.Alumnos = alumnos;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        SupEN t = obj as SupEN;
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
