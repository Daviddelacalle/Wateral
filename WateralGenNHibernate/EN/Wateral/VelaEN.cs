
using System;
// Definición clase VelaEN
namespace WateralGenNHibernate.EN.Wateral
{
public partial class VelaEN                                                                 : WateralGenNHibernate.EN.Wateral.CursoEN


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





public VelaEN() : base ()
{
}



public VelaEN(int id, int precio, int duracion
              , System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.GrupoEN> grupos, System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.ValoracionEN> valoracionesCurso, System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.AlumnoEN> alumnos
              )
{
        this.init (Id, precio, duracion, grupos, valoracionesCurso, alumnos);
}


public VelaEN(VelaEN vela)
{
        this.init (Id, vela.Precio, vela.Duracion, vela.Grupos, vela.ValoracionesCurso, vela.Alumnos);
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
        VelaEN t = obj as VelaEN;
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
