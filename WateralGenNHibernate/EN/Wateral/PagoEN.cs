
using System;
// Definición clase PagoEN
namespace WateralGenNHibernate.EN.Wateral
{
public partial class PagoEN
{
/**
 *	Atributo pedido
 */
private WateralGenNHibernate.EN.Wateral.PedidoEN pedido;



/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo tipo
 */
private WateralGenNHibernate.Enumerated.Wateral.TipoPagoEnum tipo;



/**
 *	Atributo tarjeta
 */
private WateralGenNHibernate.EN.Wateral.TarjetaEN tarjeta;



/**
 *	Atributo matricula
 */
private WateralGenNHibernate.EN.Wateral.MatriculaEN matricula;






public virtual WateralGenNHibernate.EN.Wateral.PedidoEN Pedido {
        get { return pedido; } set { pedido = value;  }
}



public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual WateralGenNHibernate.Enumerated.Wateral.TipoPagoEnum Tipo {
        get { return tipo; } set { tipo = value;  }
}



public virtual WateralGenNHibernate.EN.Wateral.TarjetaEN Tarjeta {
        get { return tarjeta; } set { tarjeta = value;  }
}



public virtual WateralGenNHibernate.EN.Wateral.MatriculaEN Matricula {
        get { return matricula; } set { matricula = value;  }
}





public PagoEN()
{
}



public PagoEN(int id, WateralGenNHibernate.EN.Wateral.PedidoEN pedido, WateralGenNHibernate.Enumerated.Wateral.TipoPagoEnum tipo, WateralGenNHibernate.EN.Wateral.TarjetaEN tarjeta, WateralGenNHibernate.EN.Wateral.MatriculaEN matricula
              )
{
        this.init (Id, pedido, tipo, tarjeta, matricula);
}


public PagoEN(PagoEN pago)
{
        this.init (Id, pago.Pedido, pago.Tipo, pago.Tarjeta, pago.Matricula);
}

private void init (int id
                   , WateralGenNHibernate.EN.Wateral.PedidoEN pedido, WateralGenNHibernate.Enumerated.Wateral.TipoPagoEnum tipo, WateralGenNHibernate.EN.Wateral.TarjetaEN tarjeta, WateralGenNHibernate.EN.Wateral.MatriculaEN matricula)
{
        this.Id = id;


        this.Pedido = pedido;

        this.Tipo = tipo;

        this.Tarjeta = tarjeta;

        this.Matricula = matricula;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        PagoEN t = obj as PagoEN;
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
