
using System;
// Definición clase AdministradorEN
namespace WateralGenNHibernate.EN.Wateral
{
public partial class AdministradorEN                                                                        : WateralGenNHibernate.EN.Wateral.UserRegistradoEN


{
/**
 *	Atributo noticias
 */
private System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.NoticiaEN> noticias;






public virtual System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.NoticiaEN> Noticias {
        get { return noticias; } set { noticias = value;  }
}





public AdministradorEN() : base ()
{
        noticias = new System.Collections.Generic.List<WateralGenNHibernate.EN.Wateral.NoticiaEN>();
}



public AdministradorEN(string email, System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.NoticiaEN> noticias
                       , string usuario, string nombre, string apellidos, String contrasenya, string telefono, Nullable<DateTime> nacimiento, string calle, string ciudad, string codpostal, string provincia, string credito, WateralGenNHibernate.EN.Wateral.CestaEN cestas, System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.ValoracionProductoEN> valoracionesProducto, WateralGenNHibernate.EN.Wateral.AlumnoEN alumno, System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.MensajeEN> mensajes, System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.MensajeEN> mensajes_0, System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.PedidoEN> pedidos, System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.TarjetaEN> tarjetas, string imagen, WateralGenNHibernate.EN.Wateral.ProfesorEN profesor
                       )
{
        this.init (Email, noticias, usuario, nombre, apellidos, contrasenya, telefono, nacimiento, calle, ciudad, codpostal, provincia, credito, cestas, valoracionesProducto, alumno, mensajes, mensajes_0, pedidos, tarjetas, imagen, profesor);
}


public AdministradorEN(AdministradorEN administrador)
{
        this.init (Email, administrador.Noticias, administrador.Usuario, administrador.Nombre, administrador.Apellidos, administrador.Contrasenya, administrador.Telefono, administrador.Nacimiento, administrador.Calle, administrador.Ciudad, administrador.Codpostal, administrador.Provincia, administrador.Credito, administrador.Cestas, administrador.ValoracionesProducto, administrador.Alumno, administrador.Mensajes, administrador.Mensajes_0, administrador.Pedidos, administrador.Tarjetas, administrador.Imagen, administrador.Profesor);
}

private void init (string email
                   , System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.NoticiaEN> noticias, string usuario, string nombre, string apellidos, String contrasenya, string telefono, Nullable<DateTime> nacimiento, string calle, string ciudad, string codpostal, string provincia, string credito, WateralGenNHibernate.EN.Wateral.CestaEN cestas, System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.ValoracionProductoEN> valoracionesProducto, WateralGenNHibernate.EN.Wateral.AlumnoEN alumno, System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.MensajeEN> mensajes, System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.MensajeEN> mensajes_0, System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.PedidoEN> pedidos, System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.TarjetaEN> tarjetas, string imagen, WateralGenNHibernate.EN.Wateral.ProfesorEN profesor)
{
        this.Email = email;


        this.Noticias = noticias;

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
        AdministradorEN t = obj as AdministradorEN;
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
