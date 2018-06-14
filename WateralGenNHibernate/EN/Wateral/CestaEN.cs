
using System;
// Definición clase CestaEN
namespace WateralGenNHibernate.EN.Wateral
{
public partial class CestaEN
{
/**
 *	Atributo usuario_Regist
 */
private WateralGenNHibernate.EN.Wateral.UserRegistradoEN usuario_Regist;



/**
 *	Atributo lineasCesta
 */
private System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.LineaCestaEN> lineasCesta;



/**
 *	Atributo id
 */
private int id;






public virtual WateralGenNHibernate.EN.Wateral.UserRegistradoEN Usuario_Regist {
        get { return usuario_Regist; } set { usuario_Regist = value;  }
}



public virtual System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.LineaCestaEN> LineasCesta {
        get { return lineasCesta; } set { lineasCesta = value;  }
}



public virtual int Id {
        get { return id; } set { id = value;  }
}





public CestaEN()
{
        lineasCesta = new System.Collections.Generic.List<WateralGenNHibernate.EN.Wateral.LineaCestaEN>();
}



public CestaEN(int id, WateralGenNHibernate.EN.Wateral.UserRegistradoEN usuario_Regist, System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.LineaCestaEN> lineasCesta
               )
{
        this.init (Id, usuario_Regist, lineasCesta);
}


public CestaEN(CestaEN cesta)
{
        this.init (Id, cesta.Usuario_Regist, cesta.LineasCesta);
}

private void init (int id
                   , WateralGenNHibernate.EN.Wateral.UserRegistradoEN usuario_Regist, System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.LineaCestaEN> lineasCesta)
{
        this.Id = id;


        this.Usuario_Regist = usuario_Regist;

        this.LineasCesta = lineasCesta;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        CestaEN t = obj as CestaEN;
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
