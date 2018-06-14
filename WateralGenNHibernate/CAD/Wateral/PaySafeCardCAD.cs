
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
 * Clase PaySafeCard:
 *
 */

namespace WateralGenNHibernate.CAD.Wateral
{
public partial class PaySafeCardCAD : BasicCAD, IPaySafeCardCAD
{
public PaySafeCardCAD() : base ()
{
}

public PaySafeCardCAD(ISession sessionAux) : base (sessionAux)
{
}



public PaySafeCardEN ReadOIDDefault (int id
                                     )
{
        PaySafeCardEN paySafeCardEN = null;

        try
        {
                SessionInitializeTransaction ();
                paySafeCardEN = (PaySafeCardEN)session.Get (typeof(PaySafeCardEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in PaySafeCardCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return paySafeCardEN;
}

public System.Collections.Generic.IList<PaySafeCardEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<PaySafeCardEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(PaySafeCardEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<PaySafeCardEN>();
                        else
                                result = session.CreateCriteria (typeof(PaySafeCardEN)).List<PaySafeCardEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in PaySafeCardCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (PaySafeCardEN paySafeCard)
{
        try
        {
                SessionInitializeTransaction ();
                PaySafeCardEN paySafeCardEN = (PaySafeCardEN)session.Load (typeof(PaySafeCardEN), paySafeCard.Id);

                paySafeCardEN.Codigo = paySafeCard.Codigo;

                session.Update (paySafeCardEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in PaySafeCardCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (PaySafeCardEN paySafeCard)
{
        try
        {
                SessionInitializeTransaction ();
                if (paySafeCard.Pedido != null) {
                        // Argumento OID y no colección.
                        paySafeCard.Pedido = (WateralGenNHibernate.EN.Wateral.PedidoEN)session.Load (typeof(WateralGenNHibernate.EN.Wateral.PedidoEN), paySafeCard.Pedido.Id);

                        paySafeCard.Pedido.Pago
                                = paySafeCard;
                }

                session.Save (paySafeCard);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in PaySafeCardCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return paySafeCard.Id;
}

public void Modify (PaySafeCardEN paySafeCard)
{
        try
        {
                SessionInitializeTransaction ();
                PaySafeCardEN paySafeCardEN = (PaySafeCardEN)session.Load (typeof(PaySafeCardEN), paySafeCard.Id);

                paySafeCardEN.Codigo = paySafeCard.Codigo;

                session.Update (paySafeCardEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in PaySafeCardCAD.", ex);
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
                PaySafeCardEN paySafeCardEN = (PaySafeCardEN)session.Load (typeof(PaySafeCardEN), id);
                session.Delete (paySafeCardEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in PaySafeCardCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
