
using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using WateralGenNHibernate.EN.Wateral;
using WateralGenNHibernate.CAD.Wateral;
using WateralGenNHibernate.CEN.Wateral;



/*PROTECTED REGION ID(usingWateralGenNHibernate.CP.Wateral_Cesta_anyadir) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace WateralGenNHibernate.CP.Wateral
{
public partial class CestaCP : BasicCP
{
public int Anyadir (int p_oid, int oid_producto, int cantidad, int dias)
{
        /*PROTECTED REGION ID(WateralGenNHibernate.CP.Wateral_Cesta_anyadir) ENABLED START*/


        ICestaCAD cestaCAD = null;
        CestaCEN cestaCEN = null;
        IProductoCAD productoCAD = null;
        ProductoCEN productoCEN = null;
        ILineaCestaCAD lineaCestaCAD = null;
        LineaCestaCEN lineaCestaCEN = null;




        try
        {
                SessionInitializeTransaction ();
                cestaCAD = new CestaCAD (session);
                cestaCEN = new CestaCEN (cestaCAD);
                productoCAD = new ProductoCAD (session);
                productoCEN = new ProductoCEN (productoCAD);
                lineaCestaCAD = new LineaCestaCAD (session);
                lineaCestaCEN = new LineaCestaCEN (lineaCestaCAD);
                CestaEN cestaza = cestaCEN.ReadOID (p_oid);
                Boolean prob = false;
                int id_lin = 0;
                Boolean same = false;


                foreach (LineaCestaEN x in cestaza.LineasCesta) {
                        if (x.Producto.Id == oid_producto) {
                                if (x.Dias != -1 && dias != -1) {
                                        if (x.Dias == dias) {
                                                prob = true;
                                                id_lin = x.Linea;
                                        }
                                }
                                if (x.Dias == -1 && dias == -1) {
                                        same = true;
                                        id_lin = x.Linea;
                                }
                        }
                }
                int lin1 = 0;
                if (prob) {
                        LineaCestaEN lin = lineaCestaCEN.ReadOID (id_lin);
                        int can = lin.Cantidad + cantidad;
                        WateralGenNHibernate.CP.Wateral.LineaCestaCP cp_lincesta = new WateralGenNHibernate.CP.Wateral.LineaCestaCP (session);
                        cp_lincesta.Cantidad (id_lin, can);
                        lin1 = id_lin;
                        lineaCestaCAD.ModifyDefault (lin);
                }
                else if (same) {
                        LineaCestaEN lin = lineaCestaCEN.ReadOID (id_lin);
                        int can = lin.Cantidad + cantidad;
                        WateralGenNHibernate.CP.Wateral.LineaCestaCP cp_lincesta = new WateralGenNHibernate.CP.Wateral.LineaCestaCP (session);
                        cp_lincesta.Cantidad (id_lin, can);
                        lin1 = id_lin;
                }
                else{
                        double precio_linea = 0;
                        ProductoEN productoaconsultar = productoCEN.ReadOID (oid_producto);
                        if (dias == -1) {
                                double precio = productoaconsultar.Precio_compra;
                                precio_linea = precio * cantidad;
                        }
                        else{
                                double precio = productoaconsultar.Precio_alquiler;
                                precio_linea = precio * dias * cantidad;
                        }
                        lineaCestaCAD = new LineaCestaCAD (session);
                        lineaCestaCEN = new LineaCestaCEN (lineaCestaCAD);
                        lin1 = lineaCestaCEN.New_ (p_oid, cantidad, dias, precio_linea, oid_producto);
                        LineaCestaEN linaconsultar = lineaCestaCEN.ReadOID (lin1);
                        //System.Console.WriteLine (linaconsultar.Dias);
                        //System.Console.WriteLine (linaconsultar.Precio);
                        //System.Console.WriteLine (linaconsultar.Cantidad);
                }



                SessionCommit ();
                /*IList<LineaCestaEN> lins = lineaCestaCAD.ReadAll(0,-1);
                 * LineaCestaEN haha = lineaCestaCAD.ReadOID(lin1);
                 * ProductoEN poo = haha.Producto;*/
                return lin1;
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
