
using System;
// Definición clase TarjetaEN
namespace WateralGenNHibernate.EN.Wateral
{
public partial class TarjetaEN
{
/**
 *	Atributo numero
 */
private string numero;



/**
 *	Atributo cVC
 */
private string cVC;



/**
 *	Atributo fecha
 */
private Nullable<DateTime> fecha;



/**
 *	Atributo nombre
 */
private string nombre;



/**
 *	Atributo apellidos
 */
private string apellidos;



/**
 *	Atributo pago
 */
private System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.PagoEN> pago;



/**
 *	Atributo userRegistrado
 */
private WateralGenNHibernate.EN.Wateral.UserRegistradoEN userRegistrado;






public virtual string Numero {
        get { return numero; } set { numero = value;  }
}



public virtual string CVC {
        get { return cVC; } set { cVC = value;  }
}



public virtual Nullable<DateTime> Fecha {
        get { return fecha; } set { fecha = value;  }
}



public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}



public virtual string Apellidos {
        get { return apellidos; } set { apellidos = value;  }
}



public virtual System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.PagoEN> Pago {
        get { return pago; } set { pago = value;  }
}



public virtual WateralGenNHibernate.EN.Wateral.UserRegistradoEN UserRegistrado {
        get { return userRegistrado; } set { userRegistrado = value;  }
}





public TarjetaEN()
{
        pago = new System.Collections.Generic.List<WateralGenNHibernate.EN.Wateral.PagoEN>();
}



public TarjetaEN(string numero, string cVC, Nullable<DateTime> fecha, string nombre, string apellidos, System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.PagoEN> pago, WateralGenNHibernate.EN.Wateral.UserRegistradoEN userRegistrado
                 )
{
        this.init (Numero, cVC, fecha, nombre, apellidos, pago, userRegistrado);
}


public TarjetaEN(TarjetaEN tarjeta)
{
        this.init (Numero, tarjeta.CVC, tarjeta.Fecha, tarjeta.Nombre, tarjeta.Apellidos, tarjeta.Pago, tarjeta.UserRegistrado);
}

private void init (string numero
                   , string cVC, Nullable<DateTime> fecha, string nombre, string apellidos, System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.PagoEN> pago, WateralGenNHibernate.EN.Wateral.UserRegistradoEN userRegistrado)
{
        this.Numero = numero;


        this.CVC = cVC;

        this.Fecha = fecha;

        this.Nombre = nombre;

        this.Apellidos = apellidos;

        this.Pago = pago;

        this.UserRegistrado = userRegistrado;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        TarjetaEN t = obj as TarjetaEN;
        if (t == null)
                return false;
        if (Numero.Equals (t.Numero))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.Numero.GetHashCode ();
        return hash;
}
}
}
