
using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using WateralGenNHibernate.EN.Wateral;
using WateralGenNHibernate.CAD.Wateral;
using WateralGenNHibernate.CEN.Wateral;



/*PROTECTED REGION ID(usingWateralGenNHibernate.CP.Wateral_Producto_listarProducto) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace WateralGenNHibernate.CP.Wateral
{
public partial class ProductoCP : BasicCP
{
public void ListarProducto (int p_oid)
{
        /*PROTECTED REGION ID(WateralGenNHibernate.CP.Wateral_Producto_listarProducto) ENABLED START*/

        IProductoCAD productoCAD = null;
        ProductoCEN productoCEN = null;



        try
        {
                SessionInitializeTransaction ();
                productoCAD = new ProductoCAD (session);
                productoCEN = new  ProductoCEN (productoCAD);



                // Write here your custom transaction ...

                throw new NotImplementedException ("Method ListarProducto() not yet implemented.");



#pragma warning disable CS0162 // Se ha detectado c�digo inaccesible
                SessionCommit ();
#pragma warning restore CS0162 // Se ha detectado c�digo inaccesible
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
