
using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using WateralGenNHibernate.EN.Wateral;
using WateralGenNHibernate.CAD.Wateral;
using WateralGenNHibernate.CEN.Wateral;



/*PROTECTED REGION ID(usingWateralGenNHibernate.CP.Wateral_LineaCesta_create_LinPed) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace WateralGenNHibernate.CP.Wateral
{
public partial class LineaCestaCP : BasicCP
{
public int Create_LinPed (int p_oid)
{
        /*PROTECTED REGION ID(WateralGenNHibernate.CP.Wateral_LineaCesta_create_LinPed) ENABLED START*/

        ILineaCestaCAD lineaCestaCAD = null;
        LineaCestaCEN lineaCestaCEN = null;
        ILineaPedidoCAD lineaPedidoCAD = null;
        LineaPedidoCEN lineaPedidoCEN = null;

        int result = -1;


        try
        {
                SessionInitializeTransaction ();
                lineaCestaCAD = new LineaCestaCAD (session);
                lineaCestaCEN = new LineaCestaCEN (lineaCestaCAD);
                lineaPedidoCAD = new LineaPedidoCAD (session);
                lineaPedidoCEN = new LineaPedidoCEN (lineaPedidoCAD);
                LineaCestaEN cesta = lineaCestaCEN.ReadOID (p_oid);
                result = lineaPedidoCEN.New_ (cesta.Cantidad, cesta.Dias, cesta.Precio, cesta.Producto.Nombre, cesta.Producto.Imagen);
                lineaPedidoCAD.CrearPedido (result, p_oid);

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
        return result;


        /*PROTECTED REGION END*/
}
}
}
