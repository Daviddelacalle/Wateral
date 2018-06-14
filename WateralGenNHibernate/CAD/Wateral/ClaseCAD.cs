
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
 * Clase Clase:
 *
 */

namespace WateralGenNHibernate.CAD.Wateral
{
public partial class ClaseCAD : BasicCAD, IClaseCAD
{
public ClaseCAD() : base ()
{
}

public ClaseCAD(ISession sessionAux) : base (sessionAux)
{
}



public ClaseEN ReadOIDDefault (int id
                               )
{
        ClaseEN claseEN = null;

        try
        {
                SessionInitializeTransaction ();
                claseEN = (ClaseEN)session.Get (typeof(ClaseEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in ClaseCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return claseEN;
}

public System.Collections.Generic.IList<ClaseEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<ClaseEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(ClaseEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<ClaseEN>();
                        else
                                result = session.CreateCriteria (typeof(ClaseEN)).List<ClaseEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in ClaseCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (ClaseEN clase)
{
        try
        {
                SessionInitializeTransaction ();
                ClaseEN claseEN = (ClaseEN)session.Load (typeof(ClaseEN), clase.Id);


                claseEN.Fecha = clase.Fecha;


                claseEN.HInicio = clase.HInicio;


                claseEN.HFin = clase.HFin;

                session.Update (claseEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in ClaseCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (ClaseEN clase)
{
        try
        {
                SessionInitializeTransaction ();
                if (clase.Grupo != null) {
                        // Argumento OID y no colección.
                        clase.Grupo = (WateralGenNHibernate.EN.Wateral.GrupoEN)session.Load (typeof(WateralGenNHibernate.EN.Wateral.GrupoEN), clase.Grupo.Id);

                        clase.Grupo.Clases
                        .Add (clase);
                }

                session.Save (clase);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in ClaseCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return clase.Id;
}

public void Modify (ClaseEN clase)
{
        try
        {
                SessionInitializeTransaction ();
                ClaseEN claseEN = (ClaseEN)session.Load (typeof(ClaseEN), clase.Id);

                claseEN.Fecha = clase.Fecha;


                claseEN.HInicio = clase.HInicio;


                claseEN.HFin = clase.HFin;

                session.Update (claseEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in ClaseCAD.", ex);
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
                ClaseEN claseEN = (ClaseEN)session.Load (typeof(ClaseEN), id);
                session.Delete (claseEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in ClaseCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: ClaseEN
public ClaseEN ReadOID (int id
                        )
{
        ClaseEN claseEN = null;

        try
        {
                SessionInitializeTransaction ();
                claseEN = (ClaseEN)session.Get (typeof(ClaseEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in ClaseCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return claseEN;
}

public System.Collections.Generic.IList<ClaseEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<ClaseEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(ClaseEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<ClaseEN>();
                else
                        result = session.CreateCriteria (typeof(ClaseEN)).List<ClaseEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in ClaseCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
