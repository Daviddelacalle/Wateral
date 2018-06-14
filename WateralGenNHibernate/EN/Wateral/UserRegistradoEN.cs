
using System;
// Definición clase UserRegistradoEN
namespace WateralGenNHibernate.EN.Wateral
{
public partial class UserRegistradoEN
{
/**
 *	Atributo email
 */
private string email;



/**
 *	Atributo usuario
 */
private string usuario;



/**
 *	Atributo nombre
 */
private string nombre;



/**
 *	Atributo apellidos
 */
private string apellidos;



/**
 *	Atributo contrasenya
 */
private String contrasenya;



/**
 *	Atributo telefono
 */
private string telefono;



/**
 *	Atributo nacimiento
 */
private Nullable<DateTime> nacimiento;



/**
 *	Atributo calle
 */
private string calle;



/**
 *	Atributo ciudad
 */
private string ciudad;



/**
 *	Atributo codpostal
 */
private string codpostal;



/**
 *	Atributo provincia
 */
private string provincia;



/**
 *	Atributo credito
 */
private string credito;



/**
 *	Atributo cestas
 */
private WateralGenNHibernate.EN.Wateral.CestaEN cestas;



/**
 *	Atributo valoracionesProducto
 */
private System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.ValoracionProductoEN> valoracionesProducto;



/**
 *	Atributo alumno
 */
private WateralGenNHibernate.EN.Wateral.AlumnoEN alumno;



/**
 *	Atributo mensajes
 */
private System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.MensajeEN> mensajes;



/**
 *	Atributo mensajes_0
 */
private System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.MensajeEN> mensajes_0;



/**
 *	Atributo pedidos
 */
private System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.PedidoEN> pedidos;



/**
 *	Atributo tarjetas
 */
private System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.TarjetaEN> tarjetas;



/**
 *	Atributo imagen
 */
private string imagen;



/**
 *	Atributo profesor
 */
private WateralGenNHibernate.EN.Wateral.ProfesorEN profesor;






public virtual string Email {
        get { return email; } set { email = value;  }
}



public virtual string Usuario {
        get { return usuario; } set { usuario = value;  }
}



public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}



public virtual string Apellidos {
        get { return apellidos; } set { apellidos = value;  }
}



public virtual String Contrasenya {
        get { return contrasenya; } set { contrasenya = value;  }
}



public virtual string Telefono {
        get { return telefono; } set { telefono = value;  }
}



public virtual Nullable<DateTime> Nacimiento {
        get { return nacimiento; } set { nacimiento = value;  }
}



public virtual string Calle {
        get { return calle; } set { calle = value;  }
}



public virtual string Ciudad {
        get { return ciudad; } set { ciudad = value;  }
}



public virtual string Codpostal {
        get { return codpostal; } set { codpostal = value;  }
}



public virtual string Provincia {
        get { return provincia; } set { provincia = value;  }
}



public virtual string Credito {
        get { return credito; } set { credito = value;  }
}



public virtual WateralGenNHibernate.EN.Wateral.CestaEN Cestas {
        get { return cestas; } set { cestas = value;  }
}



public virtual System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.ValoracionProductoEN> ValoracionesProducto {
        get { return valoracionesProducto; } set { valoracionesProducto = value;  }
}



public virtual WateralGenNHibernate.EN.Wateral.AlumnoEN Alumno {
        get { return alumno; } set { alumno = value;  }
}



public virtual System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.MensajeEN> Mensajes {
        get { return mensajes; } set { mensajes = value;  }
}



public virtual System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.MensajeEN> Mensajes_0 {
        get { return mensajes_0; } set { mensajes_0 = value;  }
}



public virtual System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.PedidoEN> Pedidos {
        get { return pedidos; } set { pedidos = value;  }
}



public virtual System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.TarjetaEN> Tarjetas {
        get { return tarjetas; } set { tarjetas = value;  }
}



public virtual string Imagen {
        get { return imagen; } set { imagen = value;  }
}



public virtual WateralGenNHibernate.EN.Wateral.ProfesorEN Profesor {
        get { return profesor; } set { profesor = value;  }
}





public UserRegistradoEN()
{
        valoracionesProducto = new System.Collections.Generic.List<WateralGenNHibernate.EN.Wateral.ValoracionProductoEN>();
        mensajes = new System.Collections.Generic.List<WateralGenNHibernate.EN.Wateral.MensajeEN>();
        mensajes_0 = new System.Collections.Generic.List<WateralGenNHibernate.EN.Wateral.MensajeEN>();
        pedidos = new System.Collections.Generic.List<WateralGenNHibernate.EN.Wateral.PedidoEN>();
        tarjetas = new System.Collections.Generic.List<WateralGenNHibernate.EN.Wateral.TarjetaEN>();
}



public UserRegistradoEN(string email, string usuario, string nombre, string apellidos, String contrasenya, string telefono, Nullable<DateTime> nacimiento, string calle, string ciudad, string codpostal, string provincia, string credito, WateralGenNHibernate.EN.Wateral.CestaEN cestas, System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.ValoracionProductoEN> valoracionesProducto, WateralGenNHibernate.EN.Wateral.AlumnoEN alumno, System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.MensajeEN> mensajes, System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.MensajeEN> mensajes_0, System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.PedidoEN> pedidos, System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.TarjetaEN> tarjetas, string imagen, WateralGenNHibernate.EN.Wateral.ProfesorEN profesor
                        )
{
        this.init (Email, usuario, nombre, apellidos, contrasenya, telefono, nacimiento, calle, ciudad, codpostal, provincia, credito, cestas, valoracionesProducto, alumno, mensajes, mensajes_0, pedidos, tarjetas, imagen, profesor);
}


public UserRegistradoEN(UserRegistradoEN userRegistrado)
{
        this.init (Email, userRegistrado.Usuario, userRegistrado.Nombre, userRegistrado.Apellidos, userRegistrado.Contrasenya, userRegistrado.Telefono, userRegistrado.Nacimiento, userRegistrado.Calle, userRegistrado.Ciudad, userRegistrado.Codpostal, userRegistrado.Provincia, userRegistrado.Credito, userRegistrado.Cestas, userRegistrado.ValoracionesProducto, userRegistrado.Alumno, userRegistrado.Mensajes, userRegistrado.Mensajes_0, userRegistrado.Pedidos, userRegistrado.Tarjetas, userRegistrado.Imagen, userRegistrado.Profesor);
}

private void init (string email
                   , string usuario, string nombre, string apellidos, String contrasenya, string telefono, Nullable<DateTime> nacimiento, string calle, string ciudad, string codpostal, string provincia, string credito, WateralGenNHibernate.EN.Wateral.CestaEN cestas, System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.ValoracionProductoEN> valoracionesProducto, WateralGenNHibernate.EN.Wateral.AlumnoEN alumno, System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.MensajeEN> mensajes, System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.MensajeEN> mensajes_0, System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.PedidoEN> pedidos, System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.TarjetaEN> tarjetas, string imagen, WateralGenNHibernate.EN.Wateral.ProfesorEN profesor)
{
        this.Email = email;


        this.Usuario = usuario;

        this.Nombre = nombre;

        this.Apellidos = apellidos;

        this.Contrasenya = contrasenya;

        this.Telefono = telefono;

        this.Nacimiento = nacimiento;

        this.Calle = calle;

        this.Ciudad = ciudad;

        this.Codpostal = codpostal;

        this.Provincia = provincia;

        this.Credito = credito;

        this.Cestas = cestas;

        this.ValoracionesProducto = valoracionesProducto;

        this.Alumno = alumno;

        this.Mensajes = mensajes;

        this.Mensajes_0 = mensajes_0;

        this.Pedidos = pedidos;

        this.Tarjetas = tarjetas;

        this.Imagen = imagen;

        this.Profesor = profesor;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        UserRegistradoEN t = obj as UserRegistradoEN;
        if (t == null)
                return false;
        if (Email.Equals (t.Email))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.Email.GetHashCode ();
        return hash;
}
}
}
