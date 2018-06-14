

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
 *      Definition of the class PagoCEN
 *
 */
public partial class PagoCEN
{
private IPagoCAD _IPagoCAD;

public PagoCEN()
{
        this._IPagoCAD = new PagoCAD ();
}

public PagoCEN(IPagoCAD _IPagoCAD)
{
        this._IPagoCAD = _IPagoCAD;
}

public IPagoCAD get_IPagoCAD ()
{
        return this._IPagoCAD;
}

public int New_ (WateralGenNHibernate.Enumerated.Wateral.TipoPagoEnum p_tipo)
{
        PagoEN pagoEN = null;
        int oid;

        //Initialized PagoEN
        pagoEN = new PagoEN ();
        pagoEN.Tipo = p_tipo;

        //Call to PagoCAD

        oid = _IPagoCAD.New_ (pagoEN);
        return oid;
}

public void Modify (int p_Pago_OID, WateralGenNHibernate.Enumerated.Wateral.TipoPagoEnum p_tipo)
{
        PagoEN pagoEN = null;

        //Initialized PagoEN
        pagoEN = new PagoEN ();
        pagoEN.Id = p_Pago_OID;
        pagoEN.Tipo = p_tipo;
        //Call to PagoCAD

        _IPagoCAD.Modify (pagoEN);
}

public void Destroy (int id
                     )
{
        _IPagoCAD.Destroy (id);
}

public void AsignarPagoPedido (int p_Pago_OID, int p_pedido_OID)
{
        //Call to PagoCAD

        _IPagoCAD.AsignarPagoPedido (p_Pago_OID, p_pedido_OID);
}
public PagoEN ReadOID (int id
                       )
{
        PagoEN pagoEN = null;

        pagoEN = _IPagoCAD.ReadOID (id);
        return pagoEN;
}

public System.Collections.Generic.IList<PagoEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<PagoEN> list = null;

        list = _IPagoCAD.ReadAll (first, size);
        return list;
}
public void AsignarPagoMatricula (int p_Pago_OID, int p_matricula_OID)
{
        //Call to PagoCAD

        _IPagoCAD.AsignarPagoMatricula (p_Pago_OID, p_matricula_OID);
}
}
}
