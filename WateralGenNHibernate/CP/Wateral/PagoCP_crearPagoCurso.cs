
using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using WateralGenNHibernate.EN.Wateral;
using WateralGenNHibernate.CAD.Wateral;
using WateralGenNHibernate.CEN.Wateral;



/*PROTECTED REGION ID(usingWateralGenNHibernate.CP.Wateral_Pago_crearPagoCurso) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace WateralGenNHibernate.CP.Wateral
{
public partial class PagoCP : BasicCP
{
public WateralGenNHibernate.EN.Wateral.PagoEN CrearPagoCurso (WateralGenNHibernate.Enumerated.Wateral.TipoPagoEnum p_tipo, bool p_pagado)
{
        /*PROTECTED REGION ID(WateralGenNHibernate.CP.Wateral_Pago_crearPagoCurso) ENABLED START*/

        IPagoCAD pagoCAD = null;
        PagoCEN pagoCEN = null;

        WateralGenNHibernate.EN.Wateral.PagoEN result = null;


        try
        {
                SessionInitializeTransaction ();
                pagoCAD = new PagoCAD (session);
                pagoCEN = new  PagoCEN (pagoCAD);




                int oid;
                //Initialized PagoEN
                PagoEN pagoEN;
                pagoEN = new PagoEN ();
                pagoEN.Tipo = p_tipo;

                pagoEN.Pagado = p_pagado;

                //Call to PagoCAD

                oid = pagoCAD.CrearPagoCurso (pagoEN);
                result = pagoCAD.ReadOIDDefault (oid);



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
