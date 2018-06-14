

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
 *      Definition of the class MensajeCEN
 *
 */
public partial class MensajeCEN
{
private IMensajeCAD _IMensajeCAD;

public MensajeCEN()
{
        this._IMensajeCAD = new MensajeCAD ();
}

public MensajeCEN(IMensajeCAD _IMensajeCAD)
{
        this._IMensajeCAD = _IMensajeCAD;
}

public IMensajeCAD get_IMensajeCAD ()
{
        return this._IMensajeCAD;
}

public int New_ (string p_mensaje, Nullable<DateTime> p_fecha, string p_userRegistrado, string p_userRegistrado_0, bool p_leido)
{
        MensajeEN mensajeEN = null;
        int oid;

        //Initialized MensajeEN
        mensajeEN = new MensajeEN ();
        mensajeEN.Mensaje = p_mensaje;

        mensajeEN.Fecha = p_fecha;


        if (p_userRegistrado != null) {
                // El argumento p_userRegistrado -> Property userRegistrado es oid = false
                // Lista de oids id
                mensajeEN.UserRegistrado = new WateralGenNHibernate.EN.Wateral.UserRegistradoEN ();
                mensajeEN.UserRegistrado.Email = p_userRegistrado;
        }


        if (p_userRegistrado_0 != null) {
                // El argumento p_userRegistrado_0 -> Property userRegistrado_0 es oid = false
                // Lista de oids id
                mensajeEN.UserRegistrado_0 = new WateralGenNHibernate.EN.Wateral.UserRegistradoEN ();
                mensajeEN.UserRegistrado_0.Email = p_userRegistrado_0;
        }

        mensajeEN.Leido = p_leido;

        //Call to MensajeCAD

        oid = _IMensajeCAD.New_ (mensajeEN);
        return oid;
}

public void Modify (int p_Mensaje_OID, string p_mensaje, Nullable<DateTime> p_fecha, bool p_leido)
{
        MensajeEN mensajeEN = null;

        //Initialized MensajeEN
        mensajeEN = new MensajeEN ();
        mensajeEN.Id = p_Mensaje_OID;
        mensajeEN.Mensaje = p_mensaje;
        mensajeEN.Fecha = p_fecha;
        mensajeEN.Leido = p_leido;
        //Call to MensajeCAD

        _IMensajeCAD.Modify (mensajeEN);
}

public void Destroy (int id
                     )
{
        _IMensajeCAD.Destroy (id);
}

public MensajeEN ReadOID (int id
                          )
{
        MensajeEN mensajeEN = null;

        mensajeEN = _IMensajeCAD.ReadOID (id);
        return mensajeEN;
}

public System.Collections.Generic.IList<MensajeEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<MensajeEN> list = null;

        list = _IMensajeCAD.ReadAll (first, size);
        return list;
}
}
}
