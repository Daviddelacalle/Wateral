

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
 *      Definition of the class LineaCestaCEN
 *
 */
public partial class LineaCestaCEN
{
private ILineaCestaCAD _ILineaCestaCAD;

public LineaCestaCEN()
{
        this._ILineaCestaCAD = new LineaCestaCAD ();
}

public LineaCestaCEN(ILineaCestaCAD _ILineaCestaCAD)
{
        this._ILineaCestaCAD = _ILineaCestaCAD;
}

public ILineaCestaCAD get_ILineaCestaCAD ()
{
        return this._ILineaCestaCAD;
}

public int New_ (int p_cesta, int p_cantidad, int p_dias, double p_precio, int p_producto)
{
        LineaCestaEN lineaCestaEN = null;
        int oid;

        //Initialized LineaCestaEN
        lineaCestaEN = new LineaCestaEN ();

        if (p_cesta != -1) {
                // El argumento p_cesta -> Property cesta es oid = false
                // Lista de oids linea
                lineaCestaEN.Cesta = new WateralGenNHibernate.EN.Wateral.CestaEN ();
                lineaCestaEN.Cesta.Id = p_cesta;
        }

        lineaCestaEN.Cantidad = p_cantidad;

        lineaCestaEN.Dias = p_dias;

        lineaCestaEN.Precio = p_precio;


        if (p_producto != -1) {
                // El argumento p_producto -> Property producto es oid = false
                // Lista de oids linea
                lineaCestaEN.Producto = new WateralGenNHibernate.EN.Wateral.ProductoEN ();
                lineaCestaEN.Producto.Id = p_producto;
        }

        //Call to LineaCestaCAD

        oid = _ILineaCestaCAD.New_ (lineaCestaEN);
        return oid;
}

public void Modify (int p_LineaCesta_OID, int p_cantidad, int p_dias, double p_precio)
{
        LineaCestaEN lineaCestaEN = null;

        //Initialized LineaCestaEN
        lineaCestaEN = new LineaCestaEN ();
        lineaCestaEN.Linea = p_LineaCesta_OID;
        lineaCestaEN.Cantidad = p_cantidad;
        lineaCestaEN.Dias = p_dias;
        lineaCestaEN.Precio = p_precio;
        //Call to LineaCestaCAD

        _ILineaCestaCAD.Modify (lineaCestaEN);
}

public void Destroy (int linea
                     )
{
        _ILineaCestaCAD.Destroy (linea);
}

public LineaCestaEN ReadOID (int linea
                             )
{
        LineaCestaEN lineaCestaEN = null;

        lineaCestaEN = _ILineaCestaCAD.ReadOID (linea);
        return lineaCestaEN;
}

public System.Collections.Generic.IList<LineaCestaEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<LineaCestaEN> list = null;

        list = _ILineaCestaCAD.ReadAll (first, size);
        return list;
}
}
}
