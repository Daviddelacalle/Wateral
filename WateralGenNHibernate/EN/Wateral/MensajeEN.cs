
using System;
// Definición clase MensajeEN
namespace WateralGenNHibernate.EN.Wateral
{
public partial class MensajeEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo mensaje
 */
private string mensaje;



/**
 *	Atributo fecha
 */
private Nullable<DateTime> fecha;



/**
 *	Atributo userRegistrado
 */
private WateralGenNHibernate.EN.Wateral.UserRegistradoEN userRegistrado;



/**
 *	Atributo userRegistrado_0
 */
private WateralGenNHibernate.EN.Wateral.UserRegistradoEN userRegistrado_0;



/**
 *	Atributo leido
 */
private bool leido;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual string Mensaje {
        get { return mensaje; } set { mensaje = value;  }
}



public virtual Nullable<DateTime> Fecha {
        get { return fecha; } set { fecha = value;  }
}



public virtual WateralGenNHibernate.EN.Wateral.UserRegistradoEN UserRegistrado {
        get { return userRegistrado; } set { userRegistrado = value;  }
}



public virtual WateralGenNHibernate.EN.Wateral.UserRegistradoEN UserRegistrado_0 {
        get { return userRegistrado_0; } set { userRegistrado_0 = value;  }
}



public virtual bool Leido {
        get { return leido; } set { leido = value;  }
}





public MensajeEN()
{
}



public MensajeEN(int id, string mensaje, Nullable<DateTime> fecha, WateralGenNHibernate.EN.Wateral.UserRegistradoEN userRegistrado, WateralGenNHibernate.EN.Wateral.UserRegistradoEN userRegistrado_0, bool leido
                 )
{
        this.init (Id, mensaje, fecha, userRegistrado, userRegistrado_0, leido);
}


public MensajeEN(MensajeEN mensaje)
{
        this.init (Id, mensaje.Mensaje, mensaje.Fecha, mensaje.UserRegistrado, mensaje.UserRegistrado_0, mensaje.Leido);
}

private void init (int id
                   , string mensaje, Nullable<DateTime> fecha, WateralGenNHibernate.EN.Wateral.UserRegistradoEN userRegistrado, WateralGenNHibernate.EN.Wateral.UserRegistradoEN userRegistrado_0, bool leido)
{
        this.Id = id;


        this.Mensaje = mensaje;

        this.Fecha = fecha;

        this.UserRegistrado = userRegistrado;

        this.UserRegistrado_0 = userRegistrado_0;

        this.Leido = leido;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        MensajeEN t = obj as MensajeEN;
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
