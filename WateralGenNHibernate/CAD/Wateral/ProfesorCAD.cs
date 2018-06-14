
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
 * Clase Profesor:
 *
 */

namespace WateralGenNHibernate.CAD.Wateral
{
public partial class ProfesorCAD : BasicCAD, IProfesorCAD
{
public ProfesorCAD() : base ()
{
}

public ProfesorCAD(ISession sessionAux) : base (sessionAux)
{
}



public ProfesorEN ReadOIDDefault (int id
                                  )
{
        ProfesorEN profesorEN = null;

        try
        {
                SessionInitializeTransaction ();
                profesorEN = (ProfesorEN)session.Get (typeof(ProfesorEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in ProfesorCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return profesorEN;
}

public System.Collections.Generic.IList<ProfesorEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<ProfesorEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(ProfesorEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<ProfesorEN>();
                        else
                                result = session.CreateCriteria (typeof(ProfesorEN)).List<ProfesorEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in ProfesorCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (ProfesorEN profesor)
{
        try
        {
                SessionInitializeTransaction ();
                ProfesorEN profesorEN = (ProfesorEN)session.Load (typeof(ProfesorEN), profesor.Id);

                profesorEN.NIF = profesor.NIF;



                profesorEN.Disponibilidad = profesor.Disponibilidad;




                profesorEN.Deporte = profesor.Deporte;

                session.Update (profesorEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in ProfesorCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (ProfesorEN profesor)
{
        try
        {
                SessionInitializeTransaction ();
                if (profesor.UserRegistrado != null) {
                        // Argumento OID y no colección.
                        profesor.UserRegistrado = (WateralGenNHibernate.EN.Wateral.UserRegistradoEN)session.Load (typeof(WateralGenNHibernate.EN.Wateral.UserRegistradoEN), profesor.UserRegistrado.Email);

                        profesor.UserRegistrado.Profesor
                                = profesor;
                }

                session.Save (profesor);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in ProfesorCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return profesor.Id;
}

public void Modify (ProfesorEN profesor)
{
        try
        {
                SessionInitializeTransaction ();
                ProfesorEN profesorEN = (ProfesorEN)session.Load (typeof(ProfesorEN), profesor.Id);

                profesorEN.NIF = profesor.NIF;


                profesorEN.Disponibilidad = profesor.Disponibilidad;


                profesorEN.Deporte = profesor.Deporte;

                session.Update (profesorEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in ProfesorCAD.", ex);
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
                ProfesorEN profesorEN = (ProfesorEN)session.Load (typeof(ProfesorEN), id);
                session.Delete (profesorEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in ProfesorCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: ProfesorEN
public ProfesorEN ReadOID (int id
                           )
{
        ProfesorEN profesorEN = null;

        try
        {
                SessionInitializeTransaction ();
                profesorEN = (ProfesorEN)session.Get (typeof(ProfesorEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in ProfesorCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return profesorEN;
}

public System.Collections.Generic.IList<ProfesorEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<ProfesorEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(ProfesorEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<ProfesorEN>();
                else
                        result = session.CreateCriteria (typeof(ProfesorEN)).List<ProfesorEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in ProfesorCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
