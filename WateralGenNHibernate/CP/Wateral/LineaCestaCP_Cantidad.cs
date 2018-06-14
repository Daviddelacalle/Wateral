
using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using WateralGenNHibernate.EN.Wateral;
using WateralGenNHibernate.CAD.Wateral;
using WateralGenNHibernate.CEN.Wateral;



/*PROTECTED REGION ID(usingWateralGenNHibernate.CP.Wateral_LineaCesta_cantidad) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace WateralGenNHibernate.CP.Wateral
{
public partial class LineaCestaCP : BasicCP
{
public void Cantidad (int p_oid, int cantidad)
{
        /*PROTECTED REGION ID(WateralGenNHibernate.CP.Wateral_LineaCesta_cantidad) ENABLED START*/

        ILineaCestaCAD lineaCestaCAD = null;
        LineaCestaCEN lineaCestaCEN = null;
        IProductoCAD productoCAD = null;
        ProductoCEN productoCEN = null;
        LineaCestaEN lineaCestaEN = null;


        try
        {
                SessionInitializeTransaction ();
                lineaCestaCAD = new LineaCestaCAD (session);
                lineaCestaCEN = new LineaCestaCEN (lineaCestaCAD);
                lineaCestaEN = lineaCestaCEN.ReadOID (p_oid);
                productoCAD = new ProductoCAD (session);
                productoCEN = new ProductoCEN (productoCAD);
                lineaCestaEN.Cantidad = cantidad;
                double precio_linea = 0;
                ProductoEN productoaconsultar = productoCEN.ReadOID (lineaCestaEN.Producto.Id);
                if (lineaCestaEN.Dias == -1) {
                        double precio = productoaconsultar.Precio_compra;
                        precio_linea = precio * cantidad;
                }
                else{
                        double precio = productoaconsultar.Precio_alquiler;
                        precio_linea = precio * lineaCestaEN.Dias * cantidad;
                }
                lineaCestaEN.Precio = precio_linea;
                lineaCestaCAD.ModifyDefault (lineaCestaEN);



                SessionCommit ();
        }
        catch (Exception ex)
        {
                SessionRollBack ();
                throw ex;
        }
        finally
        {
                SessionClose ();
        }


        /*PROTECTED REGION END*/
}
}
}
