
using System;
// Definición clase ProfesorEN
namespace WateralGenNHibernate.EN.Wateral
{
public partial class ProfesorEN
{
/**
 *	Atributo nIF
 */
private string nIF;



/**
 *	Atributo grupos
 */
private System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.GrupoEN> grupos;



/**
 *	Atributo disponibilidad
 */
private string disponibilidad;



/**
 *	Atributo valoracionesProfesor_0
 */
private System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.ValoracionProfesorEN> valoracionesProfesor_0;



/**
 *	Atributo userRegistrado
 */
private WateralGenNHibernate.EN.Wateral.UserRegistradoEN userRegistrado;



/**
 *	Atributo deporte
 */
private WateralGenNHibernate.Enumerated.Wateral.DeportesEnum deporte;



/**
 *	Atributo id
 */
private int id;






public virtual string NIF {
        get { return nIF; } set { nIF = value;  }
}



public virtual System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.GrupoEN> Grupos {
        get { return grupos; } set { grupos = value;  }
}



public virtual string Disponibilidad {
        get { return disponibilidad; } set { disponibilidad = value;  }
}



public virtual System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.ValoracionProfesorEN> ValoracionesProfesor_0 {
        get { return valoracionesProfesor_0; } set { valoracionesProfesor_0 = value;  }
}



public virtual WateralGenNHibernate.EN.Wateral.UserRegistradoEN UserRegistrado {
        get { return userRegistrado; } set { userRegistrado = value;  }
}



public virtual WateralGenNHibernate.Enumerated.Wateral.DeportesEnum Deporte {
        get { return deporte; } set { deporte = value;  }
}



public virtual int Id {
        get { return id; } set { id = value;  }
}





public ProfesorEN()
{
        grupos = new System.Collections.Generic.List<WateralGenNHibernate.EN.Wateral.GrupoEN>();
        valoracionesProfesor_0 = new System.Collections.Generic.List<WateralGenNHibernate.EN.Wateral.ValoracionProfesorEN>();
}



public ProfesorEN(int id, string nIF, System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.GrupoEN> grupos, string disponibilidad, System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.ValoracionProfesorEN> valoracionesProfesor_0, WateralGenNHibernate.EN.Wateral.UserRegistradoEN userRegistrado, WateralGenNHibernate.Enumerated.Wateral.DeportesEnum deporte
                  )
{
        this.init (Id, nIF, grupos, disponibilidad, valoracionesProfesor_0, userRegistrado, deporte);
}


public ProfesorEN(ProfesorEN profesor)
{
        this.init (Id, profesor.NIF, profesor.Grupos, profesor.Disponibilidad, profesor.ValoracionesProfesor_0, profesor.UserRegistrado, profesor.Deporte);
}

private void init (int id
                   , string nIF, System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.GrupoEN> grupos, string disponibilidad, System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.ValoracionProfesorEN> valoracionesProfesor_0, WateralGenNHibernate.EN.Wateral.UserRegistradoEN userRegistrado, WateralGenNHibernate.Enumerated.Wateral.DeportesEnum deporte)
{
        this.Id = id;


        this.NIF = nIF;

        this.Grupos = grupos;

        this.Disponibilidad = disponibilidad;

        this.ValoracionesProfesor_0 = valoracionesProfesor_0;

        this.UserRegistrado = userRegistrado;

        this.Deporte = deporte;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        ProfesorEN t = obj as ProfesorEN;
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
