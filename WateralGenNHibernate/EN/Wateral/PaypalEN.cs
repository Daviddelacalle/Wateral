
using System;
// Definición clase PaypalEN
namespace WateralGenNHibernate.EN.Wateral
{
public partial class PaypalEN                                                                       : WateralGenNHibernate.EN.Wateral.PagoEN


{
/**
 *	Atributo usuario
 */
private string usuario;



/**
 *	Atributo password
 */
private string password;






public virtual string Usuario {
        get { return usuario; } set { usuario = value;  }
}



public virtual string Password {
        get { return password; } set { password = value;  }
}





public PaypalEN() : base ()
{
}



public PaypalEN(int id, string usuario, string password
                , WateralGenNHibernate.EN.Wateral.PedidoEN pedido
                )
{
        this.init (Id, usuario, password, pedido);
}


public PaypalEN(PaypalEN paypal)
{
        this.init (Id, paypal.Usuario, paypal.Password, paypal.Pedido);
}

private void init (int id
                   , string usuario, string password, WateralGenNHibernate.EN.Wateral.PedidoEN pedido)
{
        this.Id = id;


        this.Usuario = usuario;

        this.Password = password;

        this.Pedido = pedido;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        PaypalEN t = obj as PaypalEN;
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
