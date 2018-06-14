
using System;
// Definición clase Usuario_RegistEN
namespace WateralGenNHibernate.EN.Wateral
{
public partial class Usuario_RegistEN
{
/**
 *	Atributo email
 */
private string email;



/**
 *	Atributo nomusuario
 */
private string nomusuario;



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
private System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.CestaEN> cestas;



/**
 *	Atributo productos
 */
private System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.ProductoEN> productos;



/**
 *	Atributo valoracionesUsuarios
 */
private System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.ValoracionEN> valoracionesUsuarios;






public virtual string Email {
        get { return email; } set { email = value;  }
}



public virtual string Nomusuario {
        get { return nomusuario; } set { nomusuario = value;  }
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



public virtual System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.CestaEN> Cestas {
        get { return cestas; } set { cestas = value;  }
}



public virtual System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.ProductoEN> Productos {
        get { return productos; } set { productos = value;  }
}



public virtual System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.ValoracionEN> ValoracionesUsuarios {
        get { return valoracionesUsuarios; } set { valoracionesUsuarios = value;  }
}





public Usuario_RegistEN()
{
        cestas = new System.Collections.Generic.List<WateralGenNHibernate.EN.Wateral.CestaEN>();
        productos = new System.Collections.Generic.List<WateralGenNHibernate.EN.Wateral.ProductoEN>();
        valoracionesUsuarios = new System.Collections.Generic.List<WateralGenNHibernate.EN.Wateral.ValoracionEN>();
}



public Usuario_RegistEN(string email, string nomusuario, string nombre, string apellidos, String contrasenya, string telefono, Nullable<DateTime> nacimiento, string calle, string ciudad, string codpostal, string provincia, string credito, System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.CestaEN> cestas, System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.ProductoEN> productos, System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.ValoracionEN> valoracionesUsuarios
                        )
{
        this.init (Email, nomusuario, nombre, apellidos, contrasenya, telefono, nacimiento, calle, ciudad, codpostal, provincia, credito, cestas, productos, valoracionesUsuarios);
}


public Usuario_RegistEN(Usuario_RegistEN usuario_Regist)
{
        this.init (Email, usuario_Regist.Nomusuario, usuario_Regist.Nombre, usuario_Regist.Apellidos, usuario_Regist.Contrasenya, usuario_Regist.Telefono, usuario_Regist.Nacimiento, usuario_Regist.Calle, usuario_Regist.Ciudad, usuario_Regist.Codpostal, usuario_Regist.Provincia, usuario_Regist.Credito, usuario_Regist.Cestas, usuario_Regist.Productos, usuario_Regist.ValoracionesUsuarios);
}

private void init (string email
                   , string nomusuario, string nombre, string apellidos, String contrasenya, string telefono, Nullable<DateTime> nacimiento, string calle, string ciudad, string codpostal, string provincia, string credito, System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.CestaEN> cestas, System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.ProductoEN> productos, System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.ValoracionEN> valoracionesUsuarios)
{
        this.Email = email;


        this.Nomusuario = nomusuario;

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

        this.Productos = productos;

        this.ValoracionesUsuarios = valoracionesUsuarios;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        Usuario_RegistEN t = obj as Usuario_RegistEN;
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
