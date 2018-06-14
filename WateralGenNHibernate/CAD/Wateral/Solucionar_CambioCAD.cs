
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
 * Clase Solucionar_Cambio:
 *
 */

namespace WateralGenNHibernate.CAD.Wateral
{
public partial class Solucionar_CambioCAD : BasicCAD, ISolucionar_CambioCAD
{
public Solucionar_CambioCAD() : base ()
{
}

public Solucionar_CambioCAD(ISession sessionAux) : base (sessionAux)
{
}



public Solucionar_CambioEN ReadOIDDefault (int id
                                           )
{
        Solucionar_CambioEN solucionar_CambioEN = null;

        try
        {
                SessionInitializeTransaction ();
                solucionar_CambioEN = (Solucionar_CambioEN)session.Get (typeof(Solucionar_CambioEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in Solucionar_CambioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return solucionar_CambioEN;
}

public System.Collections.Generic.IList<Solucionar_CambioEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<Solucionar_CambioEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(Solucionar_CambioEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<Solucionar_CambioEN>();
                        else
                                result = session.CreateCriteria (typeof(Solucionar_CambioEN)).List<Solucionar_CambioEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in Solucionar_CambioCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (Solucionar_CambioEN solucionar_Cambio)
{
        try
        {
                SessionInitializeTransaction ();
                Solucionar_CambioEN solucionar_CambioEN = (Solucionar_CambioEN)session.Load (typeof(Solucionar_CambioEN), solucionar_Cambio.Id);



                session.Update (solucionar_CambioEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in Solucionar_CambioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (Solucionar_CambioEN solucionar_Cambio)
{
        try
        {
                SessionInitializeTransaction ();
                if (solucionar_Cambio.Alumnos != null) {
                        for (int i = 0; i < solucionar_Cambio.Alumnos.Count; i++) {
                                solucionar_Cambio.Alumnos [i] = (WateralGenNHibernate.EN.Wateral.AlumnoEN)session.Load (typeof(WateralGenNHibernate.EN.Wateral.AlumnoEN), solucionar_Cambio.Alumnos [i].Email);
                                solucionar_Cambio.Alumnos [i].Solucionar_Cambio.Add (solucionar_Cambio);
                        }
                }
                if (solucionar_Cambio.Grupo != null) {
                        // Argumento OID y no colección.
                        solucionar_Cambio.Grupo = (WateralGenNHibernate.EN.Wateral.GrupoEN)session.Load (typeof(WateralGenNHibernate.EN.Wateral.GrupoEN), solucionar_Cambio.Grupo.Id);

                        solucionar_Cambio.Grupo.Solucionar_Cambios
                        .Add (solucionar_Cambio);
                }

                session.Save (solucionar_Cambio);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in Solucionar_CambioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return solucionar_Cambio.Id;
}

public void Modify (Solucionar_CambioEN solucionar_Cambio)
{
        try
        {
                SessionInitializeTransaction ();
                Solucionar_CambioEN solucionar_CambioEN = (Solucionar_CambioEN)session.Load (typeof(Solucionar_CambioEN), solucionar_Cambio.Id);
                session.Update (solucionar_CambioEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in Solucionar_CambioCAD.", ex);
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
                Solucionar_CambioEN solucionar_CambioEN = (Solucionar_CambioEN)session.Load (typeof(Solucionar_CambioEN), id);
                session.Delete (solucionar_CambioEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in Solucionar_CambioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
