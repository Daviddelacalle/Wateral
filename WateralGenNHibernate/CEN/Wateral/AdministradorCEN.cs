

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
 *      Definition of the class AdministradorCEN
 *
 */
public partial class AdministradorCEN
{
private IAdministradorCAD _IAdministradorCAD;

public AdministradorCEN()
{
        this._IAdministradorCAD = new AdministradorCAD ();
}

public AdministradorCEN(IAdministradorCAD _IAdministradorCAD)
{
        this._IAdministradorCAD = _IAdministradorCAD;
}

public IAdministradorCAD get_IAdministradorCAD ()
{
        return this._IAdministradorCAD;
}

public string New_ (string p_email, string p_usuario, string p_nombre, string p_apellidos, String p_contrasenya, Nullable<DateTime> p_nacimiento, string p_imagen)
{
        AdministradorEN administradorEN = null;
        string oid;

        //Initialized AdministradorEN
        administradorEN = new AdministradorEN ();
        administradorEN.Email = p_email;

        administradorEN.Usuario = p_usuario;

        administradorEN.Nombre = p_nombre;

        administradorEN.Apellidos = p_apellidos;

        administradorEN.Contrasenya = Utils.Util.GetEncondeMD5 (p_contrasenya);

        administradorEN.Nacimiento = p_nacimiento;

        administradorEN.Imagen = p_imagen;

        //Call to AdministradorCAD

        oid = _IAdministradorCAD.New_ (administradorEN);
        return oid;
}

public void Modify (string p_Administrador_OID, string p_usuario, string p_nombre, string p_apellidos, String p_contrasenya, Nullable<DateTime> p_nacimiento, string p_imagen)
{
        AdministradorEN administradorEN = null;

        //Initialized AdministradorEN
        administradorEN = new AdministradorEN ();
        administradorEN.Email = p_Administrador_OID;
        administradorEN.Usuario = p_usuario;
        administradorEN.Nombre = p_nombre;
        administradorEN.Apellidos = p_apellidos;
        administradorEN.Contrasenya = Utils.Util.GetEncondeMD5 (p_contrasenya);
        administradorEN.Nacimiento = p_nacimiento;
        administradorEN.Imagen = p_imagen;
        //Call to AdministradorCAD

        _IAdministradorCAD.Modify (administradorEN);
}

public void Destroy (string email
                     )
{
        _IAdministradorCAD.Destroy (email);
}

public AdministradorEN ReadOID (string email
                                )
{
        AdministradorEN administradorEN = null;

        administradorEN = _IAdministradorCAD.ReadOID (email);
        return administradorEN;
}

public System.Collections.Generic.IList<AdministradorEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<AdministradorEN> list = null;

        list = _IAdministradorCAD.ReadAll (first, size);
        return list;
}
}
}
