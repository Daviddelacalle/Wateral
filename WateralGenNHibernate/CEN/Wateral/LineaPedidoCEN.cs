

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
 *      Definition of the class LineaPedidoCEN
 *
 */
public partial class LineaPedidoCEN
{
private ILineaPedidoCAD _ILineaPedidoCAD;

public LineaPedidoCEN()
{
        this._ILineaPedidoCAD = new LineaPedidoCAD ();
}

public LineaPedidoCEN(ILineaPedidoCAD _ILineaPedidoCAD)
{
        this._ILineaPedidoCAD = _ILineaPedidoCAD;
}

public ILineaPedidoCAD get_ILineaPedidoCAD ()
{
        return this._ILineaPedidoCAD;
}

public int New_ (int p_cantidad, int p_dias, double p_precio, string p_producto, string p_imagen)
{
        LineaPedidoEN lineaPedidoEN = null;
        int oid;

        //Initialized LineaPedidoEN
        lineaPedidoEN = new LineaPedidoEN ();
        lineaPedidoEN.Cantidad = p_cantidad;

        lineaPedidoEN.Dias = p_dias;

        lineaPedidoEN.Precio = p_precio;

        lineaPedidoEN.Producto = p_producto;

        lineaPedidoEN.Imagen = p_imagen;

        //Call to LineaPedidoCAD

        oid = _ILineaPedidoCAD.New_ (lineaPedidoEN);
        return oid;
}

public void Modify (int p_LineaPedido_OID, int p_cantidad, int p_dias, double p_precio, string p_producto, string p_imagen)
{
        LineaPedidoEN lineaPedidoEN = null;

        //Initialized LineaPedidoEN
        lineaPedidoEN = new LineaPedidoEN ();
        lineaPedidoEN.Id = p_LineaPedido_OID;
        lineaPedidoEN.Cantidad = p_cantidad;
        lineaPedidoEN.Dias = p_dias;
        lineaPedidoEN.Precio = p_precio;
        lineaPedidoEN.Producto = p_producto;
        lineaPedidoEN.Imagen = p_imagen;
        //Call to LineaPedidoCAD

        _ILineaPedidoCAD.Modify (lineaPedidoEN);
}

public void Destroy (int id
                     )
{
        _ILineaPedidoCAD.Destroy (id);
}

public LineaPedidoEN ReadOID (int id
                              )
{
        LineaPedidoEN lineaPedidoEN = null;

        lineaPedidoEN = _ILineaPedidoCAD.ReadOID (id);
        return lineaPedidoEN;
}

public System.Collections.Generic.IList<LineaPedidoEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<LineaPedidoEN> list = null;

        list = _ILineaPedidoCAD.ReadAll (first, size);
        return list;
}
public void CrearPedido (int p_LineaPedido_OID, int p_lineaCesta_OID)
{
        //Call to LineaPedidoCAD

        _ILineaPedidoCAD.CrearPedido (p_LineaPedido_OID, p_lineaCesta_OID);
}
public void EliminarCesta (int p_LineaPedido_OID, int p_lineaCesta_OID)
{
        //Call to LineaPedidoCAD

        _ILineaPedidoCAD.EliminarCesta (p_LineaPedido_OID, p_lineaCesta_OID);
}
}
}
