
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
 * Clase ValoracionProfesor:
 *
 */

namespace WateralGenNHibernate.CAD.Wateral
{
public partial class ValoracionProfesorCAD : BasicCAD, IValoracionProfesorCAD
{
public ValoracionProfesorCAD() : base ()
{
}

public ValoracionProfesorCAD(ISession sessionAux) : base (sessionAux)
{
}



public ValoracionProfesorEN ReadOIDDefault (int id_valoracion
                                            )
{
        ValoracionProfesorEN valoracionProfesorEN = null;

        try
        {
                SessionInitializeTransaction ();
                valoracionProfesorEN = (ValoracionProfesorEN)session.Get (typeof(ValoracionProfesorEN), id_valoracion);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in ValoracionProfesorCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return valoracionProfesorEN;
}

public System.Collections.Generic.IList<ValoracionProfesorEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<ValoracionProfesorEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(ValoracionProfesorEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<ValoracionProfesorEN>();
                        else
                                result = session.CreateCriteria (typeof(ValoracionProfesorEN)).List<ValoracionProfesorEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in ValoracionProfesorCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (ValoracionProfesorEN valoracionProfesor)
{
        try
        {
                SessionInitializeTransaction ();
                ValoracionProfesorEN valoracionProfesorEN = (ValoracionProfesorEN)session.Load (typeof(ValoracionProfesorEN), valoracionProfesor.Id_valoracion);


                session.Update (valoracionProfesorEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in ValoracionProfesorCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (ValoracionProfesorEN valoracionProfesor)
{
        try
        {
                SessionInitializeTransaction ();
                if (valoracionProfesor.Alumno_0 != null) {
                        // Argumento OID y no colección.
                        valoracionProfesor.Alumno_0 = (WateralGenNHibernate.EN.Wateral.AlumnoEN)session.Load (typeof(WateralGenNHibernate.EN.Wateral.AlumnoEN), valoracionProfesor.Alumno_0.Idalumno);

                        valoracionProfesor.Alumno_0.ValoracionesProfesor
                        .Add (valoracionProfesor);
                }
                if (valoracionProfesor.Profesor != null) {
                        // Argumento OID y no colección.
                        valoracionProfesor.Profesor = (WateralGenNHibernate.EN.Wateral.ProfesorEN)session.Load (typeof(WateralGenNHibernate.EN.Wateral.ProfesorEN), valoracionProfesor.Profesor.Id);

                        valoracionProfesor.Profesor.ValoracionesProfesor_0
                        .Add (valoracionProfesor);
                }

                session.Save (valoracionProfesor);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in ValoracionProfesorCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return valoracionProfesor.Id_valoracion;
}

public void Modify (ValoracionProfesorEN valoracionProfesor)
{
        try
        {
                SessionInitializeTransaction ();
                ValoracionProfesorEN valoracionProfesorEN = (ValoracionProfesorEN)session.Load (typeof(ValoracionProfesorEN), valoracionProfesor.Id_valoracion);

                valoracionProfesorEN.Nota = valoracionProfesor.Nota;

                session.Update (valoracionProfesorEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in ValoracionProfesorCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Destroy (int id_valoracion
                     )
{
        try
        {
                SessionInitializeTransaction ();
                ValoracionProfesorEN valoracionProfesorEN = (ValoracionProfesorEN)session.Load (typeof(ValoracionProfesorEN), id_valoracion);
                session.Delete (valoracionProfesorEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in ValoracionProfesorCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public int ValorarProfesor (ValoracionProfesorEN valoracionProfesor)
{
        try
        {
                SessionInitializeTransaction ();
                if (valoracionProfesor.Alumno_0 != null) {
                        // Argumento OID y no colección.
                        valoracionProfesor.Alumno_0 = (WateralGenNHibernate.EN.Wateral.AlumnoEN)session.Load (typeof(WateralGenNHibernate.EN.Wateral.AlumnoEN), valoracionProfesor.Alumno_0.Idalumno);

                        valoracionProfesor.Alumno_0.ValoracionesProfesor
                        .Add (valoracionProfesor);
                }
                if (valoracionProfesor.Profesor != null) {
                        // Argumento OID y no colección.
                        valoracionProfesor.Profesor = (WateralGenNHibernate.EN.Wateral.ProfesorEN)session.Load (typeof(WateralGenNHibernate.EN.Wateral.ProfesorEN), valoracionProfesor.Profesor.Id);

                        valoracionProfesor.Profesor.ValoracionesProfesor_0
                        .Add (valoracionProfesor);
                }

                session.Save (valoracionProfesor);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in ValoracionProfesorCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return valoracionProfesor.Id_valoracion;
}

//Sin e: ReadOID
//Con e: ValoracionProfesorEN
public ValoracionProfesorEN ReadOID (int id_valoracion
                                     )
{
        ValoracionProfesorEN valoracionProfesorEN = null;

        try
        {
                SessionInitializeTransaction ();
                valoracionProfesorEN = (ValoracionProfesorEN)session.Get (typeof(ValoracionProfesorEN), id_valoracion);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in ValoracionProfesorCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return valoracionProfesorEN;
}

public System.Collections.Generic.IList<ValoracionProfesorEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<ValoracionProfesorEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(ValoracionProfesorEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<ValoracionProfesorEN>();
                else
                        result = session.CreateCriteria (typeof(ValoracionProfesorEN)).List<ValoracionProfesorEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in ValoracionProfesorCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
