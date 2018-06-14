
using System;
// Definición clase LineaCestaEN
namespace WateralGenNHibernate.EN.Wateral
{
public partial class LineaCestaEN
{
/**
 *	Atributo cesta
 */
private WateralGenNHibernate.EN.Wateral.CestaEN cesta;



/**
 *	Atributo linea
 */
private int linea;



/**
 *	Atributo lineaPedido
 */
private WateralGenNHibernate.EN.Wateral.LineaPedidoEN lineaPedido;



/**
 *	Atributo cantidad
 */
private int cantidad;



/**
 *	Atributo dias
 */
private int dias;



/**
 *	Atributo precio
 */
private double precio;



/**
 *	Atributo producto
 */
private WateralGenNHibernate.EN.Wateral.ProductoEN producto;






public virtual WateralGenNHibernate.EN.Wateral.CestaEN Cesta {
        get { return cesta; } set { cesta = value;  }
}



public virtual int Linea {
        get { return linea; } set { linea = value;  }
}



public virtual WateralGenNHibernate.EN.Wateral.LineaPedidoEN LineaPedido {
        get { return lineaPedido; } set { lineaPedido = value;  }
}



public virtual int Cantidad {
        get { return cantidad; } set { cantidad = value;  }
}



public virtual int Dias {
        get { return dias; } set { dias = value;  }
}



public virtual double Precio {
        get { return precio; } set { precio = value;  }
}



public virtual WateralGenNHibernate.EN.Wateral.ProductoEN Producto {
        get { return producto; } set { producto = value;  }
}





public LineaCestaEN()
{
}



public LineaCestaEN(int linea, WateralGenNHibernate.EN.Wateral.CestaEN cesta, WateralGenNHibernate.EN.Wateral.LineaPedidoEN lineaPedido, int cantidad, int dias, double precio, WateralGenNHibernate.EN.Wateral.ProductoEN producto
                    )
{
        this.init (Linea, cesta, lineaPedido, cantidad, dias, precio, producto);
}


public LineaCestaEN(LineaCestaEN lineaCesta)
{
        this.init (Linea, lineaCesta.Cesta, lineaCesta.LineaPedido, lineaCesta.Cantidad, lineaCesta.Dias, lineaCesta.Precio, lineaCesta.Producto);
}

private void init (int linea
                   , WateralGenNHibernate.EN.Wateral.CestaEN cesta, WateralGenNHibernate.EN.Wateral.LineaPedidoEN lineaPedido, int cantidad, int dias, double precio, WateralGenNHibernate.EN.Wateral.ProductoEN producto)
{
        this.Linea = linea;


        this.Cesta = cesta;

        this.LineaPedido = lineaPedido;

        this.Cantidad = cantidad;

        this.Dias = dias;

        this.Precio = precio;

        this.Producto = producto;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        LineaCestaEN t = obj as LineaCestaEN;
        if (t == null)
                return false;
        if (Linea.Equals (t.Linea))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.Linea.GetHashCode ();
        return hash;
}
}
}
