

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
 *      Definition of the class TarjetaCEN
 *
 */
public partial class TarjetaCEN
{
private ITarjetaCAD _ITarjetaCAD;

public TarjetaCEN()
{
        this._ITarjetaCAD = new TarjetaCAD ();
}

public TarjetaCEN(ITarjetaCAD _ITarjetaCAD)
{
        this._ITarjetaCAD = _ITarjetaCAD;
}

public ITarjetaCAD get_ITarjetaCAD ()
{
        return this._ITarjetaCAD;
}

public string New_ (string p_numero, string p_CVC, Nullable<DateTime> p_fecha, string p_nombre, string p_apellidos, string p_userRegistrado)
{
        TarjetaEN tarjetaEN = null;
        string oid;

        //Initialized TarjetaEN
        tarjetaEN = new TarjetaEN ();
        tarjetaEN.Numero = p_numero;

        tarjetaEN.CVC = p_CVC;

        tarjetaEN.Fecha = p_fecha;

        tarjetaEN.Nombre = p_nombre;

        tarjetaEN.Apellidos = p_apellidos;


        if (p_userRegistrado != null) {
                // El argumento p_userRegistrado -> Property userRegistrado es oid = false
                // Lista de oids numero
                tarjetaEN.UserRegistrado = new WateralGenNHibernate.EN.Wateral.UserRegistradoEN ();
                tarjetaEN.UserRegistrado.Email = p_userRegistrado;
        }

        //Call to TarjetaCAD

        oid = _ITarjetaCAD.New_ (tarjetaEN);
        return oid;
}

public void Modify (string p_Tarjeta_OID, string p_CVC, Nullable<DateTime> p_fecha, string p_nombre, string p_apellidos)
{
        TarjetaEN tarjetaEN = null;

        //Initialized TarjetaEN
        tarjetaEN = new TarjetaEN ();
        tarjetaEN.Numero = p_Tarjeta_OID;
        tarjetaEN.CVC = p_CVC;
        tarjetaEN.Fecha = p_fecha;
        tarjetaEN.Nombre = p_nombre;
        tarjetaEN.Apellidos = p_apellidos;
        //Call to TarjetaCAD

        _ITarjetaCAD.Modify (tarjetaEN);
}

public void Destroy (string numero
                     )
{
        _ITarjetaCAD.Destroy (numero);
}

public TarjetaEN ReadOID (string numero
                          )
{
        TarjetaEN tarjetaEN = null;

        tarjetaEN = _ITarjetaCAD.ReadOID (numero);
        return tarjetaEN;
}

public System.Collections.Generic.IList<TarjetaEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<TarjetaEN> list = null;

        list = _ITarjetaCAD.ReadAll (first, size);
        return list;
}
}
}
