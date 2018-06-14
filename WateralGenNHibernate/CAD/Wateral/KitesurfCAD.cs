
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
 * Clase Kitesurf:
 *
 */

namespace WateralGenNHibernate.CAD.Wateral
{
public partial class KitesurfCAD : BasicCAD, IKitesurfCAD
{
public KitesurfCAD() : base ()
{
}

public KitesurfCAD(ISession sessionAux) : base (sessionAux)
{
}



public KitesurfEN ReadOIDDefault (int id
                                  )
{
        KitesurfEN kitesurfEN = null;

        try
        {
                SessionInitializeTransaction ();
                kitesurfEN = (KitesurfEN)session.Get (typeof(KitesurfEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in KitesurfCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return kitesurfEN;
}

public System.Collections.Generic.IList<KitesurfEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<KitesurfEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(KitesurfEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<KitesurfEN>();
                        else
                                result = session.CreateCriteria (typeof(KitesurfEN)).List<KitesurfEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in KitesurfCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (KitesurfEN kitesurf)
{
        try
        {
                SessionInitializeTransaction ();
                KitesurfEN kitesurfEN = (KitesurfEN)session.Load (typeof(KitesurfEN), kitesurf.Id);

                kitesurfEN.Precio = kitesurf.Precio;


                kitesurfEN.Duracion = kitesurf.Duracion;

                session.Update (kitesurfEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in KitesurfCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (KitesurfEN kitesurf)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (kitesurf);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in KitesurfCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return kitesurf.Id;
}

public void Modify (KitesurfEN kitesurf)
{
        try
        {
                SessionInitializeTransaction ();
                KitesurfEN kitesurfEN = (KitesurfEN)session.Load (typeof(KitesurfEN), kitesurf.Id);

                kitesurfEN.Precio = kitesurf.Precio;


                kitesurfEN.Duracion = kitesurf.Duracion;

                session.Update (kitesurfEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in KitesurfCAD.", ex);
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
                KitesurfEN kitesurfEN = (KitesurfEN)session.Load (typeof(KitesurfEN), id);
                session.Delete (kitesurfEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in KitesurfCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
