
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
 * Clase Matrícula:
 *
 */

namespace WateralGenNHibernate.CAD.Wateral
{
public partial class MatrículaCAD : BasicCAD, IMatrículaCAD
{
public MatrículaCAD() : base ()
{
}

public MatrículaCAD(ISession sessionAux) : base (sessionAux)
{
}



public MatrículaEN ReadOIDDefault (int id
                                   )
{
        MatrículaEN matrículaEN = null;

        try
        {
                SessionInitializeTransaction ();
                matrículaEN = (MatrículaEN)session.Get (typeof(MatrículaEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in MatrículaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return matrículaEN;
}

public System.Collections.Generic.IList<MatrículaEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<MatrículaEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(MatrículaEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<MatrículaEN>();
                        else
                                result = session.CreateCriteria (typeof(MatrículaEN)).List<MatrículaEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in MatrículaCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (MatrículaEN matrícula)
{
        try
        {
                SessionInitializeTransaction ();
                MatrículaEN matrículaEN = (MatrículaEN)session.Load (typeof(MatrículaEN), matrícula.Id);



                session.Update (matrículaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in MatrículaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (MatrículaEN matrícula)
{
        try
        {
                SessionInitializeTransaction ();
                if (matrícula.Alumno != null) {
                        // Argumento OID y no colección.
                        matrícula.Alumno = (WateralGenNHibernate.EN.Wateral.AlumnoEN)session.Load (typeof(WateralGenNHibernate.EN.Wateral.AlumnoEN), matrícula.Alumno.Idalumno);

                        matrícula.Alumno.Matrícula
                        .Add (matrícula);
                }
                if (matrícula.Curso != null) {
                        // Argumento OID y no colección.
                        matrícula.Curso = (WateralGenNHibernate.EN.Wateral.CursoEN)session.Load (typeof(WateralGenNHibernate.EN.Wateral.CursoEN), matrícula.Curso.Nombre);

                        matrícula.Curso.Matrículas
                        .Add (matrícula);
                }

                session.Save (matrícula);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in MatrículaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return matrícula.Id;
}

public void Modify (MatrículaEN matrícula)
{
        try
        {
                SessionInitializeTransaction ();
                MatrículaEN matrículaEN = (MatrículaEN)session.Load (typeof(MatrículaEN), matrícula.Id);
                session.Update (matrículaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in MatrículaCAD.", ex);
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
                MatrículaEN matrículaEN = (MatrículaEN)session.Load (typeof(MatrículaEN), id);
                session.Delete (matrículaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in MatrículaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: MatrículaEN
public MatrículaEN ReadOID (int id
                            )
{
        MatrículaEN matrículaEN = null;

        try
        {
                SessionInitializeTransaction ();
                matrículaEN = (MatrículaEN)session.Get (typeof(MatrículaEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in MatrículaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return matrículaEN;
}

public System.Collections.Generic.IList<MatrículaEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<MatrículaEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(MatrículaEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<MatrículaEN>();
                else
                        result = session.CreateCriteria (typeof(MatrículaEN)).List<MatrículaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is WateralGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new WateralGenNHibernate.Exceptions.DataLayerException ("Error in MatrículaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
