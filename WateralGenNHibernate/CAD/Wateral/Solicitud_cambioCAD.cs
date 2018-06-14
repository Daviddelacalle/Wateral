
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
 * Clase Solicitud_cambio:
 *
 */

namespace WateralGenNHibernate.CAD.Wateral
{
public partial class Solicitud_cambioCAD : BasicCAD, ISolicitud_cambioCAD
{
public Solicitud_cambioCAD() : base ()
{
}

public Solicitud_cambioCAD(ISession sessionAux) : base (sessionAux)
{
}



public Solicitud_cambioEN ReadOIDDefault (int id
                                          )
{
        Solicitud_cambioEN solicitud_cambioEN = null;

        try
        {
                SessionInitializeTransaction ();
                solicitud_cambioEN = (Solicitud_cambioEN)session.Get (typeof(Solicitud_cambioEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in Solicitud_cambioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return solicitud_cambioEN;
}

public System.Collections.Generic.IList<Solicitud_cambioEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<Solicitud_cambioEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(Solicitud_cambioEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<Solicitud_cambioEN>();
                        else
                                result = session.CreateCriteria (typeof(Solicitud_cambioEN)).List<Solicitud_cambioEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in Solicitud_cambioCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (Solicitud_cambioEN solicitud_cambio)
{
        try
        {
                SessionInitializeTransaction ();
                Solicitud_cambioEN solicitud_cambioEN = (Solicitud_cambioEN)session.Load (typeof(Solicitud_cambioEN), solicitud_cambio.Id);

                solicitud_cambioEN.Validado = solicitud_cambio.Validado;




                session.Update (solicitud_cambioEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in Solicitud_cambioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (Solicitud_cambioEN solicitud_cambio)
{
        try
        {
                SessionInitializeTransaction ();
                if (solicitud_cambio.Alumno != null) {
                        // Argumento OID y no colección.
                        solicitud_cambio.Alumno = (WateralGenNHibernate.EN.Wateral.AlumnoEN)session.Load (typeof(WateralGenNHibernate.EN.Wateral.AlumnoEN), solicitud_cambio.Alumno.Idalumno);

                        solicitud_cambio.Alumno.Solicitudes_cambio
                        .Add (solicitud_cambio);
                }
                if (solicitud_cambio.Grupo != null) {
                        // Argumento OID y no colección.
                        solicitud_cambio.Grupo = (WateralGenNHibernate.EN.Wateral.GrupoEN)session.Load (typeof(WateralGenNHibernate.EN.Wateral.GrupoEN), solicitud_cambio.Grupo.Id);

                        solicitud_cambio.Grupo.Solicitudes_cambio
                        .Add (solicitud_cambio);
                }
                if (solicitud_cambio.Grupo_0 != null) {
                        // Argumento OID y no colección.
                        solicitud_cambio.Grupo_0 = (WateralGenNHibernate.EN.Wateral.GrupoEN)session.Load (typeof(WateralGenNHibernate.EN.Wateral.GrupoEN), solicitud_cambio.Grupo_0.Id);

                        solicitud_cambio.Grupo_0.Solicitudes_cambio_0
                        .Add (solicitud_cambio);
                }

                session.Save (solicitud_cambio);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in Solicitud_cambioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return solicitud_cambio.Id;
}

public void Modify (Solicitud_cambioEN solicitud_cambio)
{
        try
        {
                SessionInitializeTransaction ();
                Solicitud_cambioEN solicitud_cambioEN = (Solicitud_cambioEN)session.Load (typeof(Solicitud_cambioEN), solicitud_cambio.Id);

                solicitud_cambioEN.Validado = solicitud_cambio.Validado;

                session.Update (solicitud_cambioEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in Solicitud_cambioCAD.", ex);
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
                Solicitud_cambioEN solicitud_cambioEN = (Solicitud_cambioEN)session.Load (typeof(Solicitud_cambioEN), id);
                session.Delete (solicitud_cambioEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in Solicitud_cambioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: Solicitud_cambioEN
public Solicitud_cambioEN ReadOID (int id
                                   )
{
        Solicitud_cambioEN solicitud_cambioEN = null;

        try
        {
                SessionInitializeTransaction ();
                solicitud_cambioEN = (Solicitud_cambioEN)session.Get (typeof(Solicitud_cambioEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in Solicitud_cambioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return solicitud_cambioEN;
}

public System.Collections.Generic.IList<Solicitud_cambioEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<Solicitud_cambioEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(Solicitud_cambioEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<Solicitud_cambioEN>();
                else
                        result = session.CreateCriteria (typeof(Solicitud_cambioEN)).List<Solicitud_cambioEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in Solicitud_cambioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
