
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
 * Clase Vela:
 *
 */

namespace WateralGenNHibernate.CAD.Wateral
{
public partial class VelaCAD : BasicCAD, IVelaCAD
{
public VelaCAD() : base ()
{
}

public VelaCAD(ISession sessionAux) : base (sessionAux)
{
}



public VelaEN ReadOIDDefault (int id
                              )
{
        VelaEN velaEN = null;

        try
        {
                SessionInitializeTransaction ();
                velaEN = (VelaEN)session.Get (typeof(VelaEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in VelaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return velaEN;
}

public System.Collections.Generic.IList<VelaEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<VelaEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(VelaEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<VelaEN>();
                        else
                                result = session.CreateCriteria (typeof(VelaEN)).List<VelaEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in VelaCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (VelaEN vela)
{
        try
        {
                SessionInitializeTransaction ();
                VelaEN velaEN = (VelaEN)session.Load (typeof(VelaEN), vela.Id);

                velaEN.Precio = vela.Precio;


                velaEN.Duracion = vela.Duracion;

                session.Update (velaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in VelaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (VelaEN vela)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (vela);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in VelaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return vela.Id;
}

public void Modify (VelaEN vela)
{
        try
        {
                SessionInitializeTransaction ();
                VelaEN velaEN = (VelaEN)session.Load (typeof(VelaEN), vela.Id);

                velaEN.Precio = vela.Precio;


                velaEN.Duracion = vela.Duracion;

                session.Update (velaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in VelaCAD.", ex);
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
                VelaEN velaEN = (VelaEN)session.Load (typeof(VelaEN), id);
                session.Delete (velaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in VelaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
