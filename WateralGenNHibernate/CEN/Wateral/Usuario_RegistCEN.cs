

using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using WateralGenNHibernate.Exceptions;

using WateralGenNHibernate.EN.Wateral;
using WateralGenNHibernate.CAD.Wateral;


namespace WateralGenNHibernate.CEN.Wateral
{
/*
 *      Definition of the class Usuario_RegistCEN
 *
 */
public partial class Usuario_RegistCEN
{
private IUsuario_RegistCAD _IUsuario_RegistCAD;

public Usuario_RegistCEN()
{
        this._IUsuario_RegistCAD = new Usuario_RegistCAD ();
}

public Usuario_RegistCEN(IUsuario_RegistCAD _IUsuario_RegistCAD)
{
        this._IUsuario_RegistCAD = _IUsuario_RegistCAD;
}

public IUsuario_RegistCAD get_IUsuario_RegistCAD ()
{
        return this._IUsuario_RegistCAD;
}

public string New_ (string p_email, string p_nomusuario, string p_nombre, string p_apellidos, String p_contrasenya, string p_telefono, Nullable<DateTime> p_nacimiento, string p_calle, string p_ciudad, string p_codpostal, string p_provincia, string p_credito)
{
        Usuario_RegistEN usuario_RegistEN = null;
        string oid;

        //Initialized Usuario_RegistEN
        usuario_RegistEN = new Usuario_RegistEN ();
        usuario_RegistEN.Email = p_email;

        usuario_RegistEN.Nomusuario = p_nomusuario;

        usuario_RegistEN.Nombre = p_nombre;

        usuario_RegistEN.Apellidos = p_apellidos;

        usuario_RegistEN.Contrasenya = Utils.Util.GetEncondeMD5 (p_contrasenya);

        usuario_RegistEN.Telefono = p_telefono;

        usuario_RegistEN.Nacimiento = p_nacimiento;

        usuario_RegistEN.Calle = p_calle;

        usuario_RegistEN.Ciudad = p_ciudad;

        usuario_RegistEN.Codpostal = p_codpostal;

        usuario_RegistEN.Provincia = p_provincia;

        usuario_RegistEN.Credito = p_credito;

        //Call to Usuario_RegistCAD

        oid = _IUsuario_RegistCAD.New_ (usuario_RegistEN);
        return oid;
}

public void Modify (string p_Usuario_Regist_OID, string p_nomusuario, string p_nombre, string p_apellidos, String p_contrasenya, string p_telefono, Nullable<DateTime> p_nacimiento, string p_calle, string p_ciudad, string p_codpostal, string p_provincia, string p_credito)
{
        Usuario_RegistEN usuario_RegistEN = null;

        //Initialized Usuario_RegistEN
        usuario_RegistEN = new Usuario_RegistEN ();
        usuario_RegistEN.Email = p_Usuario_Regist_OID;
        usuario_RegistEN.Nomusuario = p_nomusuario;
        usuario_RegistEN.Nombre = p_nombre;
        usuario_RegistEN.Apellidos = p_apellidos;
        usuario_RegistEN.Contrasenya = Utils.Util.GetEncondeMD5 (p_contrasenya);
        usuario_RegistEN.Telefono = p_telefono;
        usuario_RegistEN.Nacimiento = p_nacimiento;
        usuario_RegistEN.Calle = p_calle;
        usuario_RegistEN.Ciudad = p_ciudad;
        usuario_RegistEN.Codpostal = p_codpostal;
        usuario_RegistEN.Provincia = p_provincia;
        usuario_RegistEN.Credito = p_credito;
        //Call to Usuario_RegistCAD

        _IUsuario_RegistCAD.Modify (usuario_RegistEN);
}

public void Destroy (string email
                     )
{
        _IUsuario_RegistCAD.Destroy (email);
}

public Usuario_RegistEN ReadOID (string email
                                 )
{
        Usuario_RegistEN usuario_RegistEN = null;

        usuario_RegistEN = _IUsuario_RegistCAD.ReadOID (email);
        return usuario_RegistEN;
}

public System.Collections.Generic.IList<Usuario_RegistEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<Usuario_RegistEN> list = null;

        list = _IUsuario_RegistCAD.ReadAll (first, size);
        return list;
}
}
}
