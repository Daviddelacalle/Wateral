using System;
using System.Collections.Generic;
namespace WateralGenNHibernate.EN.Wateral
{
public class CursoEN_OID
{
private WateralGenNHibernate.Enumerated.Wateral.DeportesEnum tipo;
public virtual WateralGenNHibernate.Enumerated.Wateral.DeportesEnum Tipo {
        get { return tipo; } set { tipo = value;  }
}




private string nombre;
public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}






public CursoEN_OID()
{
}
public CursoEN_OID(WateralGenNHibernate.Enumerated.Wateral.DeportesEnum tipo, string nombre)
{
        this.tipo = tipo;
        this.nombre = nombre;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        CursoEN_OID t = obj as CursoEN_OID;
        if (t == null)
                return false;


        if (this.tipo == t.Tipo && this.nombre == t.Nombre)

                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        // Su tipo es Enum
        hash = hash +
               (null == tipo                                                     ? 0 : this.tipo.GetHashCode ());
        // Su tipo es String
        hash = hash +
               (null == nombre                                                   ? 0 : this.nombre.GetHashCode ());
        return hash;
}
}
}
