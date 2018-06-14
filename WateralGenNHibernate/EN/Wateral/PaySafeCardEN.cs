
using System;
// Definición clase PaySafeCardEN
namespace WateralGenNHibernate.EN.Wateral
{
public partial class PaySafeCardEN                                                                  : WateralGenNHibernate.EN.Wateral.PagoEN


{
/**
 *	Atributo codigo
 */
private string codigo;






public virtual string Codigo {
        get { return codigo; } set { codigo = value;  }
}





public PaySafeCardEN() : base ()
{
}



public PaySafeCardEN(int id, string codigo
                     , WateralGenNHibernate.EN.Wateral.PedidoEN pedido
                     )
{
        this.init (Id, codigo, pedido);
}


public PaySafeCardEN(PaySafeCardEN paySafeCard)
{
        this.init (Id, paySafeCard.Codigo, paySafeCard.Pedido);
}

private void init (int id
                   , string codigo, WateralGenNHibernate.EN.Wateral.PedidoEN pedido)
{
        this.Id = id;


        this.Codigo = codigo;

        this.Pedido = pedido;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        PaySafeCardEN t = obj as PaySafeCardEN;
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
