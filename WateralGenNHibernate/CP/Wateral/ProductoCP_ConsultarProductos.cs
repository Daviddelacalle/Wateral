
using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using WateralGenNHibernate.EN.Wateral;
using WateralGenNHibernate.CAD.Wateral;
using WateralGenNHibernate.CEN.Wateral;



/*PROTECTED REGION ID(usingWateralGenNHibernate.CP.Wateral_Producto_consultarProductos) ENABLED START*/
//  references to other libraries
using System.Collections.Generic;
/*PROTECTED REGION END*/

namespace WateralGenNHibernate.CP.Wateral
{
public partial class ProductoCP : BasicCP
{
public void ConsultarProductos (string nombre)
{
        /*PROTECTED REGION ID(WateralGenNHibernate.CP.Wateral_Producto_consultarProductos) ENABLED START*/

        IProductoCAD productoCAD = null;
        ProductoCEN productoCEN = null;



        try
        {
                SessionInitializeTransaction ();
                productoCAD = new ProductoCAD (session);
                productoCEN = new  ProductoCEN (productoCAD);



                // Write here your custom transaction ...
                IList<ProductoEN> productos = new List<ProductoEN>();
                productos = productoCEN.FiltrarProductos (nombre);
                foreach (ProductoEN x in productos) {
                        System.Console.WriteLine ("El producto es: " + x.Nombre + " = " + x.Stock);
                }



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
