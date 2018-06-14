

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
 *      Definition of the class PedidoCEN
 *
 */
public partial class PedidoCEN
{
private IPedidoCAD _IPedidoCAD;

public PedidoCEN()
{
        this._IPedidoCAD = new PedidoCAD ();
}

public PedidoCEN(IPedidoCAD _IPedidoCAD)
{
        this._IPedidoCAD = _IPedidoCAD;
}

public IPedidoCAD get_IPedidoCAD ()
{
        return this._IPedidoCAD;
}

public int New_ (Nullable<DateTime> p_fecha, System.Collections.Generic.IList<WateralGenNHibernate.EN.Wateral.LineaPedidoEN> p_lineasPedido, string p_userRegistrado, double p_precio_total)
{
        PedidoEN pedidoEN = null;
        int oid;

        //Initialized PedidoEN
        pedidoEN = new PedidoEN ();
        pedidoEN.Fecha = p_fecha;

        pedidoEN.LineasPedido = p_lineasPedido;


        if (p_userRegistrado != null) {
                // El argumento p_userRegistrado -> Property userRegistrado es oid = false
                // Lista de oids id
                pedidoEN.UserRegistrado = new WateralGenNHibernate.EN.Wateral.UserRegistradoEN ();
                pedidoEN.UserRegistrado.Email = p_userRegistrado;
        }

        pedidoEN.Precio_total = p_precio_total;

        //Call to PedidoCAD

        oid = _IPedidoCAD.New_ (pedidoEN);
        return oid;
}

public void Modify (int p_Pedido_OID, Nullable<DateTime> p_fecha, double p_precio_total)
{
        PedidoEN pedidoEN = null;

        //Initialized PedidoEN
        pedidoEN = new PedidoEN ();
        pedidoEN.Id = p_Pedido_OID;
        pedidoEN.Fecha = p_fecha;
        pedidoEN.Precio_total = p_precio_total;
        //Call to PedidoCAD

        _IPedidoCAD.Modify (pedidoEN);
}

public void Destroy (int id
                     )
{
        _IPedidoCAD.Destroy (id);
}

public PedidoEN ReadOID (int id
                         )
{
        PedidoEN pedidoEN = null;

        pedidoEN = _IPedidoCAD.ReadOID (id);
        return pedidoEN;
}

public System.Collections.Generic.IList<PedidoEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<PedidoEN> list = null;

        list = _IPedidoCAD.ReadAll (first, size);
        return list;
}
}
}
