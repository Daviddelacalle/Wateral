
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
 * Clase Windsurf:
 *
 */

namespace WateralGenNHibernate.CAD.Wateral
{
public partial class WindsurfCAD : BasicCAD, IWindsurfCAD
{
public WindsurfCAD() : base ()
{
}

public WindsurfCAD(ISession sessionAux) : base (sessionAux)
{
}



public WindsurfEN ReadOIDDefault (int id
                                  )
{
        WindsurfEN windsurfEN = null;

        try
        {
                SessionInitializeTransaction ();
                windsurfEN = (WindsurfEN)session.Get (typeof(WindsurfEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in WindsurfCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return windsurfEN;
}

public System.Collections.Generic.IList<WindsurfEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<WindsurfEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(WindsurfEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<WindsurfEN>();
                        else
                                result = session.CreateCriteria (typeof(WindsurfEN)).List<WindsurfEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in WindsurfCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (WindsurfEN windsurf)
{
        try
        {
                SessionInitializeTransaction ();
                WindsurfEN windsurfEN = (WindsurfEN)session.Load (typeof(WindsurfEN), windsurf.Id);

                windsurfEN.Precio = windsurf.Precio;


                windsurfEN.Duracion = windsurf.Duracion;

                session.Update (windsurfEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in WindsurfCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (WindsurfEN windsurf)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (windsurf);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in WindsurfCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return windsurf.Id;
}

public void Modify (WindsurfEN windsurf)
{
        try
        {
                SessionInitializeTransaction ();
                WindsurfEN windsurfEN = (WindsurfEN)session.Load (typeof(WindsurfEN), windsurf.Id);

                windsurfEN.Precio = windsurf.Precio;


                windsurfEN.Duracion = windsurf.Duracion;

                session.Update (windsurfEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in WindsurfCAD.", ex);
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
                WindsurfEN windsurfEN = (WindsurfEN)session.Load (typeof(WindsurfEN), id);
                session.Delete (windsurfEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in WindsurfCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
