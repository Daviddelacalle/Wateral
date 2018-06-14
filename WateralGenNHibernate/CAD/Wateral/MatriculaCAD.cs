
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
 * Clase Matricula:
 *
 */

namespace WateralGenNHibernate.CAD.Wateral
{
public partial class MatriculaCAD : BasicCAD, IMatriculaCAD
{
public MatriculaCAD() : base ()
{
}

public MatriculaCAD(ISession sessionAux) : base (sessionAux)
{
}



public MatriculaEN ReadOIDDefault (int id
                                   )
{
        MatriculaEN matriculaEN = null;

        try
        {
                SessionInitializeTransaction ();
                matriculaEN = (MatriculaEN)session.Get (typeof(MatriculaEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in MatriculaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return matriculaEN;
}

public System.Collections.Generic.IList<MatriculaEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<MatriculaEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(MatriculaEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<MatriculaEN>();
                        else
                                result = session.CreateCriteria (typeof(MatriculaEN)).List<MatriculaEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in MatriculaCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (MatriculaEN matricula)
{
        try
        {
                SessionInitializeTransaction ();
                MatriculaEN matriculaEN = (MatriculaEN)session.Load (typeof(MatriculaEN), matricula.Id);



                session.Update (matriculaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in MatriculaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (MatriculaEN matricula)
{
        try
        {
                SessionInitializeTransaction ();
                if (matricula.Curso != null) {
                        // Argumento OID y no colección.
                        matricula.Curso = (WateralGenNHibernate.EN.Wateral.CursoEN)session.Load (typeof(WateralGenNHibernate.EN.Wateral.CursoEN), matricula.Curso.Id);

                        matricula.Curso.Matriculas
                        .Add (matricula);
                }
                if (matricula.Alumno != null) {
                        // Argumento OID y no colección.
                        matricula.Alumno = (WateralGenNHibernate.EN.Wateral.AlumnoEN)session.Load (typeof(WateralGenNHibernate.EN.Wateral.AlumnoEN), matricula.Alumno.Idalumno);

                        matricula.Alumno.Matriculas
                        .Add (matricula);
                }

                session.Save (matricula);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in MatriculaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return matricula.Id;
}

public void Modify (MatriculaEN matricula)
{
        try
        {
                SessionInitializeTransaction ();
                MatriculaEN matriculaEN = (MatriculaEN)session.Load (typeof(MatriculaEN), matricula.Id);
                session.Update (matriculaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in MatriculaCAD.", ex);
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
                MatriculaEN matriculaEN = (MatriculaEN)session.Load (typeof(MatriculaEN), id);
                session.Delete (matriculaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in MatriculaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: MatriculaEN
public MatriculaEN ReadOID (int id
                            )
{
        MatriculaEN matriculaEN = null;

        try
        {
                SessionInitializeTransaction ();
                matriculaEN = (MatriculaEN)session.Get (typeof(MatriculaEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in MatriculaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return matriculaEN;
}

public System.Collections.Generic.IList<MatriculaEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<MatriculaEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(MatriculaEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<MatriculaEN>();
                else
                        result = session.CreateCriteria (typeof(MatriculaEN)).List<MatriculaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in MatriculaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
