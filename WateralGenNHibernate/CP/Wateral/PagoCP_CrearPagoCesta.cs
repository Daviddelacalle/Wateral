
using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using WateralGenNHibernate.EN.Wateral;
using WateralGenNHibernate.CAD.Wateral;
using WateralGenNHibernate.CEN.Wateral;



/*PROTECTED REGION ID(usingWateralGenNHibernate.CP.Wateral_Pago_crearPagoCesta) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace WateralGenNHibernate.CP.Wateral
{
public partial class PagoCP : BasicCP
{
public WateralGenNHibernate.EN.Wateral.PagoEN CrearPagoCesta (WateralGenNHibernate.Enumerated.Wateral.TipoPagoEnum p_tipo, int p_pedido)
{
        /*PROTECTED REGION ID(WateralGenNHibernate.CP.Wateral_Pago_crearPagoCesta) ENABLED START*/

        IPagoCAD pagoCAD = null;
        PagoCEN pagoCEN = null;

        WateralGenNHibernate.EN.Wateral.PagoEN result = null;


        try
        {
                SessionInitializeTransaction ();
                pagoCAD = new PagoCAD (session);
                pagoCEN = new PagoCEN (pagoCAD);




                int oid;
                //Initialized PagoEN
                PagoEN pagoEN;
                pagoEN = new PagoEN ();
                pagoEN.Tipo = p_tipo;



                //Call to PagoCAD

                oid = pagoCAD.CrearPagoCesta (pagoEN);
                result = pagoCAD.ReadOIDDefault (oid);

                pagoCEN.AsignarPagoPedido (oid, p_pedido);

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
