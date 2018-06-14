
using System;
// Definición clase ValoracionProductoEN
namespace WateralGenNHibernate.EN.Wateral
{
public partial class ValoracionProductoEN                                                                   : WateralGenNHibernate.EN.Wateral.ValoracionEN


{
/**
 *	Atributo userRegistrado
 */
private WateralGenNHibernate.EN.Wateral.UserRegistradoEN userRegistrado;



/**
 *	Atributo producto
 */
private WateralGenNHibernate.EN.Wateral.ProductoEN producto;






public virtual WateralGenNHibernate.EN.Wateral.UserRegistradoEN UserRegistrado {
        get { return userRegistrado; } set { userRegistrado = value;  }
}



public virtual WateralGenNHibernate.EN.Wateral.ProductoEN Producto {
        get { return producto; } set { producto = value;  }
}





public ValoracionProductoEN() : base ()
{
}



public ValoracionProductoEN(int id_valoracion, WateralGenNHibernate.EN.Wateral.UserRegistradoEN userRegistrado, WateralGenNHibernate.EN.Wateral.ProductoEN producto
                            , int nota, string comentario
                            )
{
        this.init (Id_valoracion, userRegistrado, producto, nota, comentario);
}


public ValoracionProductoEN(ValoracionProductoEN valoracionProducto)
{
        this.init (Id_valoracion, valoracionProducto.UserRegistrado, valoracionProducto.Producto, valoracionProducto.Nota, valoracionProducto.Comentario);
}

private void init (int id_valoracion
                   , WateralGenNHibernate.EN.Wateral.UserRegistradoEN userRegistrado, WateralGenNHibernate.EN.Wateral.ProductoEN producto, int nota, string comentario)
{
        this.Id_valoracion = id_valoracion;


        this.UserRegistrado = userRegistrado;

        this.Producto = producto;

        this.Nota = nota;

        this.Comentario = comentario;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        ValoracionProductoEN t = obj as ValoracionProductoEN;
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
