
using System;
using System.Text;
using WateralGenNHibernate.CEN.Wateral;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using WateralGenNHibernate.EN.Wateral;
using WateralGenNHibernate.Exceptions;


/*
 * Clase Pago:
 *
 */

namespace WateralGenNHibernate.CAD.Wateral
{
public partial class PagoCAD : BasicCAD, IPagoCAD
{
public PagoCAD() : base ()
{
}

public PagoCAD(ISession sessionAux) : base (sessionAux)
{
}



public PagoEN ReadOIDDefault (int id
                              )
{
        PagoEN pagoEN = null;

        try
        {
                SessionInitializeTransaction ();
                pagoEN = (PagoEN)session.Get (typeof(PagoEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in PagoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return pagoEN;
}

public System.Collections.Generic.IList<PagoEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<PagoEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(PagoEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<PagoEN>();
                        else
                                result = session.CreateCriteria (typeof(PagoEN)).List<PagoEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in PagoCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (PagoEN pago)
{
        try
        {
                SessionInitializeTransaction ();
                PagoEN pagoEN = (PagoEN)session.Load (typeof(PagoEN), pago.Id);


                pagoEN.Tipo = pago.Tipo;



                session.Update (pagoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in PagoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (PagoEN pago)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (pago);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in PagoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return pago.Id;
}

public void Modify (PagoEN pago)
{
        try
        {
                SessionInitializeTransaction ();
                PagoEN pagoEN = (PagoEN)session.Load (typeof(PagoEN), pago.Id);

                pagoEN.Tipo = pago.Tipo;

                session.Update (pagoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in PagoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Destroy (int id
                     )
{
        try
        {
                SessionInitializeTransaction ();
                PagoEN pagoEN = (PagoEN)session.Load (typeof(PagoEN), id);
                session.Delete (pagoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in PagoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public int CrearPagoCesta (PagoEN pago)
{
        try
        {
                SessionInitializeTransaction ();
                if (pago.Pedido != null) {
                        // Argumento OID y no colección.
                        pago.Pedido = (WateralGenNHibernate.EN.Wateral.PedidoEN)session.Load (typeof(WateralGenNHibernate.EN.Wateral.PedidoEN), pago.Pedido.Id);

                        pago.Pedido.Pago
                                = pago;
                }

                session.Save (pago);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in PagoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return pago.Id;
}

public void AsignarPagoPedido (int p_Pago_OID, int p_pedido_OID)
{
        WateralGenNHibernate.EN.Wateral.PagoEN pagoEN = null;
        try
        {
                SessionInitializeTransaction ();
                pagoEN = (PagoEN)session.Load (typeof(PagoEN), p_Pago_OID);
                pagoEN.Pedido = (WateralGenNHibernate.EN.Wateral.PedidoEN)session.Load (typeof(WateralGenNHibernate.EN.Wateral.PedidoEN), p_pedido_OID);

                pagoEN.Pedido.Pago = pagoEN;




                session.Update (pagoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in PagoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: PagoEN
public PagoEN ReadOID (int id
                       )
{
        PagoEN pagoEN = null;

        try
        {
                SessionInitializeTransaction ();
                pagoEN = (PagoEN)session.Get (typeof(PagoEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in PagoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return pagoEN;
}

public System.Collections.Generic.IList<PagoEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<PagoEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(PagoEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<PagoEN>();
                else
                        result = session.CreateCriteria (typeof(PagoEN)).List<PagoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in PagoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public int CrearPagoMatricula (PagoEN pago)
{
        try
        {
                SessionInitializeTransaction ();
                if (pago.Matricula != null) {
                        // Argumento OID y no colección.
                        pago.Matricula = (WateralGenNHibernate.EN.Wateral.MatriculaEN)session.Load (typeof(WateralGenNHibernate.EN.Wateral.MatriculaEN), pago.Matricula.Id);

                        pago.Matricula.Pago
                                = pago;
                }

                session.Save (pago);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in PagoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return pago.Id;
}

public void AsignarPagoMatricula (int p_Pago_OID, int p_matricula_OID)
{
        WateralGenNHibernate.EN.Wateral.PagoEN pagoEN = null;
        try
        {
                SessionInitializeTransaction ();
                pagoEN = (PagoEN)session.Load (typeof(PagoEN), p_Pago_OID);
                pagoEN.Matricula = (WateralGenNHibernate.EN.Wateral.MatriculaEN)session.Load (typeof(WateralGenNHibernate.EN.Wateral.MatriculaEN), p_matricula_OID);

                pagoEN.Matricula.Pago = pagoEN;




                session.Update (pagoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in PagoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
