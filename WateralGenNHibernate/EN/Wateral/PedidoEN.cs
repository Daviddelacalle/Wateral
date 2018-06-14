
using System;
// Definición clase PedidoEN
namespace WateralGenNHibernate.EN.Wateral
{
public partial class PedidoEN
{
/**
 *	Atributo pago
 */
private WateralGenNHibernate.EN.Wateral.PagoEN pago;



/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo fecha
 */
private Nullable<DateTime> fecha;



/**
 *	Atributo lineasPedido
 */
private System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.LineaPedidoEN> lineasPedido;



/**
 *	Atributo userRegistrado
 */
private WateralGenNHibernate.EN.Wateral.UserRegistradoEN userRegistrado;



/**
 *	Atributo precio_total
 */
private double precio_total;






public virtual WateralGenNHibernate.EN.Wateral.PagoEN Pago {
        get { return pago; } set { pago = value;  }
}



public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual Nullable<DateTime> Fecha {
        get { return fecha; } set { fecha = value;  }
}



public virtual System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.LineaPedidoEN> LineasPedido {
        get { return lineasPedido; } set { lineasPedido = value;  }
}



public virtual WateralGenNHibernate.EN.Wateral.UserRegistradoEN UserRegistrado {
        get { return userRegistrado; } set { userRegistrado = value;  }
}



public virtual double Precio_total {
        get { return precio_total; } set { precio_total = value;  }
}





public PedidoEN()
{
        lineasPedido = new System.Collections.Generic.List<WateralGenNHibernate.EN.Wateral.LineaPedidoEN>();
}



public PedidoEN(int id, WateralGenNHibernate.EN.Wateral.PagoEN pago, Nullable<DateTime> fecha, System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.LineaPedidoEN> lineasPedido, WateralGenNHibernate.EN.Wateral.UserRegistradoEN userRegistrado, double precio_total
                )
{
        this.init (Id, pago, fecha, lineasPedido, userRegistrado, precio_total);
}


public PedidoEN(PedidoEN pedido)
{
        this.init (Id, pedido.Pago, pedido.Fecha, pedido.LineasPedido, pedido.UserRegistrado, pedido.Precio_total);
}

private void init (int id
                   , WateralGenNHibernate.EN.Wateral.PagoEN pago, Nullable<DateTime> fecha, System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.LineaPedidoEN> lineasPedido, WateralGenNHibernate.EN.Wateral.UserRegistradoEN userRegistrado, double precio_total)
{
        this.Id = id;


        this.Pago = pago;

        this.Fecha = fecha;

        this.LineasPedido = lineasPedido;

        this.UserRegistrado = userRegistrado;

        this.Precio_total = precio_total;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        PedidoEN t = obj as PedidoEN;
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
