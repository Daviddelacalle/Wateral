

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
 *      Definition of the class UserRegistradoCEN
 *
 */
public partial class UserRegistradoCEN
{
private IUserRegistradoCAD _IUserRegistradoCAD;

public UserRegistradoCEN()
{
        this._IUserRegistradoCAD = new UserRegistradoCAD ();
}

public UserRegistradoCEN(IUserRegistradoCAD _IUserRegistradoCAD)
{
        this._IUserRegistradoCAD = _IUserRegistradoCAD;
}

public IUserRegistradoCAD get_IUserRegistradoCAD ()
{
        return this._IUserRegistradoCAD;
}

public string New_ (string p_email, string p_usuario, string p_nombre, string p_apellidos, String p_contrasenya, Nullable<DateTime> p_nacimiento, string p_imagen)
{
        UserRegistradoEN userRegistradoEN = null;
        string oid;

        //Initialized UserRegistradoEN
        userRegistradoEN = new UserRegistradoEN ();
        userRegistradoEN.Email = p_email;

        userRegistradoEN.Usuario = p_usuario;

        userRegistradoEN.Nombre = p_nombre;

        userRegistradoEN.Apellidos = p_apellidos;

        userRegistradoEN.Contrasenya = Utils.Util.GetEncondeMD5 (p_contrasenya);

        userRegistradoEN.Nacimiento = p_nacimiento;

        userRegistradoEN.Imagen = p_imagen;

        //Call to UserRegistradoCAD

        oid = _IUserRegistradoCAD.New_ (userRegistradoEN);
        return oid;
}

public void Modify (string p_UserRegistrado_OID, string p_usuario, string p_nombre, string p_apellidos, String p_contrasenya, Nullable<DateTime> p_nacimiento, string p_imagen)
{
        UserRegistradoEN userRegistradoEN = null;

        //Initialized UserRegistradoEN
        userRegistradoEN = new UserRegistradoEN ();
        userRegistradoEN.Email = p_UserRegistrado_OID;
        userRegistradoEN.Usuario = p_usuario;
        userRegistradoEN.Nombre = p_nombre;
        userRegistradoEN.Apellidos = p_apellidos;
        userRegistradoEN.Contrasenya = Utils.Util.GetEncondeMD5 (p_contrasenya);
        userRegistradoEN.Nacimiento = p_nacimiento;
        userRegistradoEN.Imagen = p_imagen;
        //Call to UserRegistradoCAD

        _IUserRegistradoCAD.Modify (userRegistradoEN);
}

public void Destroy (string email
                     )
{
        _IUserRegistradoCAD.Destroy (email);
}

public UserRegistradoEN ReadOID (string email
                                 )
{
        UserRegistradoEN userRegistradoEN = null;

        userRegistradoEN = _IUserRegistradoCAD.ReadOID (email);
        return userRegistradoEN;
}

public System.Collections.Generic.IList<UserRegistradoEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<UserRegistradoEN> list = null;

        list = _IUserRegistradoCAD.ReadAll (first, size);
        return list;
}
}
}
