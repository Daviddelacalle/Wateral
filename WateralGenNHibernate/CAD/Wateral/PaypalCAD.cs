
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
 * Clase Paypal:
 *
 */

namespace WateralGenNHibernate.CAD.Wateral
{
public partial class PaypalCAD : BasicCAD, IPaypalCAD
{
public PaypalCAD() : base ()
{
}

public PaypalCAD(ISession sessionAux) : base (sessionAux)
{
}



public PaypalEN ReadOIDDefault (int id
                                )
{
        PaypalEN paypalEN = null;

        try
        {
                SessionInitializeTransaction ();
                paypalEN = (PaypalEN)session.Get (typeof(PaypalEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in PaypalCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return paypalEN;
}

public System.Collections.Generic.IList<PaypalEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<PaypalEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(PaypalEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<PaypalEN>();
                        else
                                result = session.CreateCriteria (typeof(PaypalEN)).List<PaypalEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in PaypalCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (PaypalEN paypal)
{
        try
        {
                SessionInitializeTransaction ();
                PaypalEN paypalEN = (PaypalEN)session.Load (typeof(PaypalEN), paypal.Id);

                paypalEN.Usuario = paypal.Usuario;


                paypalEN.Password = paypal.Password;

                session.Update (paypalEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in PaypalCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (PaypalEN paypal)
{
        try
        {
                SessionInitializeTransaction ();
                if (paypal.Pedido != null) {
                        // Argumento OID y no colección.
                        paypal.Pedido = (WateralGenNHibernate.EN.Wateral.PedidoEN)session.Load (typeof(WateralGenNHibernate.EN.Wateral.PedidoEN), paypal.Pedido.Id);

                        paypal.Pedido.Pago
                                = paypal;
                }

                session.Save (paypal);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in PaypalCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return paypal.Id;
}

public void Modify (PaypalEN paypal)
{
        try
        {
                SessionInitializeTransaction ();
                PaypalEN paypalEN = (PaypalEN)session.Load (typeof(PaypalEN), paypal.Id);

                paypalEN.Usuario = paypal.Usuario;


                paypalEN.Password = paypal.Password;

                session.Update (paypalEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in PaypalCAD.", ex);
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
                PaypalEN paypalEN = (PaypalEN)session.Load (typeof(PaypalEN), id);
                session.Delete (paypalEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in PaypalCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
