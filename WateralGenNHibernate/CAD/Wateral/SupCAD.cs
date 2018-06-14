
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
 * Clase Sup:
 *
 */

namespace WateralGenNHibernate.CAD.Wateral
{
public partial class SupCAD : BasicCAD, ISupCAD
{
public SupCAD() : base ()
{
}

public SupCAD(ISession sessionAux) : base (sessionAux)
{
}



public SupEN ReadOIDDefault (int id
                             )
{
        SupEN supEN = null;

        try
        {
                SessionInitializeTransaction ();
                supEN = (SupEN)session.Get (typeof(SupEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in SupCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return supEN;
}

public System.Collections.Generic.IList<SupEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<SupEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(SupEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<SupEN>();
                        else
                                result = session.CreateCriteria (typeof(SupEN)).List<SupEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in SupCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (SupEN sup)
{
        try
        {
                SessionInitializeTransaction ();
                SupEN supEN = (SupEN)session.Load (typeof(SupEN), sup.Id);

                supEN.Precio = sup.Precio;


                supEN.Duracion = sup.Duracion;

                session.Update (supEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in SupCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (SupEN sup)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (sup);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in SupCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return sup.Id;
}

public void Modify (SupEN sup)
{
        try
        {
                SessionInitializeTransaction ();
                SupEN supEN = (SupEN)session.Load (typeof(SupEN), sup.Id);

                supEN.Precio = sup.Precio;


                supEN.Duracion = sup.Duracion;

                session.Update (supEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in SupCAD.", ex);
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
                SupEN supEN = (SupEN)session.Load (typeof(SupEN), id);
                session.Delete (supEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in SupCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
