
using System;
using System.Text;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using WateralGenNHibernate.Exceptions;
using WateralGenNHibernate.EN.Wateral;
using WateralGenNHibernate.CAD.Wateral;


/*PROTECTED REGION ID(usingWateralGenNHibernate.CEN.Wateral_Producto_modificarStock) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace WateralGenNHibernate.CEN.Wateral
{
public partial class ProductoCEN
{
public void ModificarStock (int p_oid, int cantidad)
{
        /*PROTECTED REGION ID(WateralGenNHibernate.CEN.Wateral_Producto_modificarStock) ENABLED START*/

        // Write here your custom code...

        ProductoCEN medas = new ProductoCEN ();
        ProductoCAD modifier = new ProductoCAD ();

        ProductoEN producto = medas.ReadOID (p_oid);

        if (cantidad < 0 && producto.Stock > 0) {
                producto.Stock = producto.Stock + cantidad;
                modifier.ModifyDefault (producto);
        }
        else{
                if (cantidad > 0) {
                        producto.Stock = producto.Stock + cantidad;
                        modifier.ModifyDefault (producto);
                }
        }

        /*PROTECTED REGION END*/
}
}
}
