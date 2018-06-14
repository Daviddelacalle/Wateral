
using System;
// Definición clase LineaPedidoEN
namespace WateralGenNHibernate.EN.Wateral
{
public partial class LineaPedidoEN
{
/**
 *	Atributo lineaCesta
 */
private WateralGenNHibernate.EN.Wateral.LineaCestaEN lineaCesta;



/**
 *	Atributo pedido
 */
private WateralGenNHibernate.EN.Wateral.PedidoEN pedido;



/**
 *	Atributo id
 */
private int id;



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
private string producto;



/**
 *	Atributo imagen
 */
private string imagen;






public virtual WateralGenNHibernate.EN.Wateral.LineaCestaEN LineaCesta {
        get { return lineaCesta; } set { lineaCesta = value;  }
}



public virtual WateralGenNHibernate.EN.Wateral.PedidoEN Pedido {
        get { return pedido; } set { pedido = value;  }
}



public virtual int Id {
        get { return id; } set { id = value;  }
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



public virtual string Producto {
        get { return producto; } set { producto = value;  }
}



public virtual string Imagen {
        get { return imagen; } set { imagen = value;  }
}





public LineaPedidoEN()
{
}



public LineaPedidoEN(int id, WateralGenNHibernate.EN.Wateral.LineaCestaEN lineaCesta, WateralGenNHibernate.EN.Wateral.PedidoEN pedido, int cantidad, int dias, double precio, string producto, string imagen
                     )
{
        this.init (Id, lineaCesta, pedido, cantidad, dias, precio, producto, imagen);
}


public LineaPedidoEN(LineaPedidoEN lineaPedido)
{
        this.init (Id, lineaPedido.LineaCesta, lineaPedido.Pedido, lineaPedido.Cantidad, lineaPedido.Dias, lineaPedido.Precio, lineaPedido.Producto, lineaPedido.Imagen);
}

private void init (int id
                   , WateralGenNHibernate.EN.Wateral.LineaCestaEN lineaCesta, WateralGenNHibernate.EN.Wateral.PedidoEN pedido, int cantidad, int dias, double precio, string producto, string imagen)
{
        this.Id = id;


        this.LineaCesta = lineaCesta;

        this.Pedido = pedido;

        this.Cantidad = cantidad;

        this.Dias = dias;

        this.Precio = precio;

        this.Producto = producto;

        this.Imagen = imagen;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        LineaPedidoEN t = obj as LineaPedidoEN;
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
