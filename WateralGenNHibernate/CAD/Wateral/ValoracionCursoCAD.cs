
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
 * Clase ValoracionCurso:
 *
 */

namespace WateralGenNHibernate.CAD.Wateral
{
public partial class ValoracionCursoCAD : BasicCAD, IValoracionCursoCAD
{
public ValoracionCursoCAD() : base ()
{
}

public ValoracionCursoCAD(ISession sessionAux) : base (sessionAux)
{
}



public ValoracionCursoEN ReadOIDDefault (int id_valoracion
                                         )
{
        ValoracionCursoEN valoracionCursoEN = null;

        try
        {
                SessionInitializeTransaction ();
                valoracionCursoEN = (ValoracionCursoEN)session.Get (typeof(ValoracionCursoEN), id_valoracion);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in ValoracionCursoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return valoracionCursoEN;
}

public System.Collections.Generic.IList<ValoracionCursoEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<ValoracionCursoEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(ValoracionCursoEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<ValoracionCursoEN>();
                        else
                                result = session.CreateCriteria (typeof(ValoracionCursoEN)).List<ValoracionCursoEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in ValoracionCursoCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (ValoracionCursoEN valoracionCurso)
{
        try
        {
                SessionInitializeTransaction ();
                ValoracionCursoEN valoracionCursoEN = (ValoracionCursoEN)session.Load (typeof(ValoracionCursoEN), valoracionCurso.Id_valoracion);


                session.Update (valoracionCursoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in ValoracionCursoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (ValoracionCursoEN valoracionCurso)
{
        try
        {
                SessionInitializeTransaction ();
                if (valoracionCurso.Alumno != null) {
                        // Argumento OID y no colección.
                        valoracionCurso.Alumno = (WateralGenNHibernate.EN.Wateral.AlumnoEN)session.Load (typeof(WateralGenNHibernate.EN.Wateral.AlumnoEN), valoracionCurso.Alumno.Idalumno);

                        valoracionCurso.Alumno.ValoracionesCurso
                        .Add (valoracionCurso);
                }
                if (valoracionCurso.Curso != null) {
                        // Argumento OID y no colección.
                        valoracionCurso.Curso = (WateralGenNHibernate.EN.Wateral.CursoEN)session.Load (typeof(WateralGenNHibernate.EN.Wateral.CursoEN), valoracionCurso.Curso.Id);

                        valoracionCurso.Curso.Valoraciones_curso
                        .Add (valoracionCurso);
                }

                session.Save (valoracionCurso);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in ValoracionCursoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return valoracionCurso.Id_valoracion;
}

public void Modify (ValoracionCursoEN valoracionCurso)
{
        try
        {
                SessionInitializeTransaction ();
                ValoracionCursoEN valoracionCursoEN = (ValoracionCursoEN)session.Load (typeof(ValoracionCursoEN), valoracionCurso.Id_valoracion);

                valoracionCursoEN.Nota = valoracionCurso.Nota;

                session.Update (valoracionCursoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in ValoracionCursoCAD.", ex);
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
                ValoracionCursoEN valoracionCursoEN = (ValoracionCursoEN)session.Load (typeof(ValoracionCursoEN), id_valoracion);
                session.Delete (valoracionCursoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in ValoracionCursoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public int ValorarCurso (ValoracionCursoEN valoracionCurso)
{
        try
        {
                SessionInitializeTransaction ();
                if (valoracionCurso.Alumno != null) {
                        // Argumento OID y no colección.
                        valoracionCurso.Alumno = (WateralGenNHibernate.EN.Wateral.AlumnoEN)session.Load (typeof(WateralGenNHibernate.EN.Wateral.AlumnoEN), valoracionCurso.Alumno.Idalumno);

                        valoracionCurso.Alumno.ValoracionesCurso
                        .Add (valoracionCurso);
                }
                if (valoracionCurso.Curso != null) {
                        // Argumento OID y no colección.
                        valoracionCurso.Curso = (WateralGenNHibernate.EN.Wateral.CursoEN)session.Load (typeof(WateralGenNHibernate.EN.Wateral.CursoEN), valoracionCurso.Curso.Id);

                        valoracionCurso.Curso.Valoraciones_curso
                        .Add (valoracionCurso);
                }

                session.Save (valoracionCurso);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in ValoracionCursoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return valoracionCurso.Id_valoracion;
}

//Sin e: ReadOID
//Con e: ValoracionCursoEN
public ValoracionCursoEN ReadOID (int id_valoracion
                                  )
{
        ValoracionCursoEN valoracionCursoEN = null;

        try
        {
                SessionInitializeTransaction ();
                valoracionCursoEN = (ValoracionCursoEN)session.Get (typeof(ValoracionCursoEN), id_valoracion);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in ValoracionCursoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return valoracionCursoEN;
}

public System.Collections.Generic.IList<ValoracionCursoEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<ValoracionCursoEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(ValoracionCursoEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<ValoracionCursoEN>();
                else
                        result = session.CreateCriteria (typeof(ValoracionCursoEN)).List<ValoracionCursoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in ValoracionCursoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
